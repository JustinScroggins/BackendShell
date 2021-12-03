using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataTransferObjects
{
    public class OrderForUpdateDto
    {
        public string CustomerName { get; set; }
        public string CreatedByUserName { get; set; }
        public OrderType OrderType { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
