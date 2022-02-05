namespace BookDatabase.Models
{
    public record Book
    {
        public Guid Id { get; init; }

        public string Name { get; set; } = string.Empty;

        public Guid AuthorId { get; set; }

        public int SalesCount { get; set; }
    }
}
