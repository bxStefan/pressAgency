using pressAgency.Domain.Entites;

namespace pressAgency.Domain.Repository.Interfaces
{
    public interface IPostLockRepository
    {
        Task<PostsLock?> GetCurrentLock(int postId);

        Task<PostsLock> CreateNewLock(int postId, int authorId);

        Task DeleteExpiredLock(int postLockId);

        Task ExtendCurrentLock(PostsLock currentLock);
    }
}
