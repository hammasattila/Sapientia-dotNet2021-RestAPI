using System;
using System.Collections.Generic;
using System.Linq;
using TyreStore.Models;

namespace TyreStore.Repositories
{
    class InMemmoryItemsRepository
    {
        private readonly List<Item> Items = new(){
            new Item { Id = Guid.NewGuid(), Name = "Bridgestone", Price = 44, Width = 205, Height = 55, Inch = 16, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Hankook", Price = 44, Width = 205, Height = 55, Inch = 16, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Dunlop", Price = 44, Width = 205, Height = 55, Inch = 16, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Pirelli", Price = 44, Width = 205, Height = 55, Inch = 16, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Continental", Price = 44, Width = 205, Height = 55, Inch = 16, CreatedDate = DateTimeOffset.UtcNow },
        };
        
        public IEnumerable<Item> GetItems() {
            return Items;
        }

        public Item GetItem(Guid id) {
            return Items.Where(item => item.Id == id).SingleOrDefault();
        }
    }
}