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
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService authorService;

        public AuthorsController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Author>> Get()
        {
            var authors = this.authorService.Get();

            return Ok(authors);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Author> Get([FromRoute] Guid id)
        {
            var result = this.authorService.Get(id);

            if (result is SuccessfulResult<Author> successfulResult)
            {
                return Ok(successfulResult.Value);
            }
            else if (result is NotFoundResult<Author>)
            {
                return NotFound();
            }
            else
            {
                throw new AuthorException(id, result, $"Failed to retrieve author {id}");
            }
        }

        [HttpPost]
        public ActionResult<Author> Post([FromBody] AuthorRequest authorRequest)
        {
            var author = this.authorService.Add(authorRequest);

            return Ok(author);
        }


        [HttpPut]
        [Route("{id}")]
        public ActionResult<Author> Put([FromRoute] Guid id, [FromBody] AuthorRequest authorRequest)
        {
            var result = this.authorService.Update(id, authorRequest);

            if (result is SuccessfulResult<Author> successfulResult)
            {
                return Ok(successfulResult.Value);
            }
            else if (result is NotFoundResult<Author>)
            {
                return NotFound();
            }
            else
            {
                throw new AuthorException(id, result, $"Failed to update author {id}");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete([FromRoute] Guid id)
        {
            this.authorService.Delete(id);

            return Ok();
        }
    }
}
