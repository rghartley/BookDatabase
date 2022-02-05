using System.ComponentModel.DataAnnotations;

namespace BookDatabase.Contracts.Request
{
    public record AuthorRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Firstname { get; init; } = string.Empty;

        [Required(AllowEmptyStrings = false)]
        public string Lastname { get; init; } = string.Empty;
    }
}
