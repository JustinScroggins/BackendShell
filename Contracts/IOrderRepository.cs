using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync(bool trackChanges);
        Task<Order> GetOrderAsync(int orderId, bool trackChanges);
        void CreateOrder(Order order);
        Task<IEnumerable<Order>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges);
        void DeleteOrder(Order order);
    }
}
