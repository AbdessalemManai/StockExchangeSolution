using System;

namespace StockExchange.Api.Options;

/// <summary>
/// Classe <see cref="CustomTickersOptions"/>.
/// </summary>
[Serializable]
public class CustomTickersOptions
{
    /// <summary>
    /// Property name.
    /// </summary>
    public static readonly string ConfigurationPropertyName = "CustomTickers";

    /// <summary>
    /// List of CustomTickers.
    /// </summary>
    public CustomTickers[] CustomTickers { get; set; }
}
