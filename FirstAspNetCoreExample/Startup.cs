using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace FirstAspNetCoreExample
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<AuthorizationMiddlware>();
            services.AddSingleton<LinksModifierMiddleware>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<AuthorizationMiddlware>();

            app.UseMiddleware<LinksModifierMiddleware>();


            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
                foreach (var header in context.Request.Headers)
                {
                    await context.Response.WriteAsync($"header name: '{header.Key}', value: '{header.Value}'");
                }
            });
        }
    }
}
