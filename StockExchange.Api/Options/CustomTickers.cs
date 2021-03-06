namespace StockExchange.Api.Options;

/// <summary>
/// Class <see cref="CustomTickers"/>
/// </summary>
[Serializable]
public class CustomTickers
{    /// <summary>
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