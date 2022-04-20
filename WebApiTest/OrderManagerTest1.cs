using Moq;
using NUnit.Framework;
using OrderManager.Controllers;
using OrderManager.Data;
using OrderManager.Models;
using OrderManager.Service;
using OrderManager.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiTest
{
    public class ManagerControllerTests
    {
        private readonly Mock<IUnitOfWork> _uow = new Mock<IUnitOfWork>();
        private readonly Mock<IQueries> _queriesrepo = new Mock<IQueries>();
        private readonly ManagerController _sut;

        public ManagerControllerTests()
        {
            _sut = new ManagerController(_uow.Object);
        }

        [Test]
        public async Task GetTaskAsync_ShouldReturnCustomer_WhenCustomerExists()
        {
            var itemDto = new Item
            {
                ItemId = 1,
                ProductId = 1,
                Quantity = 10,
                ProductName = "",
                OrderId = 1
            };

            var orderDto = new Order
            {
                OrderId = 1,
                Date = DateTime.Now,
                TotalPrice = 10,
                Items = new[] { itemDto },
                CustomerId = 1
            };

            //Arrange
            var orderId = 1;
            _queriesrepo.Setup(x => x.GetOrderByIdAsync(orderId))
                .ReturnsAsync(orderDto);
            //Act
            var order = await _sut.GetOrderById(orderId);
            //Assert
            Assert.Equals(orderId, order.Value.OrderId);
        }
    }
}