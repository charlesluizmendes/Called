using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Called.Application.AutoMapper;
using Called.Infrastructure.Context;
using Called.Infrastructure.EventBus.Options;
using Called.Infrastructure.IoC;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Called.Api
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

            services.AddDbContext<CalledContext>(option =>
                 option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            // RabbitMQ

            services.AddOptions();

            services.Configure<RabbitMqConfiguration>(Configuration.GetSection("RabbitMq"));

            // IoC

            InjectorDependency.Register(services);

            // AutoMapper

            services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));

            // JWT

            var audienceConfig = Configuration.GetSection("Audience");

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = "Token";
            })
            .AddJwtBearer("Token", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = audienceConfig["Iss"],
                    ValidAudience = audienceConfig["Aud"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(audienceConfig["Secret"])),
                    ClockSkew = TimeSpan.Zero,
                    RequireExpirationTime = true
                };
            });

            // Cors

            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder
                    .WithOrigins("https://localhost:12345")
                    .AllowAnyHeader()
                    .WithMethods("GET", "POST")
                    .AllowCredentials();
            }));

            // WebSocket

            services.AddSignalR();

            // Swagger

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Microservice Called",
                    Description = "Microservice of Called",
                    Version = "v1"
                });
            });

            // Fluent Validation

            services.AddControllers().AddFluentValidation();
        }

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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Microservice Called");
            });

            app.UseRouting();

            // JWT

            app.UseAuthentication();

            app.UseAuthorization();

            // Cors

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                // WebSocket

                endpoints.MapHub<Hub>("/chathub");
            });
        }
    }
}
