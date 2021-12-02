using Contracts;
using Entities;
using Moq;
using Presentation;
using Services.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using Xunit;

namespace BackendShell.Tests
{
    public class OrderControllerTests
    {

        [Fact]
        public void GetOrderAsync_ShouldReturnAllOrders()
        {
            // Arrange
            var mockServiceManager = new Mock<IServiceManager>();
            var mockOrderController = new Mock<OrderController>();

            // Act
            var result = mockOrderController.Setup(repo => repo.GetOrderAsync(1));

            // Assert
            //Assert.Equal(result, )
        }
    }
}
