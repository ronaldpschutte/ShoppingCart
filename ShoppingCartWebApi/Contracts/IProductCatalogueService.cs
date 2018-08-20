using System;
using System.Collections.Generic;
using ShoppingCartWebApi.Model;

namespace ShoppingCartWebApi.Contracts
{
    public interface IProductCatalogueService
    {
        void LoadProductsFromFile();
        IEnumerable<Product> GetAllItems();
        Product GetById(int id);
    }
}
