using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Domain.Entities
{
    public class Stock
    {
        public int Id { get; private set; }
        public string Symbol { get; private set; }
        public double Price { get; private set; }
        public DateTime LastUpdate { get; set; }
    }
}
