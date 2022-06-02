namespace StockExchange.Domain.TickerAggregate;
public class Ticker
{
    public long Id { get;  }
    public string Symbol { get; }

    public string Name { get; }

    public decimal LastPrice { get; }

    public Ticker( string symbol, string name, decimal lastPrice)
    {
        Symbol =symbol;
        Name = name;
        LastPrice=lastPrice;
    }
}
