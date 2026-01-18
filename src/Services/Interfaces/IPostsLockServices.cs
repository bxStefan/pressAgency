namespace pressAgency.Services.Interfaces
{
    public interface IPostsLockServices
    {
        public Task VerifyPostLockStatus(int postId);
    }
}
