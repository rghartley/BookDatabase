using BookDatabase.Common.Result;
using BookDatabase.Models;

namespace BookDatabase.Exceptions
{
    public class BookException : Exception
    {
        public BookException(Guid id, Result<Book> result, string message) : base(message)
        {
            this.Id = id;
            this.Result = result;
        }

        public Guid Id { get; }

        public Result<Book> Result { get; }
    }
}
