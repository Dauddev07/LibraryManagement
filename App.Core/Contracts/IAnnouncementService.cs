using App.Core.Models;
using System.Collections.Generic;

namespace App.Core.Contracts
{
    public interface IAnnouncementService
    {
        void Add(Announcement announcement);
        void Update(Announcement announcement);
        void Delete(string id);
        Announcement GetById(string id);
        List<Announcement> GetAll();
        List<Announcement> GetActive();
    }
}