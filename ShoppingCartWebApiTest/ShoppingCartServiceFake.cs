using System;
using System.Collections.Generic;
using System.Linq;
using web_api.Contracts;
using web_api.Model;

namespace WebApiTest
{
    class ShoppingCartServiceFake : IShoppingCartService
    {
        private readonly List<CartItem> _shoppingCart;

        public ShoppingCartServiceFake()
        {
            Product _testProduct1 = new Product() { Id = 999999, Title = "TestProduct", Description = "This is a test product. Not from catalogue", Price = 10.00M };
            Product _testProduct2 = new Product() { Id = 999999, Title = "TestProduct", Description = "This is a test product. Not from catalogue", Price = 20.00M };

            _shoppingCart = new List<CartItem>()
            {
                new CartItem() { Id = 1, product = _testProduct1 , Number=1, Price = 10.00M },
                new CartItem() { Id = 2, product = _testProduct2 , Number=1, Price = 20.00M },
            };
        }

        public IEnumerable<CartItem> GetAllItems()
        {
            return _shoppingCart;
        }

        public CartItem Add(CartItem newItem)
        {
            newItem.Id = 1;
            _shoppingCart.Add(newItem);
            return newItem;
        }

        public CartItem GetById(int id)
        {
            return _shoppingCart.Where(a => a.Id == id)
                .FirstOrDefault();
        }

        public void Remove(int id)
        {
            var existing = _shoppingCart.First(a => a.Id == id);
            _shoppingCart.Remove(existing);
        }
    }
}
