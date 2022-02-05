using BookDatabase.Common.Result;
using BookDatabase.Models;
using System.Collections.Concurrent;

namespace BookDatabase.Repository
{
    internal class AuthorRepository : IAuthorRepository
    {
        private readonly ConcurrentDictionary<Guid, Author> authors = new();

        public void AddOrUpdate(Author author)
        {
            this.authors.AddOrUpdate(author.Id, author, (k, v) => author);
        }

        public void Delete(Guid id)
        {
            this.authors.TryRemove(id, out _);
        }

        public Result<Author> Get(Guid id)
        {
            this.authors.TryGetValue(id, out var author);

            return author is null
                ? new NotFoundResult<Author>()
                : new SuccessfulResult<Author>(author);
        }

        public IEnumerable<Author> Get()
        {
            return this.authors.Values;
        }
    }
}
