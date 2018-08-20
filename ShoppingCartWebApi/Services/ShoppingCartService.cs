using System;
using System.Collections.Generic;
using web_api.Contracts;
using web_api.Model;

namespace web_api.Sevices
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
