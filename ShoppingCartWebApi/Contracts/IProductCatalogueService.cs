using System;
using System.Collections.Generic;
using web_api.Model;

namespace web_api.Contracts
{
    public interface IProductCatalogueService
    {
        void LoadProductsFromFile();
        IEnumerable<Product> GetAllItems();
        Product GetById(int id);
    }
}
