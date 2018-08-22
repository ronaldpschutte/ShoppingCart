using System;
using System.Collections.Generic;
using ShoppingCartWebApi.Models;

namespace ShoppingCartWebApi.Contracts
{
    public interface IShoppingCartService
    {
        IEnumerable<CartItem> GetAllItems();
        void Add(CartItem newItem);
        CartItem GetById(int id);
        void Remove(int id);
    }
}
