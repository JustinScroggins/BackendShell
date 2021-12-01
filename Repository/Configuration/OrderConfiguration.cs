using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Repository.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData
                (
                    new Order
                    {
                        CustomerName = "Kroger",
                        OrderId = 1,
                        OrderType = OrderType.Standard,
                        CreatedDate = new DateTime(2020, 9, 30),
                        CreatedByUserName = "Matt"
                    },
                    new Order
                    {
                        CustomerName = "Target",
                        OrderId = 2,
                        OrderType = OrderType.PurchaseOrder,
                        CreatedDate = new DateTime(2020, 11, 1),
                        CreatedByUserName = "Shay"
                    },
                    new Order
                    {
                        CustomerName = "Walmart",
                        OrderId = 3,
                        OrderType = OrderType.ReturnOrder,
                        CreatedDate = new DateTime(2020, 10, 19),
                        CreatedByUserName = "David"
                    },
                    new Order
                    {
                        CustomerName = "Aldi",
                        OrderId = 4,
                        OrderType = OrderType.SaleOrder,
                        CreatedDate = new DateTime(2020, 5, 15),
                        CreatedByUserName = "Josh"
                    },
                    new Order
                    {
                        CustomerName = "Meijer",
                        OrderId = 5,
                        OrderType = OrderType.TransferOrder,
                        CreatedDate = new DateTime(2020, 12, 12),
                        CreatedByUserName = "Alex"
                    }
                );
        }
    }
}
