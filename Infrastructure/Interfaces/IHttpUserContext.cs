namespace pressAgency.Infrastructure.Interfaces
{
    public interface IHttpUserContext
    {
        int? AuthorId { get; }

        string AuthorEmail { get; }
    }
}
