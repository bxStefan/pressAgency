using pressAgency.Shared.DTO.Common;
using pressAgency.Shared.DTO.ODTO;

namespace pressAgency.Domain.Repository.Interfaces
{
    public interface IPostsRepository
    {
        Task<PagedResult<PostsODTO>> GetAllPosts(int page, int pageSize);

        Task<PostsODTO> GetSinglePost(int postId);
    }
}
