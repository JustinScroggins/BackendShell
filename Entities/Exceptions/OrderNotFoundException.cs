using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Exceptions
{
    public sealed class OrderNotFoundException : NotFoundException
    {
        public OrderNotFoundException(int orderId)
        : base($"The order with id: {orderId} doesn't exist in the database.")
        {
        }
    }
}
