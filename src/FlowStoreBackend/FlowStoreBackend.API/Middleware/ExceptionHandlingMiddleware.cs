using FlowStoreBackend.Logic.Exceptions;
using System.Net;

namespace FlowStoreBackend.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        public ExceptionHandlingMiddleware(RequestDelegate next, 
            ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                await ExceptionHandlerAsync(context, ex);
            }
        }

        private async Task ExceptionHandlerAsync(HttpContext context, Exception ex)
        {
            _logger.LogError(ex.Message);
            var code = ex switch
            {
                EntityFindException => HttpStatusCode.NotFound,
                _ => HttpStatusCode.InternalServerError
            };
            await context.Response.WriteAsJsonAsync(new { StatusCode = code, Errors = ex.Message });
        }
    }
}
