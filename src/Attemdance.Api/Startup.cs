using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attemdance.Infrastructure.Context;
using Attemdance.Infrastructure.EventBus.Options;
using Attemdance.Infrastructure.IoC;
using Attemdance.Infrastructure.Service.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Attemdance.Api
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

            services.AddDbContext<AttemdanceContext>(option =>
                 option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            // RabbitMQ

            services.AddOptions();

            services.Configure<RabbitMqConfiguration>(Configuration.GetSection("RabbitMq"));

            // Email

            services.Configure<EmailConfiguration>(Configuration.GetSection("Email"));

            // IoC

            InjectorDependency.Register(services);

            // Swagger

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Microservice Attemdance",
                    Description = "Microservice of Attemdance",
                    Version = "v1"
                });
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // Swagger

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Microservice Attemdance");
            });

            app.UseRouting();            

            app.UseAuthorization();            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();               
            });
        }
    }
}
