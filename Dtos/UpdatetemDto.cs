using System.ComponentModel.DataAnnotations;

namespace TyreStore.Dtos
{

    public record UpdateItemDto
    {
        [Required]
        public string Name { get; init; }
        [Required]
        [Range(100, 400)]
        public double Width { get; init; }
        [Required]
        [Range(10, 100)]
        public double Height { get; init; }
        [Required]
        [Range(10, 100)]
        public double Inch { get; init; }
        [Required]
        [Range(1, 1000)]
        public double Price { get; init; }
    }

}