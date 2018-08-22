using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ShoppingCartWebApi.Contracts;
using ShoppingCartWebApi.Models;

namespace ShoppingCartWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCatalogueController : ControllerBase
    {
        private readonly IProductCatalogueService _service;

        public ProductCatalogueController(IProductCatalogueService service)
        {
            _service = service;
        }

        // GET api/productcatalogue
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var items = _service.GetAllItems();
            return Ok(items);
        }

        // GET api/productcatalogue/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var item = _service.GetById(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

    }
}