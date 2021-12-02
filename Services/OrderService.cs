using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using LoggerService;
using Services.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class OrderService : IOrderService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public OrderService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync(bool trackChanges)
        {
            var orders = await _repository.Order.GetAllOrdersAsync(trackChanges);
            var ordersDto = _mapper.Map<IEnumerable<OrderDto>>(orders);

            return ordersDto;
        }

        public async Task<OrderDto> GetOrderAsync(int orderId, bool trackChanges)
        {
            var order = await _repository.Order.GetOrderAsync(orderId, trackChanges);

            if (order is null)
                throw new OrderNotFoundException(orderId);

            var orderDto = _mapper.Map<OrderDto>(order);
            return orderDto;
        }

        public async Task<OrderDto> CreateOrderAsync(OrderForCreationDto order)
        {
            var orderEntity = _mapper.Map<Order>(order);
            _repository.Order.CreateOrder(orderEntity);
            await _repository.SaveAsync();

            var orderToReturn = _mapper.Map<OrderDto>(orderEntity);

            return orderToReturn;
        }

        public async Task<IEnumerable<OrderDto>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges)
        {
            if (ids is null)
                throw new IdParametersBadRequestException();

            var orderEntities = await _repository.Order.GetByIdsAsync(ids, trackChanges);
            if (ids.Count() != orderEntities.Count())
                throw new CollectionByIdsBadRequestException();

            var ordersToReturn = _mapper.Map<IEnumerable<OrderDto>>(orderEntities);

            return ordersToReturn;

        }

        //public async Task<(IEnumerable<OrderDto> orders, string ids)> CreateOrderCollectionAsync
        //    (IEnumerable<OrderForCreationDto> ordersCollection)
        //{
        //    if (ordersCollection is null)
        //        throw new OrderCollectionBadRequest();

        //    var orderEntities = _mapper.Map<IEnumerable<Order>>(ordersCollection);
        //    foreach (var order in orderEntities)
        //    {
        //        _repository.Order.CreateOrder(order);
        //    }

        //    await _repository.SaveAsync();

        //    var orderCollectionToReturn = _mapper.Map<IEnumerable<OrderDto>>(orderEntities);
        //    var ids = string.Join(",", orderCollectionToReturn.Select(c => c.OrderId));

        //    return (orders: orderCollectionToReturn, ids: ids);
        //}

        public async Task DeleteOrderAsync(int orderId, bool trackChanges)
        {
            var order = await _repository.Order.GetOrderAsync(orderId, trackChanges);
            if (order is null)
                throw new OrderNotFoundException(orderId);

            _repository.Order.DeleteOrder(order);
            await _repository.SaveAsync();
        }

        public async Task UpdateOrderAsync(int orderId, OrderForUpdateDto orderForUpdate, bool trackChanges)
        {
            var order = await _repository.Order.GetOrderAsync(orderId, trackChanges);
            if (order is null)
                throw new OrderNotFoundException(orderId);

            _mapper.Map(orderForUpdate, order);
            await _repository.SaveAsync();
        }
    }
}
