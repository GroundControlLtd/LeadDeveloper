using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Shared;

namespace Interview
{
    public class LibraryService
    {
        public static JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        public async Task<string> BorrowBook(Book book)
        {
            using var client = new HttpClient {BaseAddress = new Uri("https://localhost:44321")};
            var json = JsonSerializer.Serialize(book, JsonSerializerOptions);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/library/borrowbook", content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }

            return await response.Content.ReadAsStringAsync();
        }
    }
}
