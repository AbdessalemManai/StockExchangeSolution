using Microsoft.EntityFrameworkCore;
using StockExchange.Data.Database;
using StockExchange.Domain.TickerAggregate;

namespace StockExchange.Data.Domain.Tickers
{
    /// <inheritdoc/>
    public class TickerRepository : ITickerRepository
    {
        private readonly StockExchangeDbContext _stockExchangeDbContext;

        /// <summary>
        /// Constructor of TickerRepository.
        /// </summary>
        /// <param name="stockExchangeDbContext">constext of TickerRepository</param>
        /// <exception cref="ArgumentNullException">if <paramref name="stockExchangeDbContext"/> is null</exception>
        public TickerRepository(StockExchangeDbContext stockExchangeDbContext)
        {
            _stockExchangeDbContext = stockExchangeDbContext ?? throw new ArgumentNullException(nameof(stockExchangeDbContext));
        }

        /// <inheritdoc/>
        public async Task<Ticker?> GetTickerBySymbolAsync(string symbol, CancellationToken cancellationToken)
        {
            Ticker? ticker = await _stockExchangeDbContext.Tickers?.Where(t => t.Symbol.ToLower().Trim() == symbol.ToLower().Trim())?.FirstOrDefaultAsync();
            return ticker;
        }
    }
}