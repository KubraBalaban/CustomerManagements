using CustomerManagementAPI.App.Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;
using FluentValidation;

namespace CustomerManagementAPI.App.Middleware
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var statusCode = httpContext.Response.StatusCode;

            _logger.LogError(ex, " --- Unhandled Exception");

            string message = "Internal Server Error";
            if (ex.GetType() == typeof(ValidationException))
            {
                ValidationException e = (ValidationException)ex;
                message = e.Errors.Any() ? string.Empty : message;
                foreach (var item in e.Errors)
                {
                    message += item.ErrorMessage + " \r\n ";
                }
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }

            var result = ResponseModel<string>.Fail(message);
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(result, serializerSettings));
        }
    }
}

