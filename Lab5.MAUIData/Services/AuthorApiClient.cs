using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5.MAUIData.Interfaces;
using Lab5.MAUIData.Models;
using Newtonsoft.Json;

namespace Lab5.MAUIData.Services
{
    public class AuthorApiClient : IAuthorApiClient
    {
        private readonly HttpClient _httpClient;

        public static string BaseAddress =
            DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5205" : "http://localhost:5136";

        public AuthorApiClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<T[]> GetItemsAsync<T>(string url) where T : class
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{BaseAddress}/{url}");
            var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var items = JsonConvert.DeserializeObject<T[]>(json);

            return items;
        }

        public async Task DeleteItemAsync(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"{BaseAddress}/{url}");
            var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateItem<T>(string url, T entity) where T : class
        {
            var request = new HttpRequestMessage(HttpMethod.Put, $"{BaseAddress}/{url}");

            var content = new StringContent(JsonConvert.SerializeObject(entity), null, "application/json");

            request.Content = content;

            var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();
        }
    }
}
