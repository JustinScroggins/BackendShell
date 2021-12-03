using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(c => c.OrderId)
                .ToListAsync();

        public async Task<Order> GetOrderAsync(int orderId, bool trackChanges) =>
            await FindByCondition(c => c.OrderId.Equals(orderId), trackChanges)
            .SingleOrDefaultAsync();

        public void CreateOrder(Order order)
        {
            order.CreatedDate = DateTime.Now;
            Create(order);
        }

        public void DeleteOrder(Order order) => Delete(order);

        public void DeleteOrderCollectionAsync(IEnumerable<int> ids) => DeleteOrderCollectionAsync(ids);
    }
}
