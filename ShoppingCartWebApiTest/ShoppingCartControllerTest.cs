using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using web_api.Controllers;
using web_api.Model;
using web_api.Contracts;
using System.Linq;

namespace WebApiTest
{
    public class ShoppingCartControllerTest
    {
        ShoppingCartController _controller;
        IShoppingCartService _service;

        public ShoppingCartControllerTest()
        {
            _service = new ShoppingCartServiceFake();
            _controller = new ShoppingCartController(_service);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.Get().Result as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<CartItem>>(okResult.Value);
            Assert.Equal(2, items.Count);
        }

        [Fact]
        public void GetById_UnknownIntPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.Get(99999999);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void GetById_ExistingIntPassed_ReturnsOkResult()
        {
            // Arrange
            var testInt = 1;

            // Act
            var okResult = _controller.Get(testInt);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetById_ExistingIntPassed_ReturnsRightItem()
        {
            // Arrange
            var testInt = 1;

            // Act
            var okResult = _controller.Get(testInt).Result as OkObjectResult;

            // Assert
            Assert.IsType<CartItem>(okResult.Value);
            Assert.Equal(testInt, (okResult.Value as CartItem).Id);
        }

        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var nameMissingItem = new CartItem()
            {
                Number = 1,
                Price = 12.00M
            };
            _controller.ModelState.AddModelError("Amount", "Required");

            // Act
            var badResponse = _controller.Post(nameMissingItem);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }


        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            CartItem testItem = new CartItem()
            {
                Id = 1,
                Number = 1,
                Price = 12.00M
            };

            // Act
            var createdResponse = _controller.Post(testItem);

            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }


        [Fact]
        public void Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            var testItem = new CartItem()
            {
                Number = 1,
                Price = 12.00M
            };

            // Act
            var createdResponse = _controller.Post(testItem) as CreatedAtActionResult;
            var item = createdResponse.Value as CartItem;

            // Assert
            Assert.IsType<CartItem>(item);
            Assert.Equal(12.00M, item.Price);
        }

        [Fact]
        public void Remove_NotExistingIntPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            int notExistingInt = 999999999;
        
            // Act
            var badResponse = _controller.Remove(notExistingInt);

            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public void Remove_ExistingIntPassed_ReturnsOkResult()
        {
            // Arrange
            var existingInt = 1;

            // Act
            var okResponse = _controller.Remove(existingInt);

            // Assert
            Assert.IsType<OkResult>(okResponse);
        }

        [Fact]
        public void Remove_ExistingIntPassed_RemovesOneItem()
        {
            // Arrange
            var existingInt = 1;

            // Act
            var okResponse = _controller.Remove(existingInt);

            // Assert
            Assert.DoesNotContain(_service.GetAllItems(), c => c.Id == 1);
        }
    }
}
