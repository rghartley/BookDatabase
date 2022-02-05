using BookDatabase.Common.Result;
using BookDatabase.Contracts.Request;
using BookDatabase.Models;

namespace BookDatabase.Services
{
    public interface IBookService
    {
        Result<Book> Get(Guid id);

        IEnumerable<Book> Get();

        Book Add(BookRequest bookRequest);

        Result<Book> Update(Guid Id, BookRequest bookRequest);

        void Delete(Guid Id);

        Result<Book> IncrementSaleCount(Guid id);
    }
}
