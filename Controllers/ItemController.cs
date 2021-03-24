using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
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
        [EnableCors("mySpecificOrigin")]
        [HttpGet]
        public IEnumerable<ItemDto> GetItemsAsync()
        {
            var items = repository.GetItemsAsync().Select(item => item.MapToDto());
            return items;
        }

        // Get/Item/{id}
        [EnableCors("mySpecificOrigin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItemAsync(Guid id)
        {
            var item = await repository.GetItemAsync(id);
            if (item is null)
            {
                return NotFound();
            }

            return item.MapToDto();
        }

        // Post/Item/
        [HttpPost]
        public async Task<ActionResult<ItemDto>> CreateItem(CreateItemDto createItemDto)
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

            await repository.CreateItemAsync(item);
            return CreatedAtAction(nameof(GetItemAsync), new { id = item.Id }, item.MapToDto());
        }

        // Put/item/
        [HttpPut("{id}")]
        public async Task<ActionResult<ItemDto>> UpdateItem(Guid id, UpdateItemDto updateItemDto)
        {
            var existingItem = await repository.GetItemAsync(id);

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

            await repository.UpdateItemAsync(updateItem);
            return NoContent();
        }

        // Delete/item/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItemAsync(Guid id)
        {
            var existingItem = await repository.GetItemAsync(id);

            if(existingItem is null) {
                return NotFound();
            }

            await repository.DeleteItemAsync(id);
            return NoContent();
        }
    }
}