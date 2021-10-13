﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Shared
{
    public static class StringExtensions
    {
        public static HttpContent ToHttpContent<T>(this T obj)
        {
            var json = JsonSerializer.Serialize(obj, JsonSerializerOptions);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            return content;
        }

        private static readonly JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

    }
}
