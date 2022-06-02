using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Domain.TickerAggregate
{
    public interface ITickerRepository
    {

        Task<Ticker?> GetTickerBySymbolAsync(string symbol, CancellationToken cancellationToken, Guid? tenantId = null);

    }
}
