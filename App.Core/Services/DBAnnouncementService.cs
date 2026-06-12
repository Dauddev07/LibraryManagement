using App.Core.Contracts;
using App.Core.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace App.Core.Services
{
    public class DBAnnouncementService : IAnnouncementService
    {
        private readonly string _connectionString;

        public DBAnnouncementService(string connString)
        {
            _connectionString = connString;
        }

        public void Add(Announcement announcement)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Announcement (Id, Title, Message, PostedDate, IsActive) " +
                             "VALUES (@Id, @Title, @Message, @PostedDate, @IsActive)";
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", announcement.Id);
                cmd.Parameters.AddWithValue("@Title", announcement.Title);
                cmd.Parameters.AddWithValue("@Message", announcement.Message);
                cmd.Parameters.AddWithValue("@PostedDate", announcement.PostedDate);
                cmd.Parameters.AddWithValue("@IsActive", announcement.IsActive);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Announcement announcement)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "UPDATE Announcement SET Title=@Title, Message=@Message, IsActive=@IsActive WHERE Id=@Id";
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", announcement.Id);
                cmd.Parameters.AddWithValue("@Title", announcement.Title);
                cmd.Parameters.AddWithValue("@Message", announcement.Message);
                cmd.Parameters.AddWithValue("@IsActive", announcement.IsActive);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM Announcement WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public Announcement GetById(string id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Announcement WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        return ReadAnnouncement(reader);
                }
            }
            return null;
        }

        public List<Announcement> GetAll()
        {
            var list = new List<Announcement>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Announcement ORDER BY PostedDate DESC", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        list.Add(ReadAnnouncement(reader));
                }
            }
            return list;
        }

        public List<Announcement> GetActive()
        {
            var list = new List<Announcement>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Announcement WHERE IsActive=1 ORDER BY PostedDate DESC", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        list.Add(ReadAnnouncement(reader));
                }
            }
            return list;
        }

        private Announcement ReadAnnouncement(SqlDataReader reader)
        {
            return new Announcement
            {
                Id = reader["Id"].ToString(),
                Title = reader["Title"].ToString(),
                Message = reader["Message"].ToString(),
                PostedDate = Convert.ToDateTime(reader["PostedDate"]),
                IsActive = Convert.ToBoolean(reader["IsActive"])
            };
        }
    }
}