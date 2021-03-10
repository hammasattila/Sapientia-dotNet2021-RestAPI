namespace TyreStore.Dtos
{
    using System;
    public record ItemDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public double Width { get; init; }
        public double Height { get; init; }
        public double Inch { get; init; }
        public double Price { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }

}