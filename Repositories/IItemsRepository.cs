
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TyreStore.Models;

namespace TyreStore.Repositories
{

    public interface IItemsRepository
    {
        Task<Item> GetItemAsync(Guid id);
        IEnumerable<Item> GetItemsAsync();
        Task CreateItemAsync(Item item);
        Task UpdateItemAsync(Item item);
        Task DeleteItemAsync(Guid id);
    }
}