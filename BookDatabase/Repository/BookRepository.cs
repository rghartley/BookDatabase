using BookDatabase.Common.Result;
using BookDatabase.Models;
using System.Collections.Concurrent;

namespace BookDatabase.Repository
{
    internal class BookRepository : IBookRepository
    {
        private readonly ConcurrentDictionary<Guid, Book> books = new();

        public void AddOrUpdate(Book book)
        {
            this.books.AddOrUpdate(book.Id, book, (k, v) => book);
        }

        public void Delete(Guid id)
        {
            this.books.TryRemove(id, out _);
        }

        public Result<Book> Get(Guid id)
        {
            this.books.TryGetValue(id, out var book);

            return book is null
                ? new NotFoundResult<Book>()
                : new SuccessfulResult<Book>(book);
        }

        public IEnumerable<Book> Get()
        {
            return this.books.Values;
        }

        public Result<Book> IncrementSaleCount(Guid id)
        {
            this.books.TryGetValue(id, out var book);

            if (book is null)
            {
                return new NotFoundResult<Book>();
            }

            book.IncrementSalesCount();

            return new SuccessfulResult<Book>(book);
        }
    }
}
