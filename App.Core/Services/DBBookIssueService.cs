using App.Core.Contracts;
using App.Core.Models;
using App.Core.Utilities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace App.Core.Services
{
    public class DBBookIssueService : IBookIssueService
    {
        private readonly string _connectionString;

        public DBBookIssueService(string connString)
        {
            _connectionString = connString;
        }

        void IBookIssueService.Add(BookIssue issue)
        {
            issue.Id = "I-" + Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                // Check book status before issuing
                SqlCommand checkBook = new SqlCommand(
                    "SELECT Stock, Status FROM Book WHERE Id=@BookId", conn);
                checkBook.Parameters.AddWithValue("@BookId", issue.BookId);

                using (var reader = checkBook.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string bookStatus = reader["Status"].ToString();
                        int currentStock = Convert.ToInt32(reader["Stock"]);

                        if (bookStatus == BookStatusEnum.Lost.ToString())
                            throw new Exception("This book is marked as Lost and cannot be issued.");

                        if (bookStatus == BookStatusEnum.Issued.ToString())
                            throw new Exception("This book is already marked as Issued and cannot be issued again.");

                        if (currentStock <= 0)
                            throw new Exception("This book is out of stock and cannot be issued.");
                    }
                }

                // Insert issue record
                string sql = "INSERT INTO BookIssue(Id, BookId, BookTitle, MemberId, MemberName, IssueDate, ReturnDate, Status) " +
                             "VALUES (@Id, @BookId, @BookTitle, @MemberId, @MemberName, @IssueDate, @ReturnDate, @Status)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", issue.Id);
                cmd.Parameters.AddWithValue("@BookId", issue.BookId);
                cmd.Parameters.AddWithValue("@BookTitle", issue.BookTitle ?? "");
                cmd.Parameters.AddWithValue("@MemberId", issue.MemberId);
                cmd.Parameters.AddWithValue("@MemberName", issue.MemberName ?? "");
                cmd.Parameters.AddWithValue("@IssueDate", issue.IssueDate);
                cmd.Parameters.AddWithValue("@ReturnDate", (object)issue.ReturnDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Status", issue.Status.ToString());
                cmd.ExecuteNonQuery();

                // Decrease stock by 1 and mark as Issued if stock reaches 0
                SqlCommand decreaseStock = new SqlCommand(
                    "UPDATE Book SET Stock = Stock - 1, " +
                    "Status = CASE WHEN Stock - 1 <= 0 THEN @IssuedStatus ELSE Status END " +
                    "WHERE Id = @BookId", conn);
                decreaseStock.Parameters.AddWithValue("@BookId", issue.BookId);
                decreaseStock.Parameters.AddWithValue("@IssuedStatus", BookStatusEnum.Issued.ToString());
                decreaseStock.ExecuteNonQuery();
            }
        }

        void IBookIssueService.Update(BookIssue issue)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                // Get old status
                SqlCommand getOld = new SqlCommand("SELECT Status FROM BookIssue WHERE Id=@Id", conn);
                getOld.Parameters.AddWithValue("@Id", issue.Id);
                string oldStatus = getOld.ExecuteScalar()?.ToString();

                // Guard: a Returned record is final — it cannot be re-issued or marked Overdue
                if (oldStatus == IssueStatusEnum.Returned.ToString() &&
                    issue.Status != IssueStatusEnum.Returned)
                {
                    throw new InvalidOperationException(
                        "A returned book issue record cannot be changed back to Issued or Overdue.");
                }

                // Update issue record
                string sql = "UPDATE BookIssue SET BookId=@BookId, BookTitle=@BookTitle, MemberId=@MemberId, " +
                             "MemberName=@MemberName, IssueDate=@IssueDate, ReturnDate=@ReturnDate, Status=@Status WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", issue.Id);
                cmd.Parameters.AddWithValue("@BookId", issue.BookId);
                cmd.Parameters.AddWithValue("@BookTitle", issue.BookTitle ?? "");
                cmd.Parameters.AddWithValue("@MemberId", issue.MemberId);
                cmd.Parameters.AddWithValue("@MemberName", issue.MemberName ?? "");
                cmd.Parameters.AddWithValue("@IssueDate", issue.IssueDate);
                cmd.Parameters.AddWithValue("@ReturnDate", (object)issue.ReturnDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Status", issue.Status.ToString());
                cmd.ExecuteNonQuery();

                // Stock adjustment based on status transition.
                // A Returned record is permanently locked — no transition away from Returned is allowed.
                // Only two transitions require a stock update:
                //   Issued → Returned  or  Overdue → Returned : book came back, restore stock.
                //   Issued ↔ Overdue                          : book hasn't moved, no stock change.
                bool wasIssued = oldStatus == IssueStatusEnum.Issued.ToString();
                bool wasOverdue = oldStatus == IssueStatusEnum.Overdue.ToString();
                bool nowReturned = issue.Status == IssueStatusEnum.Returned;

                if ((wasIssued || wasOverdue) && nowReturned)
                {
                    // Book physically came back — increase stock, mark Available if stock was 0
                    SqlCommand increaseStock = new SqlCommand(
                        "UPDATE Book SET Stock = Stock + 1, " +
                        "Status = CASE WHEN Status = @IssuedStatus THEN @AvailableStatus ELSE Status END " +
                        "WHERE Id = @BookId", conn);
                    increaseStock.Parameters.AddWithValue("@BookId", issue.BookId);
                    increaseStock.Parameters.AddWithValue("@IssuedStatus", BookStatusEnum.Issued.ToString());
                    increaseStock.Parameters.AddWithValue("@AvailableStatus", BookStatusEnum.Available.ToString());
                    increaseStock.ExecuteNonQuery();
                }
                // Issued ↔ Overdue transitions: book hasn't physically moved, no stock change needed
            }
        }

        void IBookIssueService.Delete(string id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM BookIssue WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        BookIssue IBookIssueService.GetById(string id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM BookIssue WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        return ReadIssue(reader);
                }
            }
            return null;
        }

        List<BookIssue> IBookIssueService.GetAll()
        {
            var issues = new List<BookIssue>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM BookIssue ORDER BY IssueDate DESC", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        issues.Add(ReadIssue(reader));
                }
            }
            return issues;
        }

        List<BookIssue> IBookIssueService.GetByMemberId(string memberId)
        {
            var issues = new List<BookIssue>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM BookIssue WHERE MemberId=@MemberId ORDER BY IssueDate DESC", conn);
                cmd.Parameters.AddWithValue("@MemberId", memberId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        issues.Add(ReadIssue(reader));
                }
            }
            return issues;
        }

        List<BookIssue> IBookIssueService.GetByStatus(IssueStatusEnum status)
        {
            var issues = new List<BookIssue>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM BookIssue WHERE Status=@Status ORDER BY IssueDate DESC", conn);
                cmd.Parameters.AddWithValue("@Status", status.ToString());
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        issues.Add(ReadIssue(reader));
                }
            }
            return issues;
        }

        private BookIssue ReadIssue(SqlDataReader reader)
        {
            BookIssue issue = new BookIssue();
            issue.Id = reader["Id"].ToString();
            issue.BookId = reader["BookId"].ToString();
            issue.BookTitle = reader["BookTitle"].ToString();
            issue.MemberId = reader["MemberId"].ToString();
            issue.MemberName = reader["MemberName"].ToString();
            issue.IssueDate = Convert.ToDateTime(reader["IssueDate"]);
            issue.ReturnDate = reader["ReturnDate"] == DBNull.Value ? null : Convert.ToDateTime(reader["ReturnDate"]);
            string statusStr = reader["Status"].ToString();
            issue.Status = Enum.TryParse<IssueStatusEnum>(statusStr, true, out var s) ? s : IssueStatusEnum.Issued;
            return issue;
        }
    }
}