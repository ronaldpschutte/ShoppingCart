using System;
using System.Collections.Generic;
using web_api.Model;

namespace web_api.Contracts
{
    public interface IShoppingCartService
    {
        IEnumerable<CartItem> GetAllItems();
        CartItem Add(CartItem newItem);
        CartItem GetById(int id);
        void Remove(int id);
    }
}
