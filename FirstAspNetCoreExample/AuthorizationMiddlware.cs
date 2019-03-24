using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAspNetCoreExample
{
    public class AuthorizationMiddlware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            bool isAllowed = IsUserAllowed(context);

            if (isAllowed)
            {
                await next(context);
            }
            else
            {
                Write403Response(context);
            }
        }

        private bool IsUserAllowed(HttpContext context)
        {
            return true;
        }

        private void Write403Response(HttpContext context)
        {
            throw new NotImplementedException();
        }
    }
}
