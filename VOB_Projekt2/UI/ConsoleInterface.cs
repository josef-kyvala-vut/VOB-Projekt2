using SteamDealsApp.Providers;
using SteamDealsApp.Logic;
using SteamDealsApp.Models;

namespace SteamDealsApp.UI
{
    public class ConsoleInterface
    {
        private readonly IDealProvider _provider;
        private readonly DealAnalyzer _analyzer;

        public ConsoleInterface(IDealProvider provider, DealAnalyzer analyzer)
        {
            _provider = provider;
            _analyzer = analyzer;
        }

        public async Task RunAsync()
        {
            Console.WriteLine("Stahuji 30 nejvyhodnejsich slev na Steamu...\n");

            try
            {
                var topDeals = await _provider.GetTopDealsAsync();
                var sortedDeals = _analyzer.SortByBestRating(topDeals);
                var freeGames = _analyzer.GetFreeGames(topDeals);

                PrintFreeGames(freeGames);
                PrintDeals(sortedDeals);
            }
            catch (HttpRequestException ex)
            {
                PrintError($"Chyba u stahovani dat: ({ex.Message})");
            }
            catch (Exception ex)
            {
                PrintError($"Neocekavana chyba: {ex.Message}");
            }

            Console.WriteLine("\nStisknete klavesu pro ukonceni...");
            Console.ReadKey();
        }

        private void PrintFreeGames(List<GameDeal> freeGames)
        {
            if (!freeGames.Any())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("Na Steamu neni hra zdarma");
                Console.WriteLine("-------------------------------------------------\n");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("! HRY ZDARMA !");
            foreach (var freeGame in freeGames)
            {
                Console.WriteLine($"- {freeGame.Title} (Puvodni: {freeGame.NormalPrice} €)");
            }
            Console.WriteLine("-------------------------------------------------\n");
            Console.ResetColor();

        }

        private void PrintDeals(List<GameDeal> deals)
        {
            Console.WriteLine("Nejvyhodnejsi slevy serazene podle Steam hodnoceni [%]");
            foreach (var deal in deals)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("  -");
                Console.ResetColor();
                Console.WriteLine($"[{deal.SteamRatingPercent}%] - {deal.Title} - Cena: {deal.SalePrice} € (Puvodni: {deal.NormalPrice} €)");
            }
        }

        private void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}