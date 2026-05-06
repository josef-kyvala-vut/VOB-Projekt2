using SteamDealsApp.Providers;
using SteamDealsApp.Logic;
using SteamDealsApp.UI;

Console.OutputEncoding = System.Text.Encoding.UTF8;

IDealProvider provider = new CheapSharkProvider();
DealAnalyzer analyzer = new DealAnalyzer();

ConsoleInterface ui = new ConsoleInterface(provider, analyzer);

await ui.RunAsync();