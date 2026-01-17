using Microsoft.EntityFrameworkCore;
using pressAgency.Domain.Context;
using pressAgency.Shared.Constants;
using System.Text.RegularExpressions;

namespace pressAgency.Middlewares
{
    public class BasicAuthMiddleware : IMiddleware
    {
        private readonly PressDbContext _dbContext;
        private static readonly Regex EmailRegex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

        public BasicAuthMiddleware(PressDbContext pressDbContext)
        {
            _dbContext = pressDbContext;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // auth only against api routes
            string currentPath = context.Request.Path.Value ?? "/";

            if (!currentPath.StartsWith(Constants.DefaultRouteSuffix))
            {
                await next(context);
                return;
            }

            if (!context.Request.Headers.TryGetValue("X-User-Email", out var emailHeader))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsJsonAsync(new
                {
                    Status = 401,
                    Message = "Unauthorized",
                    Reason = "User not provided"
                });

                return;
            }

            var email = emailHeader.ToString()
                                   .Trim()
                                   .ToLower();

            if (email.Length == 0 || !EmailRegex.IsMatch(email))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsJsonAsync(new
                {
                    Status = 401,
                    Message = "Unauthorized",
                    Reason = "Invalid user email"
                });
                return;
            }

            var user = await _dbContext.Authors
                                       .AsNoTracking()
                                       .Where(x => x.Email == email)
                                       .Select(x => new { x.AuthorId, x.Email })
                                       .FirstOrDefaultAsync();

            if (user == null)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsJsonAsync(new
                {
                    Status = 401,
                    Message = "Unauthorized",
                    Reason = "Unkown user provided"
                });
                return;
            }

            context.Items["UserId"] = user.AuthorId;
            context.Items["UserEmail"] = user.Email;

            await next(context);
        }
    }
}
