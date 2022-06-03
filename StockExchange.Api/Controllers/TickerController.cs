using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockExchange.Application.Tickers.FindTickerBySymbol;

namespace StockExchange.Api.Controllers;

/// <summary>
///Class <see cref="TickerController"/>
/// </summary>
[ApiController]
[Route("[controller]")]
public class TickerController
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Constructor of TickerController.
    /// </summary>
    /// <param name="mediator">mediator</param>
    /// <exception cref="ArgumentNullException">if mediator is null</exception>
    public TickerController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    /// <summary>
    /// Get Ticker by symbol.
    /// </summary>
    /// <param name="symbol">symbol</param>
    /// <param name="cancellationToken">ct</param>
    /// <returns>TickerDto</returns>
    [HttpGet("{symbol}")]
    public async Task<IActionResult> Get(string symbol, CancellationToken cancellationToken)
    {
        TickerDto? tickerDto = await _mediator.Send(new FindTickerBySymbolQuery(symbol), cancellationToken).ConfigureAwait(false);

        if (tickerDto == null)
        {
            return new NotFoundObjectResult(string.Format("The ticker with symbol '{0}' does not exist!", symbol));
        }
        return new OkObjectResult(tickerDto);
    }
}