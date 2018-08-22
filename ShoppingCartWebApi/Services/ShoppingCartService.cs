using System;
using System.Collections.Generic;
using ShoppingCartWebApi.Contracts;
using ShoppingCartWebApi.Models;

namespace ShoppingCartWebApi.Sevices
{
    public class ShoppingCartService : IShoppingCartService
    {
        Dictionary<int,CartItem> cartItems;

        public void Add(CartItem newItem)
        {
            // Create a shoppingCard if this is a first item in Card

            cartItems.Add(newItem.Id, newItem);

        }

        public IEnumerable<CartItem> GetAllItems()
        {
            return cartItems.Values;
        }

        public CartItem GetById(int id)
        {
            return cartItems.GetValueOrDefault(id);
        }

        public void Remove(int id)
        {
            cartItems.Remove(id);
        }
    }
}
