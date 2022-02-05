namespace BookDatabase.Models
{
    public record Book
    {
        private int salesCount;

        public Guid Id { get; init; }

        public string Name { get; set; } = string.Empty;

        public Guid AuthorId { get; set; }

        public int SalesCount => this.salesCount;

        public void IncrementSalesCount()
        {
            Interlocked.Increment(ref this.salesCount);
        }
    }
}
