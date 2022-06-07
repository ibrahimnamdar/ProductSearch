using System.Net;
using System.Text.Json;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using ProductSearch.Infrastructure.Base;

namespace ProductSearch.Application.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }


        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (exception.GetType() == typeof(ValidationException))
            {
                var code = HttpStatusCode.BadRequest;
                var result = JsonSerializer.Serialize(((ValidationException)exception).Errors.Select(x=>new ValidationError {PropertyName = x.PropertyName, ErrorMessage = x.ErrorMessage}));
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)code;
                return context.Response.WriteAsync(result);
            }
            
            throw exception;
        }
    }
}