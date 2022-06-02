using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StockExchange.Data.Database;
using StockExchange.Domain.TickerAggregate;

namespace StockExchange.Data.Domain.Tickers
{
    public class TickerRepository : ITickerRepository
    {
        private readonly StockExchangeDbContext _stockExchangeDbContext;

        public TickerRepository(StockExchangeDbContext stockExchangeDbContext)
        {
            _stockExchangeDbContext = stockExchangeDbContext;
        }

        public StockExchangeDbContext Get_stockExchangeDbContext()
        {
            return _stockExchangeDbContext;
        }

        public async Task<Ticker?> GetTickerBySymbolAsync(string symbol,  CancellationToken cancellationToken, Guid? tenantId = null)
        {
            try
            {
                Ticker? ticker = await _stockExchangeDbContext.Tickers?.Where(t => t.Symbol.ToLower().Trim() == symbol.ToLower().Trim())?.FirstOrDefaultAsync();
                return ticker;
            }
            catch (Exception ee)
            {

                throw;
            }
            return null;
        }
    }
}