using System;
using System.Threading.Tasks;
using Core.DataAccess;
using Microsoft.AspNetCore.Http;

namespace API.Middleware
{
    public class EntityMiddleware
    {
        private readonly RequestDelegate _next;

        public EntityMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, RecordStoreContext db)
        {
            try
            {
                await _next(context);
                await db.SaveChangesAsync();
            }
            catch
            {
                Console.WriteLine("save changes failed");
                throw;
            }
        }
    }
}