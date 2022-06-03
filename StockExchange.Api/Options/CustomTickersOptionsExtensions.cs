 
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockExchange.Api.Options;
using System;

namespace StockExchange.Api.Options;

/// <summary>
/// Class <see cref="CustomTickersOptionsExtensions"/> of CustomTickers Options.
/// </summary>
internal static class CustomTickersOptionsExtensions
{
    /// <summary>
    /// Get settings from json file and map to class.
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="configuration">configuration</param>
    /// <returns>services</returns>
    /// <exception cref="ArgumentNullException">id configuration is null</exception>
    internal static IServiceCollection AddCustomTickersOptions(this IServiceCollection services, IConfiguration configuration)
    {
        if (configuration == null)
        {
            throw new ArgumentNullException(nameof(configuration));
        }

        var options = new CustomTickersOptions
        {
            CustomTickers = configuration.GetSection(CustomTickersOptions.ConfigurationPropertyName)?.Get<CustomTickers[]>()
        };
        services.AddSingleton(options);

        return services;
    }
}
