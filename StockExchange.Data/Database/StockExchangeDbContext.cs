using Microsoft.EntityFrameworkCore;
using StockExchange.Data.Domain.Tickers;
using StockExchange.Domain.TickerAggregate;

namespace StockExchange.Data.Database;

/// <summary>
/// Class <see cref="StockExchangeDbContext"/>.
/// </summary>
public class StockExchangeDbContext : DbContext
{
    /// <summary>
    /// Default Schema.
    /// </summary>
    public const string DEFAULTSCHEMA = "StackEx";

    private readonly string _schema;

    /// <summary>
    /// DbSet Tickers.
    /// </summary>
    public DbSet<Ticker> Tickers { get; set; }

    /// <summary>
    /// Constructor of StockExchangeDbContext.
    /// </summary>
    /// <param name="options"></param>
    public StockExchangeDbContext(DbContextOptions options) : base(options)
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