using Contracts;
using Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Tests;

public class OrderControllerTests
{
    [Fact]
    public async void GetAllOrdersAsync_ReturnsListOfOrders_WithASingleOrder()
    {
        //Arrange
        var mockRepo = new Mock<IOrderRepository>();
        mockRepo.Setup(repo => (repo.GetAllOrdersAsync(false)))
            .Returns(Task.FromResult(GetOrders()));

        // Act
        var result = mockRepo.Object.GetAllOrdersAsync(false)
            .GetAwaiter().GetResult().ToList();

        // Assert 
        Assert.IsType<List<Order>>(result);
        Assert.Single(result);
    }

    [Fact]
    public async void DeleteOrder_ShouldRemoveOrderFromRepository()
    {
        // Arrange
        var mockRepo = new Mock<IOrderRepository>();
        mockRepo.Setup(repo => (repo.GetAllOrdersAsync(false)))
            .Returns(Task.FromResult(GetOrders()));
        var order = GetOrders().FirstOrDefault();
        

        // Act
        mockRepo.Object.DeleteOrder(order);

        // Assert
        Assert.NotSame(mockRepo, order);
        
    }

    [Fact]
    public async void GetSingleOrder_ShouldReturnCorrectOrder() 
    {
        // Arrange
        var mockRepo = new Mock<IOrderRepository>();
        mockRepo.Setup(repo => (repo.GetAllOrdersAsync(false)))
            .Returns(Task.FromResult(GetOrders()));

        // Act
    }

    public IEnumerable<Order> GetOrders()
    {
        return new List<Order>
            {
                new Order
                {
                    OrderId = 1,
                    CreatedByUserName = "Justin Scroggins",
                    CreatedDate = new DateTime(2021, 10, 8),
                    CustomerName = "Walgreens",
                    OrderType = OrderType.Standard
                }
            };
    }
}