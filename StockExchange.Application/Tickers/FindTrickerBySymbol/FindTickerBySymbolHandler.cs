 
using MediatR;
using StockExchange.Domain.TickerAggregate;
using System.Net;

namespace StockExchange.Application.Tickers.FindTickerBySymbol;

/// <summary>
/// Class <see cref="FindTickerBySymbolHandler"/> finding Ticker by Symbol.
/// </summary>
public class FindTickerBySymbolHandler : IRequestHandler<FindTickerBySymbolQuery, TickerDto?>
{

    /// <summary>
    /// Gets the ITickerRepository.
    /// </summary>
    public ITickerRepository _tickerRepository { get; }

    /// <summary>
    /// Constructor of FindTickerBySymbolHandler.
    /// </summary>
    /// <param name="tickerRepository">tickerRepository</param>
    /// <exception cref="ArgumentNullException">if <paramref name="FindTickerBySymbolHandler"/> is null</exception>
    public FindTickerBySymbolHandler(ITickerRepository tickerRepository)
    {
        _tickerRepository = tickerRepository ?? throw new ArgumentNullException(nameof(tickerRepository));
    }

    public async Task<TickerDto?> Handle(FindTickerBySymbolQuery request, CancellationToken cancellationToken)
    {
        TickerDto tickerDto = null;
        Ticker ticker= await _tickerRepository.GetTickerBySymbolAsync(request.Symbol,cancellationToken).ConfigureAwait(false);

        if(ticker != null)
        {
            tickerDto = new TickerDto();
            tickerDto.Symbol= ticker.Symbol;
            tickerDto.Name= ticker.Name;
            tickerDto.LastPrice= ticker.LastPrice;
        }
        return  tickerDto;
    }
}