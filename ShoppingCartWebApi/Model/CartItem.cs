using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartWebApi.Model
{
    public class CartItem
    {
        public int Id { get; set; }
        [Required]
        public Product product{get;set; }
        public decimal Price { get; set; }
        public int Number { get; set; }
    }
}
