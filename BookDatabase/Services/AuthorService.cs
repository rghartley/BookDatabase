using BookDatabase.Common.Result;
using BookDatabase.Contracts.Request;
using BookDatabase.Models;
using BookDatabase.Repository;

namespace BookDatabase.Services
{
    internal class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public Result<Author> Get(Guid id)
        {
            return this.authorRepository.Get(id);
        }

        public IEnumerable<Author> Get()
        {
            return this.authorRepository.Get();
        }

        public Author Add(AuthorRequest authorRequest)
        {
            var id = Guid.NewGuid();

            var author = new Author
            {
                Id = id,
                Firstname = authorRequest.Firstname,
                Lastname = authorRequest.Lastname
            };

            this.authorRepository.AddOrUpdate(author);

            return author;
        }

        public Result<Author> Update(Guid Id, AuthorRequest authorRequest)
        {
            var authorResult = this.authorRepository.Get(Id);

            if (authorResult is SuccessfulResult<Author> successfulAuthorResult)
            {
                var author = successfulAuthorResult.Value;

                author.Firstname = authorRequest.Firstname;
                author.Lastname = authorRequest.Lastname;

                this.authorRepository.AddOrUpdate(author);
            }

            return authorResult;
        }

        public void Delete(Guid Id)
        {
            this.authorRepository.Delete(Id);
        }
    }
}
