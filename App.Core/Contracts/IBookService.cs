using App.Core.Models;
using App.Core.Utilities;
using System.Collections.Generic;

namespace App.Core.Contracts
{
    public interface IBookService
    {
        Book Add(Book book);
        bool Update(Book book);
        bool Delete(string id);
        Book GetById(string id);
        List<Book> GetAll();
        List<Book> Search(string text, BookCategoryEnum? category, BookStatusEnum? status);
    }
}
