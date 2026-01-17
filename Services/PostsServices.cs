using Microsoft.AspNetCore.Mvc.RazorPages;
using pressAgency.Domain.Repository.Interfaces;
using pressAgency.Services.Interfaces;
using pressAgency.Shared.DTO.Common;
using pressAgency.Shared.DTO.ODTO;

namespace pressAgency.Services
{
    public class PostsServices : IPostsServices
    {
        private readonly IPostsRepository _postsRepository;

        public PostsServices(IPostsRepository postsRepository)
        {
            _postsRepository = postsRepository;
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
