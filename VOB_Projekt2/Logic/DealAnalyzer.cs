using SteamDealsApp.Models;

namespace SteamDealsApp.Logic
{
    public class DealAnalyzer
    {
        public List<GameDeal> SortByBestRating(List<GameDeal> deals)
        {
            return deals
                .OrderByDescending(d => int.TryParse(d.SteamRatingPercent, out int rating) ? rating : 0)
                .ToList();
        }

        public List<GameDeal> GetFreeGames(List<GameDeal> deals)
        {
            return deals
                .Where(d => decimal.TryParse(d.SalePrice, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal price) && price == 0)
                .ToList();
        }
    }
}