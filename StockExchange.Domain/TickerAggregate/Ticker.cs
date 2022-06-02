namespace StockExchange.Domain.TickerAggregate;

/// <summary>
/// Class <see cref="Ticker"/>
/// </summary>
public class Ticker
{
    /// <summary>
    /// Id.
    /// </summary>
    public long Id { get; }

    /// <summary>
    /// Symbol
    /// </summary>
    public string Symbol { get; }

    /// <summary>
    /// Company name.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Last Price.
    /// </summary>
    public decimal LastPrice { get; }

    /// <summary>
    /// Constructor of Ticker.
    /// </summary>
    /// <param name="symbol">symbol</param>
    /// <param name="name">name</param>
    /// <param name="lastPrice">last price</param>
    public Ticker(string symbol, string name, decimal lastPrice)
    {
        Symbol = symbol;
        Name = name;
        LastPrice = lastPrice;
    }
}