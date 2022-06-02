namespace StockExchange.Api.Options;

[Serializable]
public class CustomTickers
{
    public string Symbol { get; set; }

    public string Name { get; set; }

    public decimal LastPrice { get; set; }
}