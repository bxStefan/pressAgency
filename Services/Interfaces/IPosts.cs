namespace pressAgency.Services.Interfaces
{
    public interface IPosts
    {
        Task GetAllPosts();

        Task GetSinglePost();
    }
}
