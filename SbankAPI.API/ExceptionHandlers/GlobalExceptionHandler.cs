using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace SbankAPI.API.ExceptionHandlers
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            _logger.LogError(exception, "An unhandled exception occurred: {ExceptionMessage}", exception.Message);

            var problemDetails = new ProblemDetails
            {
                Instance = httpContext.Request.Path,
                Extensions = new Dictionary<string, object?> { { "traceId", httpContext.TraceIdentifier } }
            };

            if (exception is ValidationException validationException)
            {
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                problemDetails.Title = "Validation error";
                problemDetails.Status = StatusCodes.Status400BadRequest;
                problemDetails.Detail = "One or more validation errors occurred.";
                problemDetails.Extensions.Add("errors", validationException.Errors
                    .GroupBy(x => x.PropertyName)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Select(x => x.ErrorMessage).ToArray()));
            }
            else
            {
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                problemDetails.Title = "An error occurred while processing your request.";
                problemDetails.Status = StatusCodes.Status500InternalServerError;
                problemDetails.Detail = exception.Message;
            }

            httpContext.Response.ContentType = "application/problem+json";
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}