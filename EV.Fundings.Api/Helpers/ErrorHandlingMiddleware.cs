using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV.Fundings.Api.Helpers
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IHostingEnvironment env;
        private readonly ILogger<ErrorHandlingMiddleware> logger;
        public ErrorHandlingMiddleware(RequestDelegate _next, IHostingEnvironment _env, ILogger<ErrorHandlingMiddleware> _logger)
        {

            next = _next;
            env = _env;
            logger = _logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext == null) throw new ArgumentNullException(nameof(httpContext));
            var errorMsg = "";
            Exception exception = new Exception($"Exception occurred.!");
            try
            {
                await next.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                exception = ex;

                if (!httpContext.Response.HasStarted)
                {
                    logger.LogError(ex, $"Exception occurred.!");
                    httpContext.Response.ContentType = "application/json";
                    var traceId = httpContext.TraceIdentifier.Replace(":", "");
                    var apiErrorResponse = new object();
                    apiErrorResponse = "Internal Server Error Occourred. Trace Id: " + traceId;
                    if (env.IsDevelopment())
                    {
                        apiErrorResponse = new { traceId, ex.Message, ex.StackTrace };
                    }
                    var json = JsonConvert.SerializeObject(apiErrorResponse);
                    httpContext.Response.StatusCode = 500;
                    await httpContext.Response.WriteAsync(json);
                }
            }

        }
    }
}
