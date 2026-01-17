using pressAgency.Domain.Repository.Interfaces;
using pressAgency.Infrastructure.Interfaces;
using pressAgency.Services.Interfaces;
using pressAgency.Shared.DTO.Common;
using pressAgency.Shared.DTO.IDTO;
using pressAgency.Shared.DTO.ODTO;

namespace pressAgency.Services
{
    public class PostsServices : IPostsServices
    {
        private readonly IPostsRepository _postsRepository;
        private readonly IHttpUserContext _httpUserContext;

        public PostsServices(IPostsRepository postsRepository, IHttpUserContext httpUserContext)
        {
            _postsRepository = postsRepository;
            _httpUserContext = httpUserContext;
        }

        public async Task<string> CreateNewPost(PostsIDTO newPost)
        {
            int authorId = _httpUserContext.AuthorId;
            return await _postsRepository.CreatePost(newPost, authorId);
        }

        public async Task<PagedResult<PostsODTO>> GetAllPosts(int page, int pageSize)
        {
            return await _postsRepository.GetAllPosts(page, pageSize);
        }

        public async Task<PostsODTO> GetSinglePost(int postId)
        {
            return await _postsRepository.GetSinglePost(postId);
        }
    }
}
