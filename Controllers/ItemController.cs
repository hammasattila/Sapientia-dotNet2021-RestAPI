using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TyreStore.Models;
using TyreStore.Repositories;

namespace TyreStore.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemController : ControllerBase
    {
        private readonly InMemmoryItemsRepository repository;

        public ItemController()
        {
            repository = new InMemmoryItemsRepository();
        }

        // Get/Items
        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            return repository.GetItems();
        }

        // Get/Item/{id}
        [HttpGet("{id}")]
        public Item GetItem(Guid id)
        {
            var item = repository.GetItem(id);
            // if (item is null)
            // {
            //     return NotFound();
            // }

            return item;
        }
    }
}