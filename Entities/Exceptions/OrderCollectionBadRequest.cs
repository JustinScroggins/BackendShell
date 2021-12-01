using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Exceptions
{
    public sealed class OrderCollectionBadRequest : BadRequestException
    {
        public OrderCollectionBadRequest()
            :base("Order collection sent from the client is null")
        {
        }
    }
}
