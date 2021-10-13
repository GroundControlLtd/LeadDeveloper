using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Interview.Extenstions;
using Interview.Interfaces;
using Shared;

namespace Interview
{
    public class GarageService: IGarageService
    {
        private readonly string _baseUrl;
        private readonly string _endPoint;

        /// <summary>
        /// Dependency injection for configuration keys
        /// </summary>
        /// <param name="configuration"></param>
        public GarageService(IGarageServiceConfiguration configuration)
        {
            _baseUrl = configuration.BaseUrl;
            _endPoint = configuration.ServiceEndpoint;
        }
        public async Task<string> BookMot(Car car)
        {
            var client = new HttpClient();
            JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions();

            //JsonSerializerOptions.SetCamelCaseNamingPolicy() Extenstion method added
            var json = JsonSerializer.Serialize(car, JsonSerializerOptions.SetCamelCaseNamingPolicy());

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
