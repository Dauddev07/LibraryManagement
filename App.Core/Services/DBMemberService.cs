using App.Core.Contracts;
using App.Core.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace App.Core.Services
{
    public class DBMemberService : IMemberService
    {
        private readonly string _connectionString;

        public DBMemberService(string connString)
        {
            _connectionString = connString;
        }

        void IMemberService.Add(Member member)
        {
            member.Id = "M-" + Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Member(Id, Name, Phone, Email, Address) VALUES (@Id, @Name, @Phone, @Email, @Address)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", member.Id);
                cmd.Parameters.AddWithValue("@Name", member.Name);
                cmd.Parameters.AddWithValue("@Phone", member.Phone ?? "");
                cmd.Parameters.AddWithValue("@Email", member.Email ?? "");
                cmd.Parameters.AddWithValue("@Address", member.Address ?? "");
                cmd.ExecuteNonQuery();
            }
        }

        void IMemberService.Update(Member member)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "UPDATE Member SET Name=@Name, Phone=@Phone, Email=@Email, Address=@Address WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", member.Id);
                cmd.Parameters.AddWithValue("@Name", member.Name);
                cmd.Parameters.AddWithValue("@Phone", member.Phone ?? "");
                cmd.Parameters.AddWithValue("@Email", member.Email ?? "");
                cmd.Parameters.AddWithValue("@Address", member.Address ?? "");
                cmd.ExecuteNonQuery();
            }
        }

        void IMemberService.Delete(string id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM Member WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        Member IMemberService.GetById(string id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Member WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return ReadMember(reader);
                    }
                }
            }
            return null;
        }

        List<Member> IMemberService.GetAll()
        {
            List<Member> members = new List<Member>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Member ORDER BY Name", conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        members.Add(ReadMember(reader));
                    }
                }
            }
            return members;
        }

        List<Member> IMemberService.Search(string query)
        {
            List<Member> members = new List<Member>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Member WHERE Name LIKE @query OR Phone LIKE @query OR Email LIKE @query";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@query", "%" + query.Trim() + "%");

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        members.Add(ReadMember(reader));
                    }
                }
            }
            return members;
        }

        private Member ReadMember(SqlDataReader reader)
        {
            Member member = new Member();
            member.Id = reader["Id"].ToString();
            member.Name = reader["Name"].ToString();
            member.Phone = reader["Phone"].ToString();
            member.Email = reader["Email"].ToString();
            member.Address = reader["Address"].ToString();
            return member;
        }
    }
}
