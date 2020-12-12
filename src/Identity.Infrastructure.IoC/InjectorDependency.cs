using FluentValidation;
using Identity.Application.Dto;
using Identity.Application.Services.Command;
using Identity.Application.Services.Query;
using Identity.Application.Validators;
using Identity.Domain.Entities;
using Identity.Domain.Interfaces.Repository;
using Identity.Domain.Interfaces.Services;
using Identity.Domain.Services;
using Identity.Infrastructure.Repository;
using Identity.Infrastructure.Services.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Identity.Infrastructure.IoC
{
    public class InjectorDependency
    {
        public static void Register(IServiceCollection container)
        {
            // Application

            container.AddMediatR(Assembly.GetExecutingAssembly());
            container.AddTransient<IRequestHandler<GetAcessTokenByLoginQuery, AcessToken>, GetAcessTokenByLoginQueryHandler>();
            container.AddTransient<IRequestHandler<GetUserQuery, IEnumerable<User>>, GetUserQueryHandler>();
            container.AddTransient<IRequestHandler<GetUserByIdQuery, User>, GetUserByIdQueryHandler>();
            container.AddTransient<IRequestHandler<CreateUserCommand, User>, CreateUserCommandHandler>();
            container.AddTransient<IRequestHandler<UpdateUserCommand, User>, UpdateUserCommandHandler>();
            container.AddTransient<IRequestHandler<DeleteUserCommand, User>, DeleteUserCommandHandler>();

            // Domain

            container.AddTransient<IUserService, UserService>();

            // Infrastructure            

            container.AddTransient<IUserRepository, UserRepository>();
            container.AddTransient<ITokenService, TokenService>();

            // Validator

            container.AddTransient<IValidator<GetAcessTokenDto>, GetAcessTokenValidator>();
            container.AddTransient<IValidator<UpdateUserDto>, UpdateUserValidator>();
            container.AddTransient<IValidator<CreateUserDto>, CreateUserValidator>();           
        }
    }
}
