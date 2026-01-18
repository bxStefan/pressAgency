using pressAgency.Shared.DTO.Common;
using pressAgency.Shared.DTO.IDTO;
using pressAgency.Shared.DTO.ODTO;

namespace pressAgency.Domain.Repository.Interfaces
{
    public interface IPostsRepository
    {
        Task<PagedResult<PostsODTO>> GetAllPosts(int page, int pageSize);

        Task<PostsODTO> GetSinglePost(int postId);

        Task<bool> CheckForExisitingPost(string postName);

        Task<bool> CheckForExisitingPostAfterEdit(int postId, string postName);

        Task<string> CreatePost(PostsIDTO newPost, int authorId);

        Task SavePost(EditedPostIDTO postToSave);
    }
}
