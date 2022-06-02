using Extensions.Hosting.AsyncInitialization;
using StockExchange.Api.Options;
using StockExchange.Data.Database;
using StockExchange.Domain.TickerAggregate;

namespace StockExchange.Api.Controllers.Infrastructure;

/// <summary>
/// Class <see cref="SeedInitializer"/>.
/// </summary>
internal class SeedInitializer : IAsyncInitializer
{
    private readonly StockExchangeDbContext _context;
    private readonly CustomTickersOptions _customTickersOptions;

    public SeedInitializer(StockExchangeDbContext context, CustomTickersOptions  customTickersOptions)
    {
        _context = context;
        _customTickersOptions = customTickersOptions;
    }

    public async Task InitializeAsync()
    {
       await  SeedTickerAsync();
    }
    /// <summary>
    /// Initialize Ticker data.
    /// </summary>
    private async Task<Task> SeedTickerAsync()
    {
        List<Ticker> tickersFromDB = _context.Tickers.ToList();
        List<CustomTickers> customTickers = _customTickersOptions.CustomTickers.ToList();
        List<Ticker> tickersToAdd=  new List<Ticker>();

        try
        {
            foreach (CustomTickers customTicker in customTickers)
            {
                if (tickersFromDB?.Where(x => x.Symbol == customTicker.Symbol)?.Count() == 0)
                {
                    tickersToAdd.Add(
                        new Ticker(customTicker.Symbol, customTicker.Name, customTicker.LastPrice));
                }
            }
            _context.Tickers.AddRange(tickersToAdd);
            await _context.SaveChangesAsync().ConfigureAwait(false);

        }
        catch (Exception)
        {
            _context.Dispose();
        }

        return Task.CompletedTask;
    }
}
