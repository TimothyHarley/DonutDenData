using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonutDenData.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string SpecialRequest { get; set; }
    }
}
