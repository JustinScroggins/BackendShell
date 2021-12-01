using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public OrderType OrderType { get; set; }
        public string CustomerName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserName { get; set; }
    }
}
