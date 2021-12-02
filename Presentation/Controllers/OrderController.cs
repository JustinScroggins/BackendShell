using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using LoggerService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Shared.DataTransferObjects;

namespace Presentation
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IServiceManager _service;

        public OrderController(IServiceManager service) => _service = service;

        [HttpGet, Authorize(Roles = "User,Administrator")]
        public async Task<IActionResult> GetOrdersAsync()
        {
            var orders = await _service.OrderService.GetAllOrdersAsync(trackChanges: false);

            return Ok(orders);
        }

        // Add a Search endpoint
        [HttpGet("{id}", Name = "OrderById"), Authorize(Roles = "User,Administrator")]
        public async Task<IActionResult> GetOrderAsync(int id)
        {
            var order = await _service.OrderService.GetOrderAsync(id, trackChanges: false);
            return Ok(order);
        }

        // Search for Collection by multiple ID's
        [HttpGet("collection", Name = "OrderCollection"), Authorize(Roles = "User,Administrator")]
        public async Task<IActionResult>GetOrderCollectionAsync(List<int> ids)
        {
            var orders = await _service.OrderService.GetByIdsAsync(ids, trackChanges: false);
            return Ok(orders);
        }

        // Add a Create endpoint
        [HttpPost, Authorize(Roles = "User,Administrator")]
        public async Task<IActionResult> CreateOrderAsync([FromBody] OrderForCreationDto order)
        {
            if (order is null)
                return BadRequest("OrderForCreationDto object is null");

            var createdOrder = await _service.OrderService.CreateOrderAsync(order);

            return CreatedAtRoute("OrderById", new { id = createdOrder.OrderId }, createdOrder);
        }

        [HttpPost("collection"), Authorize(Roles = "User,Administrator")]
        public async Task<IActionResult> CreateOrderCollection([FromBody] IEnumerable<OrderForCreationDto> orderCollection)
        {
            var result = await _service.OrderService.CreateOrderCollectionAsync(orderCollection);
            return CreatedAtRoute("OrderCollection", new { result.ids }, result.orders);
        }

        // Add a Delete endpoint
        [HttpDelete("{orderId}"), Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteOrderAsync(int orderId)
        {
            await _service.OrderService.DeleteOrderAsync(orderId, trackChanges: false);
            return NoContent();
        }

        //Edit an order
        [HttpPut("{orderId}"), Authorize(Roles = "Administrator")]
        public async Task<IActionResult> UpdateOrderAsync(int orderId, [FromBody] OrderForUpdateDto order)
        {
            if (order is null)
                return BadRequest("OrderForUpdateDto object is null");

            await _service.OrderService.UpdateOrderAsync(orderId, order, trackChanges: true);

            return NoContent();
        }
    }
}