using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TyreStore.Dtos;
using TyreStore.Models;
using TyreStore.Repositories;

namespace TyreStore.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemController : ControllerBase
    {
        private readonly IItemsRepository repository;

        public ItemController(IItemsRepository repository)
        {
            this.repository = repository;
        }

        // Get/Items
        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items = repository.GetItems().Select(item => item.MapToDto());
            return items;
        }

        // Get/Item/{id}
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = repository.GetItem(id);
            if (item is null)
            {
                return NotFound();
            }

            return item.MapToDto();
        }

        // Post/Item/
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto createItemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = createItemDto.Name,
                Width = createItemDto.Width,
                Height = createItemDto.Height,
                Inch = createItemDto.Inch,
                Price = createItemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            repository.CreateItem(item);
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.MapToDto());
        }

        // Put/item/
        [HttpPut("{id}")]
        public ActionResult<ItemDto> UpdateItem(Guid id, UpdateItemDto updateItemDto)
        {
            var existingItem = repository.GetItem(id);

            if(existingItem is null) {
                return NotFound();
            }

            Item updateItem = existingItem with
            {
                Name = updateItemDto.Name,
                Width = updateItemDto.Width,
                Height = updateItemDto.Height,
                Inch = updateItemDto.Inch,
                Price = updateItemDto.Price
            };

            repository.UpdateItem(updateItem);
            return NoContent();
        }
    }
}