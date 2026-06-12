using App.Core.Utilities;
using System;

namespace App.Core.Models
{
    public class BookIssue
    {
        public string Id { get; set; }
        public string BookId { get; set; }
        public string BookTitle { get; set; }
        public string MemberId { get; set; }
        public string MemberName { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public IssueStatusEnum Status { get; set; }

        public BookIssue()
        {
            
            IssueDate = DateTime.Now;
            Status = IssueStatusEnum.Issued;
        }
    }
}
