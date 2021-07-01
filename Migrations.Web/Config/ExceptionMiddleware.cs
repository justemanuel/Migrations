using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Migrations.Web.Models.Others;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Migrations.Web.Config
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<ExceptionMiddleware>();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong!: {ex.Message}");
                await HandleGlobalExceptionAsync(context, ex);
            }
        }

        private static Task HandleGlobalExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.NotAcceptable;
            return context.Response.WriteAsync(JsonSerializer.Serialize(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = "Oops, something went wrong!",
                StackTrace = ex.StackTrace
            }));
        }
    }
}
