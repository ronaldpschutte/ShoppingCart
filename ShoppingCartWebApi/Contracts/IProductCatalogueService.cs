using System;
using System.Collections.Generic;
using ShoppingCartWebApi.Models;

namespace ShoppingCartWebApi.Contracts
{
    public interface IProductCatalogueService
    {
        void LoadProductsFromFile();
        IEnumerable<Product> GetAllItems();
        Product GetById(int id);
    }
}
