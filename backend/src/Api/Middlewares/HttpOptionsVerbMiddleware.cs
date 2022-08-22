using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Middlewares
{
    public class HttpOptionsVerbMiddleware
    {
        readonly RequestDelegate next;

        public HttpOptionsVerbMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public Task Invoke(HttpContext context)
        {
            return BeginInvoke(context);
        }

        Task BeginInvoke(HttpContext context)
        {
            if (context.Request.Method == "OPTIONS")
            {
                context.Response.Headers.Add("Access-Control-Allow-Origin", new[] { (string)context.Request.Headers["Origin"] });
                context.Response.Headers.Add("Access-Control-Allow-Headers", new[] { "Origin, X-Requested-With, Content-Type, Accept" });
                context.Response.Headers.Add("Access-Control-Allow-Methods", new[] { "GET, POST, PUT, DELETE, OPTIONS" });
                context.Response.Headers.Add("Access-Control-Allow-Credentials", new[] { "true" });
                context.Response.StatusCode = 200;
                return context.Response.WriteAsync("OK");
            }

            return next.Invoke(context);
        }
    }
    public static class OptionsMiddlewareExtensions
    {
        public static IApplicationBuilder UseOptions(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HttpOptionsVerbMiddleware>();
        }
    }
}