using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockExchange.Application.Tickers.FindTrickerBySymbol;

namespace StockExchange.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TickerController
    {
        private readonly IMediator _mediator;

        public TickerController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("{symbol}")]
        public async Task<IActionResult> Get(string symbol, CancellationToken cancellationToken)
        {
            Task<TrickerDto?> trickerDto = _mediator.Send(new FindTickerBySymbolQuery(symbol), cancellationToken);

            if (trickerDto.Result == null)
            {
                return new NotFoundObjectResult(string.Format("The ticker with symbol '{0}' does not exist!", symbol));
            }
            return new OkObjectResult(trickerDto.Result);
        }
    }
}