using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            // catch (RecordStoreException ex)
            // {
            //     Console.WriteLine($"{ex.GetType()}\n{ex.Message}\nPath {ex.Path}.{ex.Method}");
            //     context.Response.StatusCode = 418;
            //     context.Response.Headers.Add("content-type", "application/json");
            //     await context.Response.WriteAsync(new RecordStoreExceptionModel(ex).ToString());
            // }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.GetType()}\n{ex.Message}\n{ex.StackTrace}");
                context.Response.StatusCode = 500;
                context.Response.Headers.Add("content-type", "application/json");
                await context.Response.WriteAsync(ex.ToString());
            }
        }
    }
}
