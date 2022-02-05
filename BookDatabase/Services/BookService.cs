using BookDatabase.Common.Result;
using BookDatabase.Contracts.Request;
using BookDatabase.Models;
using BookDatabase.Repository;

namespace BookDatabase.Services
{
    internal class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public Result<Book> Get(Guid id)
        {
            return this.bookRepository.Get(id);
        }

        public IEnumerable<Book> Get()
        {
            return this.bookRepository.Get();
        }

        public Book Add(BookRequest bookRequest)
        {
            var id = Guid.NewGuid();

            var book = new Book
            {
                Id = id,
                Name = bookRequest.Name,
                AuthorId = bookRequest.AuthorId
            };

            this.bookRepository.AddOrUpdate(book);

            return book;
        }

        public Result<Book> Update(Guid Id, BookRequest bookRequest)
        {
            var bookResult = this.bookRepository.Get(Id);

            if (bookResult is SuccessfulResult<Book> successfulBookResult)
            {
                var book = successfulBookResult.Value;

                book.Name = bookRequest.Name;
                book.AuthorId = bookRequest.AuthorId;

                this.bookRepository.AddOrUpdate(book);
            }

            return bookResult;
        }

        public void Delete(Guid Id)
        {
            this.bookRepository.Delete(Id);
        }

        public Result<Book> IncrementSaleCount(Guid id)
        {
            return this.bookRepository.IncrementSaleCount(id);
        }
    }
}
