using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TyreStore.Models;

namespace TyreStore.Repositories
{
    class InMemmoryItemsRepository : IItemsRepository
    {
        private readonly List<Item> Items = new()
        {
            new Item { Id = Guid.NewGuid(), Name = "Bridgestone", Price = 44, Width = 205, Height = 55, Inch = 16, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Hankook", Price = 44, Width = 205, Height = 55, Inch = 16, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Dunlop", Price = 44, Width = 205, Height = 55, Inch = 16, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Pirelli", Price = 44, Width = 205, Height = 55, Inch = 16, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Continental", Price = 44, Width = 205, Height = 55, Inch = 16, CreatedDate = DateTimeOffset.UtcNow },
        };

        public IEnumerable<Item> GetItemsAsync()
        {
            return Items;
        }

        public async Task<Item> GetItemAsync(Guid id)
        {
            var item = Items.Where(item => item.Id == id).SingleOrDefault();
            return await Task.FromResult(item);
        }

        public async Task CreateItemAsync(Item item)
        {
            Items.Add(item);
            await Task.CompletedTask;
        }

        public async Task UpdateItemAsync(Item item)
        {
            var index = Items.FindIndex(existingItem => existingItem.Id == item.Id);
            Items[index] = item;
            await Task.CompletedTask;
        }

        public async Task DeleteItemAsync(Guid id)
        {
            var index = Items.FindIndex(existingItem => existingItem.Id == id);
            Items.RemoveAt(index);
            await Task.CompletedTask;
        }
    }
}