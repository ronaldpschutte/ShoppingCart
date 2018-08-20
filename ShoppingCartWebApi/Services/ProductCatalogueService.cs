using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using web_api.Contracts;
using web_api.Model;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace web_api.Sevices
{

    public class ProductCatalogueService : IProductCatalogueService
    {

        private Dictionary<int, Product> Catalogue = new Dictionary<int, Product>();

       
        public void LoadProductsFromFile()
        {

            using (StreamReader file = File.OpenText(Path.Combine(Directory.GetCurrentDirectory() + "\\Data\\ProductCatalogue.json")))
            {
                JsonSerializer serializer = new JsonSerializer();
                //JObject products = (JObject)serializer.Deserialize(file, typeof(JObject));
                //foreach(JToken p in products.DescendantsAndSelf().Values())
                //{
                //    Product product = p.ToObject<Product>();
                //    Catalogue.TryAdd(product.Id, product);
                //}

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
