using Microsoft.AspNetCore.Mvc;
using SimpleApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace SimpleApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        private static List<Item> items = new List<Item>();

        [HttpGet]
        public ActionResult<IEnumerable<Item>> Get() => items;

        [HttpPost]
        public ActionResult<Item> Post(Item item)
        {
            if (items.Any(i => i.Id == item.Id))
                return BadRequest("Item with this ID already exists.");
            items.Add(item);
            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Item updatedItem)
        {
            var index = items.FindIndex(i => i.Id == id);
            if (index == -1)
                return NotFound("Item not found.");

            items[index] = updatedItem;
            return Ok(updatedItem);
        }
    }
}
