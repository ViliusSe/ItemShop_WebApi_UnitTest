using _20231220_EntityFrameworkCore_ItemShop_WebApi.Exeptions;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Reflection;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace _20231220_EntityFrameworkCore_ItemShop_WebApi.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;


        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                // log the error

                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case ItemNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case NotFoundException:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case CreateItemException e:
                        response.StatusCode = (int)HttpStatusCode.Conflict;
                        break;
                    case CanNotCreateItemExeptio e:
                        response.StatusCode = (int)HttpStatusCode.Conflict;
                        return;
                    case KeyNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        _logger.LogError(error, error.Message);
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                var result = JsonSerializer.Serialize(new { message = error?.Message });
                await response.WriteAsync(result);
            }
        }
    }
}
