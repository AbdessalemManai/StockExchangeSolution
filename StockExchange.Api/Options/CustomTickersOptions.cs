using System;

namespace StockExchange.Api.Options;

[Serializable]
public class CustomTickersOptions
{
    public static readonly string ConfigurationPropertyName = "CustomTickers";

    /// <summary>
    /// Liste des claims personnalisées acceptées.
    /// </summary>
    public CustomTickers[] CustomTickers { get; set; }
}
