namespace StockExchange.Domain.TickerAggregate;

/// <summary>
/// Interface <see cref="ITickerRepository"/> containing methods of Ticker.
/// </summary>
public interface ITickerRepository
{
    /// <summary>
    /// Get Ticker By Symbol.
    /// </summary>
    /// <param name="symbol">symbol</param>
    /// <param name="cancellationToken">ct</param>
    /// <returns>Ticker</returns>
    Task<Ticker?> GetTickerBySymbolAsync(string symbol, CancellationToken cancellationToken);
}