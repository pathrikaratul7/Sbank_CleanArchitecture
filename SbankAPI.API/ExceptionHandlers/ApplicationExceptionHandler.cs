using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace SbankAPI.API.ExceptionHandlers
{
    public class ApplicationExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<ApplicationExceptionHandler> _logger;

        public ApplicationExceptionHandler(ILogger<ApplicationExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            // Only handle specific application exceptions
            if (exception is not (ArgumentException or InvalidOperationException))
            {
                return false;
            }

            _logger.LogWarning(exception, "An application exception occurred: {ExceptionMessage}", exception.Message);

            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Bad Request",
                Detail = exception.Message,
                Instance = httpContext.Request.Path,
                Extensions = new Dictionary<string, object?> { { "traceId", httpContext.TraceIdentifier } }
            };

            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            httpContext.Response.ContentType = "application/problem+json";

            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}