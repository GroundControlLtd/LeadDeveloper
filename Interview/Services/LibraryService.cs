using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Interview.Configuration;
using Interview.Extenstions;
using Interview.Interfaces;
using Shared;

namespace Interview
{
    public class LibraryService: ILibraryService
    {
        private readonly string _baseUrl;
        private readonly string _endPoint;
        /// <summary>
        /// Dependency injection for configuration keys
        /// </summary>
        /// <param name="configuration"></param>
        public LibraryService(ILibraryServiceConfiguration configuration)
        {
            _baseUrl = configuration.BaseUrl;
            _endPoint = configuration.ServiceEndpoint;
        }
        public async Task<string> BorrowBook(Book book)
        {
  
            var client = new HttpClient();
            JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions();

            //JsonSerializerOptions.SetCamelCaseNamingPolicy() Extenstion method added
            var json = JsonSerializer.Serialize(book, JsonSerializerOptions.SetCamelCaseNamingPolicy());

            //Httpclient Extenstion method added
            var response = await client.PostAsyncResponse(json, _baseUrl, _endPoint);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }

            return await response.Content.ReadAsStringAsync();
        }
    }
}
