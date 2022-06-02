namespace StockExchange.Application.Tickers.FindTickerBySymbol;

/// <summary>
/// Classe <see cref="TickerDto"/>.
/// </summary>
public class TickerDto
{
    /// <summary>
    /// Symbol
    /// </summary>
    public string Symbol { get; set; }

    /// <summary>
    /// Company name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Last Price.
    /// </summary>
    public decimal LastPrice { get; set; }
}