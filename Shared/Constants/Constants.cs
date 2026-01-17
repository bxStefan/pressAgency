using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace pressAgency.Shared.Constants
{
    public static class Constants
    {
        // Pagination defaults
        public const int DefaultPage = 1;
        public const int DefaultPageSize = 10;
        public const int MaxPageSize = 100;

        // Controller output messages
        public const string NoPostsFound = "No posts found";
        public const string PostNotFound = "Post not found";

        // Route props
        public const string DefaultRouteSuffix = "/api/v1";
    }
}
