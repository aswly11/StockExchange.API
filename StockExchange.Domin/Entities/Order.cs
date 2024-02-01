using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockExchange.Domain.Enums;

namespace StockExchange.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public OrderType Type { get; set; }
        public int StockId { get; set; }
        public  virtual Stock Stock { get; set; }

    }
}
