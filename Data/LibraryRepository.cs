using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class LibraryRepository
    {
        private readonly List<Book> _books = new List<Book>(){ new Book { Author = "Aldous Huxley", Title = "Brave New World" } };

        public DateTime BorrowBook(Book book)
        {
            if (_books.Count(b=> b.Title == book.Title && b.Author == book.Author) == 0)
            {
                throw new Exception("Book not found!");
            }

            return  DateTime.Now.AddDays(30);
        }
    }
}
