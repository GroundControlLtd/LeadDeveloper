using System;
using System.Net.Http;
using System.Threading.Tasks;
using Shared;

namespace Interview
{
    public class LibraryService : ILibraryService
    {
        public async Task<string> BorrowBook(Book book)
        {
            using var client = new HttpClient {BaseAddress = new Uri("https://localhost:44321")};

            var response = await client.PostAsync("/api/library/borrowbook", book.ToHttpContent());
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }

            return await response.Content.ReadAsStringAsync();
        }
    }
}
