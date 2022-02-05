using BookDatabase.Common.Result;
using BookDatabase.Contracts.Request;
using BookDatabase.Models;

namespace BookDatabase.Services
{
    public interface IAuthorService
    {
        Result<Author> Get(Guid id);

        IEnumerable<Author> Get();

        Author Add(AuthorRequest authorRequest);

        Result<Author> Update(Guid Id, AuthorRequest authorRequest);

        void Delete(Guid Id);
    }
}
