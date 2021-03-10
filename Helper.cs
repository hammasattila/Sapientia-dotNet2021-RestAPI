using TyreStore.Dtos;
using TyreStore.Models;

namespace TyreStore
{
    public static class Helper
    {
        public static ItemDto MapToDto(this Item item)
        {
            return new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Width = item.Width,
                Height = item.Height,
                Inch = item.Inch,
                Price = item.Price,
                CreatedDate = item.CreatedDate
            };
        }
    }
}