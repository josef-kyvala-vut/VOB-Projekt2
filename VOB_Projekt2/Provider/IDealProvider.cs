using SteamDealsApp.Models;

namespace SteamDealsApp.Providers
{
    public interface IDealProvider
    {
        Task<List<GameDeal>> GetTopDealsAsync();
    }
}