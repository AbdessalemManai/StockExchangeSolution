 
using MediatR;
using StockExchange.Domain.TickerAggregate;
using System.Net;

namespace StockExchange.Application.Tickers.FindTrickerBySymbol;

/// <summary>
/// Classe <see cref="CheckFirstLoginMobileHandler"/> de vérification de première authentification utilisateur.
/// </summary>
public class FindTickerBySymbolHandler : IRequestHandler<FindTickerBySymbolQuery, TrickerDto?>
{
 
    public ITickerRepository _tickerRepository { get; }

    public FindTickerBySymbolHandler(ITickerRepository tickerRepository)
    {
        _tickerRepository = tickerRepository ?? throw new ArgumentNullException(nameof(tickerRepository));
    }

    public async Task<TrickerDto?> Handle(FindTickerBySymbolQuery request, CancellationToken cancellationToken)
    {
        TrickerDto trickerDto = null;
        Ticker ticker= await _tickerRepository.GetTickerBySymbolAsync(request.Symbol,cancellationToken).ConfigureAwait(false);

        if(ticker != null)
        {
            trickerDto = new TrickerDto();
            trickerDto.Symbol= ticker.Symbol;
            trickerDto.Name= ticker.Name;
            trickerDto.LastPrice= ticker.LastPrice;
        }
        return  trickerDto;
    }
}