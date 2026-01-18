using Microsoft.AspNetCore.Cors;
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
    [EnableCors("CORS")]
    public class PostsController : ControllerBase
    {
        private readonly IPostsServices _postsService;

        public PostsController(IPostsServices posts)
        {
            _postsService = posts;
        }

        [HttpGet]
        [EndpointSummary("Get all available posts")]
        public async Task<ActionResult<PagedResult<PostsODTO>>> GetAllPosts(int page, int pageSize)
        {
            var posts = await _postsService.GetAllPosts(page, pageSize);

            if(posts.Records?.Count == 0)
                return NotFound();

            return Ok(posts);

        }

        [HttpGet("{postId}")]
        [EndpointSummary("Get single post by id")]
        public async Task<ActionResult<PostsODTO>> GetSinglePost(int postId)
        {
            var post = await _postsService.GetSinglePost(postId);

            if (post.PostId == null)
                return NotFound();

            return Ok(post);
        }

        [HttpPost("create-new")]
        [EndpointSummary("Create new post")]
        [EndpointDescription("Create new posts. Blocked if post with same name already exists")]
        public async Task<ActionResult<GenericResponse>> CreateNewPost([FromBody] PostsIDTO newPost)
        {
            var result = await _postsService.CreateNewPost(newPost);

            if (result.Status != 200)
                return StatusCode(result.Status, result);

            return Ok(result);
        }

        [HttpGet("request-edit/{postId}")]
        [EndpointSummary("Request post for edit")]
        [EndpointDescription("Endpoint returns requested post alongside with it's lock state")]
        public async Task<ActionResult<PostEditRequestODTO>> GetPostForEdit(int postId)
        {
            var postForEdit = await _postsService.GetPostForEdit(postId);
            return Ok(postForEdit);
        }

        [HttpGet("extend-edit-session/{postId}")]
        [EndpointSummary("Extends session for post editing")]
        [EndpointDescription("Used in fixed intervals to extend edit session by 10 more minutes")]
        public async Task<ActionResult<GenericResponse>> ExtendPostEditSession(int postId)
        {
            var result = await _postsService.ExtendPostEditSession(postId);

            if(result.Status != 200)
                return StatusCode(result.Status, result);

            return Ok(result);
        }

        [HttpPatch("save")]
        [EndpointSummary("Save edited post")]
        [EndpointDescription("Used to save currently edited post. If lock status exists and its valid.")]
        public async Task<ActionResult<GenericResponse>> SavePost([FromBody] EditedPostIDTO postToSave)
        {
            var result = await _postsService.SavePost(postToSave);

            if (result.Status != 200)
                return StatusCode(result.Status, result);

            return Ok(result);
        }
    }
}
