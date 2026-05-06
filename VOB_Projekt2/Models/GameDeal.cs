using System.Text.Json.Serialization;

namespace SteamDealsApp.Models
{
    public class GameDeal
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("salePrice")]
        public string SalePrice { get; set; }

        [JsonPropertyName("normalPrice")]
        public string NormalPrice { get; set; }

        [JsonPropertyName("steamRatingPercent")]
        public string SteamRatingPercent { get; set; }
    }
}