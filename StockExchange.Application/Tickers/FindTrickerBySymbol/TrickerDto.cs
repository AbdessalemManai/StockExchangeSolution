using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Application.Tickers.FindTrickerBySymbol
{
    public class TrickerDto
    {
        public string Symbol { get; set; }

        public string Name { get; set; }

        public decimal LastPrice { get; set; }
    }
}
