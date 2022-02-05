using BookDatabase.Common.Result;
using BookDatabase.Models;

namespace BookDatabase.Exceptions
{
    internal class AuthorException : Exception
    {
        public AuthorException(Guid id, Result<Author> result, string message) : base(message)
        {
            this.Id = id;
            this.Result = result;
        }

        public Guid Id { get; }

        public Result<Author> Result { get; }
    }
}
