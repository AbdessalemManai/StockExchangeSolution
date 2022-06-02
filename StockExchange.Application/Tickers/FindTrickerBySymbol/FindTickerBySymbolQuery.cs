using MediatR;


namespace StockExchange.Application.Tickers.FindTrickerBySymbol;
 
public class FindTickerBySymbolQuery : IRequest<TrickerDto?>
{
 
    public string Symbol { get; }
 
    public FindTickerBySymbolQuery(string symbol)
    {
        Symbol = symbol;
    }
}