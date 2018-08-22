using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingCartWebApi.Contracts;
using ShoppingCartWebApi.Models;

namespace WebApiTest
{
    class ShoppingCartServiceFake : IShoppingCartService
    {
        private readonly List<CartItem> _shoppingCart;

        public ShoppingCartServiceFake()
        {
            
            _shoppingCart = new List<CartItem>()
            {
                new CartItem() { Id = 1, ProductId = 1, Number=1, Price = 10.00M },
                new CartItem() { Id = 2, ProductId = 2, Number=1, Price = 20.00M },
            };
        }

        public IEnumerable<CartItem> GetAllItems()
        {
            return _shoppingCart;
        }

        public void Add(CartItem newItem)
        {
            newItem.Id = 1;
            _shoppingCart.Add(newItem);
           
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
