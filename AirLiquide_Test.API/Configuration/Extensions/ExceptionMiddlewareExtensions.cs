using AirLiquide_Test.API.Configuration.ErrorResponses;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;

namespace AirLiquide_Test.API.Configuration.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        ErrorResponse errorResponse = new(contextFeature.Error.Message);
                        string response = JsonConvert.SerializeObject(errorResponse);

                        await context.Response.WriteAsync(response);
                    }
                });
            });
        }
    }
}