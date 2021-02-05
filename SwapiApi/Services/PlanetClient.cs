using SwapiApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SwapiApi.Services
{
    public class PlanetClient : IPlanetClient
    {
        private readonly HttpClient _httpClient;

        public PlanetClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<PlanetResponse> GetPlanetInfo()
        {
            var results = await _httpClient.GetAsync("planets/?page=1");
            if (results.IsSuccessStatusCode)
            {
                var stringContent = await results.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                var obj = JsonSerializer.Deserialize<PlanetResponse>(stringContent, options);
                return obj;
            }

            else
            {
                throw new HttpRequestException("nothing here");
            }

        }

        public async Task<PlanetResponse> GetPlanetInfo(string url)
        {
            var results = await _httpClient.GetAsync(url);

            if (results.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase

                };
                var stringContent = await results.Content.ReadAsStringAsync();
                var obj = JsonSerializer.Deserialize<PlanetResponse>(stringContent, options);
                return obj;
            }
            else
            {
                throw new HttpRequestException("nothing here");
            }
        
        }
    }
}
