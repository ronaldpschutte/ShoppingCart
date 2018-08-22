using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ShoppingCartWebApi.Contracts;
using ShoppingCartWebApi.Models;

namespace ShoppingCartWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _service;

        public ShoppingCartController(IShoppingCartService service)
        {
            _service = service;
        }

        // GET api/shoppingcart
        [HttpGet]
        public ActionResult<IEnumerable<CartItem>> Get()
        {
            var items = _service.GetAllItems();
            return Ok(items);
        }

        // GET api/shoppingcart/5
        [HttpGet("{id}")]
        public ActionResult<CartItem> Get(int id)
        {
            var item = _service.GetById(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // POST api/shoppingcart
        [HttpPost]
        public ActionResult Post([FromBody] CartItem value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
                _service.Add(value);
                return CreatedAtAction("Get", new { id = value.Id }, value);
        }

        // DELETE api/shoppingcart/5
        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            var existingItem = _service.GetById(id);

            if (existingItem == null)
            {
                return NotFound();
            }

            _service.Remove(id);
            return Ok();
        }
    }
}