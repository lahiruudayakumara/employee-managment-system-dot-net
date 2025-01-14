using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var errorDetails = new
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = "An unexpected error occurred.",
                Details = exception.Message
            };

            if (httpContext.Response.StatusCode == (int)HttpStatusCode.InternalServerError)
            {
                errorDetails = new
                {
                    StatusCode = httpContext.Response.StatusCode,
                    Message = "An unexpected error occurred.",
                    Details = string.Empty
                };
            }

            var response = JsonConvert.SerializeObject(errorDetails);

            return httpContext.Response.WriteAsync(response);
        }
    }
}
