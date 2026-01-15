using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace pressAgency.Controllers
{
    [Route("api/v1/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetAllPosts()
        {
            return Ok("All posts");
        }
    }
}
