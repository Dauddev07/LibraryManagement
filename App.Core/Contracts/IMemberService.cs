using App.Core.Models;
using System.Collections.Generic;

namespace App.Core.Contracts
{
    public interface IMemberService
    {
        void Add(Member member);
        void Update(Member member);
        void Delete(string id);
        Member GetById(string id);
        List<Member> GetAll();
        List<Member> Search(string query);
    }
}
