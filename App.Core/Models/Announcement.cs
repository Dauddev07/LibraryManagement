using System;

namespace App.Core.Models
{
    public class Announcement
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime PostedDate { get; set; }
        public bool IsActive { get; set; }

        public Announcement()
        {
            Id = "A-" + Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();
            PostedDate = DateTime.Now;
            IsActive = true;
        }
    }
}