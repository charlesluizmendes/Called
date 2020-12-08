using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.Infrastructure.Context;
using Identity.Infrastructure.IoC;
using Identity.Infrastructure.Services.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Identity.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Context

            services.AddDbContext<IdentityContext>(option =>
                 option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            // IoC

            InjectorDependency.Register(services);

            // JWT

            services.Configure<AudienceConfiguration>(Configuration.GetSection("Audience"));

            services.AddControllers();           
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
