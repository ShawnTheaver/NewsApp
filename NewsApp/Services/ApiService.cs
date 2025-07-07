using NewsApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace NewsApp.Services
{
    public class ApiService
    {
        private readonly string apiKey = "460746bc85e2431000a38f19ef3e48d5";

        public async Task<Root> GetNews(string categoryName)
        {
            try
            {
                var httpClient = new HttpClient();
                var url = $"https://gnews.io/api/v4/top-headlines?category={categoryName.ToLower()}&lang=en&token={apiKey}";
                var response = await httpClient.GetStringAsync(url);
                return JsonConvert.DeserializeObject<Root>(response);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"API error: {ex.Message}");
                return new Root { Articles = new List<Article>() };
            }
        }
    }
}
