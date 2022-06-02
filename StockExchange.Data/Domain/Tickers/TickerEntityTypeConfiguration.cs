using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockExchange.Domain.TickerAggregate;

namespace StockExchange.Data.Domain.Tickers
{
    /// <summary>
    /// classe <see cref="SettingEntityTypeConfiguration"/> Configurations de la table Setting.
    /// </summary>
    public class TickerEntityTypeConfiguration : IEntityTypeConfiguration<Ticker>
    {



        public void Configure(EntityTypeBuilder<Ticker> builder)
        {
            builder.ToTable("Tickers");
            builder.Property(p => p.Symbol);
            builder.HasIndex(b => new { b.Symbol }).IsUnique();
            builder.Property(p => p.LastPrice);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name);
        }
    }
}