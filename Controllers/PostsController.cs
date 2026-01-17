using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pressAgency.Services.Interfaces;
using pressAgency.Shared;
using pressAgency.Shared.DTO.Common;
using pressAgency.Shared.DTO.ODTO;

namespace pressAgency.Controllers
{
    [Route($"{Constants.DefaultRouteSuffix}/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostsServices _postsService;

        public PostsController(IPostsServices posts)
        {
            _postsService = posts;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<PostsODTO>>> GetAllPosts(int page, int pageSize)
        {
            var posts = await _postsService.GetAllPosts(page, pageSize);

            if(posts.Records?.Count > 0)
            {
                return Ok(posts);
            }

            return NotFound(Constants.NoPostsFound);
        }

        [HttpGet("{postId}")]
        public async Task<ActionResult<PostsODTO>> GetSinglePost(int postId)
        {
            var post = await _postsService.GetSinglePost(postId);
            if (post.PostId != 0)
            {
                return Ok(post);
            }

            return NotFound(Constants.PostNotFound);
        }
    }
}
