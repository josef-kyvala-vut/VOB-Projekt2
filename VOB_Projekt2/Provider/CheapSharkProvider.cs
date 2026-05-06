using System.Net.Http.Json;
using SteamDealsApp.Models;

namespace SteamDealsApp.Providers
{
    public class CheapSharkProvider : IDealProvider
    {
        private readonly HttpClient _httpClient;

        public CheapSharkProvider()
        {
            _httpClient = new HttpClient();

            _httpClient.DefaultRequestHeaders.Add("User-Agent", "SteamDealsStudentApp/1.0");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<List<GameDeal>> GetTopDealsAsync()
        {
            string url = "https://www.cheapshark.com/api/1.0/deals?storeID=1";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                string errorDetails = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Server vrátil chybu {response.StatusCode}. Detaily: {errorDetails}");
            }

            var deals = await response.Content.ReadFromJsonAsync<List<GameDeal>>();

            if (deals == null) return new List<GameDeal>();

            return deals.Take(30).ToList();
        }
    }
}