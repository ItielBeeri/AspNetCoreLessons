using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAspNetCoreExample
{
    public class LinksModifierMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await next(context);

            await AlterLinks(context.Response);
        }

        private async Task AlterLinks(HttpResponse response)
        {
            await response.WriteAsync("\n\nHello from links modifier!!!");
        }
    }
}
