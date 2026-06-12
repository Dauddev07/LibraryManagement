using App.Core.Contracts;
using App.Core.Models;
using App.Core.Utilities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace App.Core.Services
{
    public class DBBookService : IBookService
    {
        private readonly string _connectionString;

        public DBBookService(string connString)
        {
            _connectionString = connString;
        }

        Book IBookService.Add(Book book)
        {
            book.Id = "B-" + Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Book(Id, Title, Author, ISBN, Category, Stock, Status) VALUES (@Id, @Title, @Author, @ISBN, @Category, @Stock, @Status)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", book.Id);
                cmd.Parameters.AddWithValue("@Title", book.Title);
                cmd.Parameters.AddWithValue("@Author", book.Author);
                cmd.Parameters.AddWithValue("@ISBN", book.ISBN ?? "");
                cmd.Parameters.AddWithValue("@Category", book.Category.ToString());
                cmd.Parameters.AddWithValue("@Stock", book.Stock);
                cmd.Parameters.AddWithValue("@Status", book.Status.ToString());

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    return book;
                else
                    return null;
            }
        }

        bool IBookService.Update(Book book)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "UPDATE Book SET Title=@Title, Author=@Author, ISBN=@ISBN, Category=@Category, Stock=@Stock, Status=@Status WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", book.Id);
                cmd.Parameters.AddWithValue("@Title", book.Title);
                cmd.Parameters.AddWithValue("@Author", book.Author);
                cmd.Parameters.AddWithValue("@ISBN", book.ISBN ?? "");
                cmd.Parameters.AddWithValue("@Category", book.Category.ToString());
                cmd.Parameters.AddWithValue("@Stock", book.Stock);
                cmd.Parameters.AddWithValue("@Status", book.Status.ToString());

                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        bool IBookService.Delete(string id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM Book WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        Book IBookService.GetById(string id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Book WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return ReadBook(reader);
                    }
                }
            }
            return null;
        }

        List<Book> IBookService.GetAll()
        {
            List<Book> books = new List<Book>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Book ORDER BY Title", conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(ReadBook(reader));
                    }
                }
            }
            return books;
        }

        List<Book> IBookService.Search(string text, BookCategoryEnum? category, BookStatusEnum? status)
        {
            List<Book> books = new List<Book>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                string sql = "SELECT * FROM Book WHERE (Title LIKE @text OR Author LIKE @text)";

                if (category != null)
                    sql += " AND Category=@cat";

                if (status != null)
                    sql += " AND Status=@status";

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@text", "%" + text.Trim() + "%");

                if (category != null)
                    cmd.Parameters.AddWithValue("@cat", category.ToString());

                if (status != null)
                    cmd.Parameters.AddWithValue("@status", status.ToString());

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(ReadBook(reader));
                    }
                }
            }
            return books;
        }

        // Helper method to avoid repeating reader parsing code
        private Book ReadBook(SqlDataReader reader)
        {
            Book book = new Book();
            book.Id = reader["Id"].ToString();
            book.Title = reader["Title"].ToString();
            book.Author = reader["Author"].ToString();
            book.ISBN = reader["ISBN"].ToString();

            string catStr = reader["Category"].ToString();
            book.Category = Enum.TryParse<BookCategoryEnum>(catStr, ignoreCase: true, out var catParsed) ? catParsed : BookCategoryEnum.General;

            book.Stock = Convert.ToInt32(reader["Stock"]);

            string statusStr = reader["Status"].ToString();
            book.Status = Enum.TryParse<BookStatusEnum>(statusStr, ignoreCase: true, out var statusParsed) ? statusParsed : BookStatusEnum.Available;

            return book;
        }
    }
}
