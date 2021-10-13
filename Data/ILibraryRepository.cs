using System;
using Shared;

namespace Data
{
    public interface ILibraryRepository
    {
        DateTime BorrowBook(Book book);
    }
}