using App.Core.Models;
using App.Core.Utilities;
using System.Collections.Generic;

namespace App.Core.Contracts
{
    public interface IBookIssueService
    {
        void Add(BookIssue issue);
        void Update(BookIssue issue);
        void Delete(string id);
        BookIssue GetById(string id);
        List<BookIssue> GetAll();
        List<BookIssue> GetByMemberId(string memberId);
        List<BookIssue> GetByStatus(IssueStatusEnum status);
    }
}
