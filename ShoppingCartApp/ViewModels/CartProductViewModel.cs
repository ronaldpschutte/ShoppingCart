using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCartApp.Models;

namespace ShoppingCartApp.ViewModels
{
    public class CartProductViewModel
    {
        public CartItem CartItem { get; }
        public Product Product { get; }
    }
}
