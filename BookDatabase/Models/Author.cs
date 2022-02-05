namespace BookDatabase.Models
{
    public record Author
    {
        public Guid Id { get; init; }

        public string Firstname { get; set; } = string.Empty;

        public string Lastname { get; set; } = string.Empty;
    }
}
