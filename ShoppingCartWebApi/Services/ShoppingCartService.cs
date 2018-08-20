using System;
using System.Collections.Generic;
using ShoppingCartWebApi.Contracts;
using ShoppingCartWebApi.Model;

namespace ShoppingCartWebApi.Sevices
{
    public class ShoppingCartService : IShoppingCartService
    {
        public CartItem Add(CartItem newItem)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CartItem> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public CartItem GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
