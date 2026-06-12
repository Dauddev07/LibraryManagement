using App.Core.Utilities;
using System;

namespace App.Core.Models
{
    public class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public BookCategoryEnum Category { get; set; }
        public int Stock { get; set; }
        public BookStatusEnum Status { get; set; }

        public Book() { }
    }
}
