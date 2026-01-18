using Microsoft.AspNetCore.Mvc;
using pressAgency.Services.Interfaces;
using pressAgency.Shared.Constants;
using pressAgency.Shared.DTO.Common;
using pressAgency.Shared.DTO.IDTO;
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

            if(posts.Records?.Count == 0)
                return NotFound();

            return Ok(posts);

        }

        [HttpGet("{postId}")]
        public async Task<ActionResult<PostsODTO>> GetSinglePost(int postId)
        {
            var post = await _postsService.GetSinglePost(postId);

            if (post.PostId == null)
                return NotFound();

            return Ok(post);
        }

        [HttpPost("create-new")]
        public async Task<ActionResult<GenericResponse>> CreateNewPost([FromBody] PostsIDTO newPost)
        {
            var result = await _postsService.CreateNewPost(newPost);

            if (result.Status != 200)
                return StatusCode(result.Status, result);

            return Ok(result);
        }

        [HttpGet("request-edit/{postId}")]
        public async Task<ActionResult<PostEditRequestODTO>> GetPostForEdit(int postId)
        {
            var postForEdit = await _postsService.GetPostForEdit(postId);
            return Ok(postForEdit);
        }

        [HttpGet("extend-edit-session/{postId}")]
        public async Task<ActionResult<GenericResponse>> ExtendPostEditSession(int postId)
        {
            var result = await _postsService.ExtendPostEditSession(postId);

            if(result.Status != 200)
                return StatusCode(result.Status, result);

            return Ok(result);
        }
    }
}
