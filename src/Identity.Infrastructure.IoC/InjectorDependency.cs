using Identity.Domain.Interfaces.Repository;
using Identity.Domain.Interfaces.Services;
using Identity.Domain.Services;
using Identity.Infrastructure.Repository;
using Identity.Infrastructure.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Infrastructure.IoC
{
    public class InjectorDependency
    {
        public static void Register(IServiceCollection container)
        {
            // Application

            

            // Domain

            container.AddTransient(typeof(IBaseService<>), typeof(BaseService<>));
            container.AddTransient<IUserService, UserService>();

            // Infrastructure            

            container.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            container.AddTransient<IUserRepository, UserRepository>();

            container.AddTransient<ITokenService, TokenService>();
        }
    }
}
