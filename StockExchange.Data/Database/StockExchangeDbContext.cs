using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StockExchange.Data.Domain.Tickers;
using StockExchange.Domain.TickerAggregate;

namespace StockExchange.Data.Database;

public class StockExchangeDbContext : DbContext
{
    public const string DEFAULTSCHEMA = "StackEx";

    private readonly string _schema;

    /// <summary>
    /// DbSet Settings.
    /// </summary>
    public DbSet<Ticker> Tickers { get; set; }

    /// <summary>
    /// Le filtre automatique sur les entités supprimées logiquement est-il actif ?
    /// </summary>
    public bool IsDeletedQueryFilterEnabled { get; }

    public StockExchangeDbContext(DbContextOptions options ) : base(options)
    {
 
    }

 

    ///<inheritdoc/>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema(_schema);

        new TickerEntityTypeConfiguration().Configure(builder.Entity<Ticker>());

        base.OnModelCreating(builder);


    }


   
}