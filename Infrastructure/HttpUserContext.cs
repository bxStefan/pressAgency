using pressAgency.Infrastructure.Interfaces;

namespace pressAgency.Infrastructure
{
    public class HttpUserContext : IHttpUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpUserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int? AuthorId => _httpContextAccessor.HttpContext?.Items["UserId"] as int? 
                                  ?? throw new UnauthorizedAccessException("Unauthorized");

        public string AuthorEmail => _httpContextAccessor.HttpContext?.Items["UserEmail"] as string
                                      ?? throw new UnauthorizedAccessException("Unauthorized");
    }
}
