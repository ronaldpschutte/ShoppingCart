using System;
using System.Collections.Generic;
using ShoppingCartWebApi.Model;

namespace ShoppingCartWebApi.Contracts
{
    public interface IShoppingCartService
    {
        IEnumerable<CartItem> GetAllItems();
        CartItem Add(CartItem newItem);
        CartItem GetById(int id);
        void Remove(int id);
    }
}
