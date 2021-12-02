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
        Task<IEnumerable<OrderDto>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges);
        // Accepts a collection of the CreateForCreationDto as a parameter and return a tuple with two fields 
        // (orders and ids) as a result
        //Task<(IEnumerable<OrderDto> orders, string ids)> CreateOrderCollectionAsync
        //    (IEnumerable<OrderForCreationDto> orderCollection);

        Task DeleteOrderAsync(int orderId, bool trackChanges);

        Task UpdateOrderAsync(int orderId, OrderForUpdateDto order, bool trackChanges);
    }
}
