using pressAgency.Shared.DTO.Common;
using pressAgency.Shared.DTO.IDTO;
using pressAgency.Shared.DTO.ODTO;

namespace pressAgency.Services.Interfaces
{
    public interface IPostsServices
    {
        Task<PagedResult<PostsODTO>> GetAllPosts(int page, int pageSize);

        Task<PostsODTO> GetSinglePost(int postId);

        Task<GenericResponse> CreateNewPost(PostsIDTO newPost);

        Task<PostEditRequestODTO> GetPostForEdit (int postId);

        Task<GenericResponse> ExtendPostEditSession(int postId);

        Task<GenericResponse> SavePost(EditedPostIDTO postToSave);
    }
}
