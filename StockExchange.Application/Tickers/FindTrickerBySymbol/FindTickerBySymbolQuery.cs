using MediatR;

namespace StockExchange.Application.Tickers.FindTickerBySymbol;

/// <summary>
/// Class <see cref="FindTickerBySymbolQuery"/>.
/// </summary>
public class FindTickerBySymbolQuery : IRequest<TickerDto?>
{
    /// <summary>
    /// Symbol of Ticker
    /// </summary>
    public string Symbol { get; }

    /// <summary>
    /// Constructor of FindTickerBySymbolQuery.
    /// </summary>
    /// <param name="symbol">symbol of ticker</param>
    public FindTickerBySymbolQuery(string symbol)
    {
        Symbol = symbol;
    }
}