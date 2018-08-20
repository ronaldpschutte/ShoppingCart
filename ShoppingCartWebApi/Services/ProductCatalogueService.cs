using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using ShoppingCartWebApi.Contracts;
using ShoppingCartWebApi.Model;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ShoppingCartWebApi.Sevices
{

    public class ProductCatalogueService : IProductCatalogueService
    {

        private Dictionary<int, Product> Catalogue = new Dictionary<int, Product>();

       
        public void LoadProductsFromFile()
        {

            using (StreamReader file = File.OpenText(Path.Combine(Directory.GetCurrentDirectory() + "\\Data\\ProductCatalogue.json")))
            {
                JsonSerializer serializer = new JsonSerializer();
                Product[] products = (Product[])serializer.Deserialize(file, typeof(Product[]));
                foreach (Product p in products)
                {
                    Catalogue.TryAdd(p.Id, p);

                }
            }
        }


        public IEnumerable<Product> GetAllItems()
        {
            return Catalogue.Values;
        }

        public Product GetById(int id)
        {
            Product catalogueItem;
            Catalogue.TryGetValue(id, out catalogueItem);
            if (catalogueItem != null)
            {
                return catalogueItem;
            }
            else
            {
                return null; // nog veranderen in http statuscode
            }
        }
    }
}
