using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using ShoppingCartWebApi.Contracts;
using ShoppingCartWebApi.Models;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Net.Http;
using Microsoft.Extensions.Logging;

namespace ShoppingCartWebApi.Sevices
{

    public class ProductCatalogueService : IProductCatalogueService
    {

        private Dictionary<int, Product> Catalogue = new Dictionary<int, Product>();
        private readonly ILogger _logger;

        public ProductCatalogueService(ILogger<ProductCatalogueService> logger)
        {
            _logger = logger;
        }
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
                _logger.LogInformation($"ProductCatalogue: {products.Count()} products");
            }
        }


        public IEnumerable<Product> GetAllItems()
        {
            try
            {
                List<Product> products = Catalogue.Values.ToList<Product>();
                _logger.LogInformation($"ProductCatalogue: {products.Count()} products");

                //List<Product> products = new List<Product>();
                //Product p = new Product();
                //p.Category = "sd";
                //p.Description = "sds";
                //p.Id = 1;
                //p.Title = "wew";
                //p.Price = 10.00M;
                //products.Add(p);
                return products;


            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.InnerException.Message.ToString(), e);
                return null;
            }
           
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
