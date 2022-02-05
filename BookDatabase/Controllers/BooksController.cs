using BookDatabase.Common.Result;
using BookDatabase.Contracts.Request;
using BookDatabase.Exceptions;
using BookDatabase.Models;
using BookDatabase.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookDatabase.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService bookService;

        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            var books = this.bookService.Get();

            return Ok(books);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Book> Get([FromRoute] Guid id)
        {
            var result = this.bookService.Get(id);

            if (result is SuccessfulResult<Book> successfulResult)
            {
                return Ok(successfulResult.Value);
            }
            else if (result is NotFoundResult<Book>)
            {
                return NotFound();
            }
            else
            {
                throw new BookException(id, result, $"Failed to retrieve book {id}");
            }
        }

        [HttpPost]
        public ActionResult<Book> Post([FromBody] BookRequest bookRequest)
        {
            var book = this.bookService.Add(bookRequest);

            return Ok(book);
        }


        [HttpPut]
        [Route("{id}")]
        public ActionResult<Book> Put([FromRoute] Guid id, [FromBody] BookRequest bookRequest)
        {
            var result = this.bookService.Update(id, bookRequest);

            if (result is SuccessfulResult<Book> successfulResult)
            {
                return Ok(successfulResult.Value);
            }
            else if (result is NotFoundResult<Book>)
            {
                return NotFound();
            }
            else
            {
                throw new BookException(id, result, $"Failed to update book {id}");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete([FromRoute] Guid id)
        {
            this.bookService.Delete(id);

            return Ok();
        }
    }
}
