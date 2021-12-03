using Entities;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllOrdersAsync(bool trackChanges);
        Task<OrderDto> GetOrderAsync(int orderId, bool trackChanges);
        Task<OrderDto> CreateOrderAsync(OrderForCreationDto order);

        Task DeleteOrderCollectionAsync(IEnumerable<int> ids, bool trackChanges);

        Task DeleteOrderAsync(int orderId, bool trackChanges);

        Task UpdateOrderAsync(int orderId, OrderForUpdateDto order, bool trackChanges);
    }
}
