using System.ComponentModel.DataAnnotations;

namespace BookDatabase.Contracts.Request
{
    public record BookRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; } = string.Empty;

        public Guid AuthorId { get; set; }
    }
}
