using Caching.Demo.Api.Data;
using Caching.Demo.Api.Repositories;
using Caching.Demo.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Caching.Demo.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            }
            );

            services.AddScoped<StoreDataContext, StoreDataContext>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductService, ProductService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
