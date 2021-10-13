using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Interview.Extenstions
{
    public static class Extensions
    {
        public static JsonSerializerOptions SetCamelCaseNamingPolicy(this JsonSerializerOptions jsonSerializerOptions)
        {
            jsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            return jsonSerializerOptions;
        }
        public static async Task<HttpResponseMessage> PostAsyncResponse(this HttpClient client, string json, string baseurl, string endpoint)
        {
            try
            {
                client.BaseAddress = new Uri(baseurl);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(endpoint, content);
                return response;
            }
            catch(Exception ex)
            {
                //todo log exception
               return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}
