namespace pressAgency.Middlewares
{
    internal sealed class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await TryHandleAync(ex, context);
            }
        }

        private async Task TryHandleAync(Exception ex, HttpContext context)
        {
            context.Response.StatusCode = ex switch
            {
                KeyNotFoundException => StatusCodes.Status404NotFound,
                ArgumentException or ArgumentNullException or ArgumentOutOfRangeException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };

            context.Response.ContentType = "application/problem+json";

            await context.Response.WriteAsJsonAsync(new
            {
                Title = "An error occurred while processing your request.",
                Type = ex.GetType().Name,
                Details = ex.Message,
                TraceId = context.TraceIdentifier
            });
        }
    }
}
