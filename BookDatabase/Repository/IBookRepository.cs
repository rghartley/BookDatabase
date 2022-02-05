using BookDatabase.Common.Result;
using BookDatabase.Models;

namespace BookDatabase.Repository
{
    internal interface IBookRepository
    {
        void AddOrUpdate(Book book);

        void Delete(Guid id);

        Result<Book> Get(Guid id);

        IEnumerable<Book> Get();
    }
}
