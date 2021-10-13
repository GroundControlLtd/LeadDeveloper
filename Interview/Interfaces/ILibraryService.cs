using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    public interface ILibraryService
    {
        Task<string> BorrowBook(Book book);
    }
}
