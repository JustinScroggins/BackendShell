﻿using System;
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

        // Add a Create endpoint
        [HttpPost, Authorize(Roles = "User,Administrator")]
        public async Task<IActionResult> CreateOrderAsync([FromBody] OrderForCreationDto order)
        {
            if (order is null)
                return BadRequest("OrderForCreationDto object is null");

            var createdOrder = await _service.OrderService.CreateOrderAsync(order);

            return CreatedAtRoute("OrderById", new { id = createdOrder.OrderId }, createdOrder);
        }

        // Add a Delete endpoint
        [HttpDelete("{orderId}"), Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteOrderAsync(int orderId)
        {
            await _service.OrderService.DeleteOrderAsync(orderId, trackChanges: false);
            return NoContent();
        }

        // Delete a collection of orders
        [HttpDelete("collection/({ids})", Name = "OrderCollection"), Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteOrderCollectionAsync(IEnumerable<int> ids)
        {
            await _service.OrderService.DeleteOrderCollectionAsync(ids, trackChanges: false);
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