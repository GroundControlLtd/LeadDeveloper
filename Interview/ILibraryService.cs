using System.Threading.Tasks;
using Shared;

namespace Interview
{
    public interface ILibraryService
    {
        Task<string> BorrowBook(Book book);
    }
}