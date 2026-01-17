using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pressAgency.Services.Interfaces;
using pressAgency.Shared.Constants;
using pressAgency.Shared.DTO.Common;
using pressAgency.Shared.DTO.ODTO;

namespace pressAgency.Controllers
{
    [Route($"{Constants.DefaultRouteSuffix}/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsServices _authorsServices;

        public AuthorsController(IAuthorsServices authorsServices)
        {
            _authorsServices = authorsServices;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<AuthorsODTO>>> GetAllAuthors(int page, int pageSize)
        {
            var authors = await _authorsServices.GetAllAuthors(page, pageSize);
            if (authors.Records?.Count > 0)
            {
                return Ok(authors);
            }
            return NotFound(Constants.NoAuthorsFound);
        }

        [HttpGet("{authorId}")]
        public async Task<ActionResult<AuthorsODTO>> GetSingleAuthor(int authorId)
        {
            var author = await _authorsServices.GetSingleAuthor(authorId);
            if (author.AuthorId != 0)
            {
                return Ok(author);
            }
            return NotFound(Constants.AuthorNotFound);
        }
    }
}
