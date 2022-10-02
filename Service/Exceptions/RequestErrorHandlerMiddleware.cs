using Business.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Service.Exceptions
{
    public class RequestErrorHandlerMiddleware : ControllerBase
    {
        private readonly RequestDelegate next;

        private readonly ILogger<RequestErrorHandlerMiddleware> logger;

        public RequestErrorHandlerMiddleware(RequestDelegate next, ILogger<RequestErrorHandlerMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected

            if (ex is TypeInitializationException)
            {
                ex = ex.GetBaseException();
            }

            switch (ex)
            {
                case UnauthorizedAccessException:
                case NotAuthenticatedException:
                    code = HttpStatusCode.Unauthorized;
                    context.Response.Headers.Add("WWW-Authenticate", "Basic");
                    break;

                case ForbiddenException:
                    code = HttpStatusCode.Forbidden;
                    break;

                case NotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;

                default:
                    logger.LogError(ex.Message);
                    logger.LogDebug(ex.StackTrace);
                    break;
            }

            var result = JsonConvert.SerializeObject(new { error = ex.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }
    }
}