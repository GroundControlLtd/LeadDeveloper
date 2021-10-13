using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Shared;

namespace Interview
{
    public class GarageService : IGarageService
    {
        public static JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        public async Task<string> BookMot(Car car)
        {
            using var client = new HttpClient { BaseAddress = new Uri("https://localhost:44321") };

            var response = await client.PostAsync("/api/garage/bookmot", car.ToHttpContent());
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }

            return await response.Content.ReadAsStringAsync();
        }
    }
}
