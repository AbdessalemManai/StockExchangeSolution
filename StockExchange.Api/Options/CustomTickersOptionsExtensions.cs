 
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockExchange.Api.Options;
using System;

namespace HubOne.Fundamentals.Identity.API.Extensions
{
    internal static class CustomTickersOptionsExtensions
    {
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
}