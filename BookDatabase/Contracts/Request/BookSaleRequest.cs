namespace BookDatabase.Contracts.Request
{
    public record BookSaleRequest
    {
        public Guid BookId { get; init; }
    }
}
