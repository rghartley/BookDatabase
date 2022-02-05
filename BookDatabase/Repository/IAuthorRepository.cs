using BookDatabase.Common.Result;
using BookDatabase.Models;

namespace BookDatabase.Repository
{
    internal interface IAuthorRepository
    {
        void AddOrUpdate(Author author);

        void Delete(Guid id);

        Result<Author> Get(Guid id);

        IEnumerable<Author> Get();
    }
}
