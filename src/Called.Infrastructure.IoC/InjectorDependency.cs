using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using MediatR;
using Called.Application.Services.Query;
using Called.Domain.Entities;
using Called.Application.Services.Command;
using Called.Domain.Interfaces.Repository;
using Called.Domain.Interfaces.Services;
using Called.Infrastructure.Repository;
using Called.Domain.Services;
using Called.Infrastructure.EventBus.Sender;

namespace Called.Infrastructure.IoC
{
    public class InjectorDependency
    {
        public static void Register(IServiceCollection container)
        {
            // Application

            container.AddMediatR(Assembly.GetExecutingAssembly());
            container.AddTransient<IRequestHandler<GetTicketQuery, IEnumerable<Ticket>>, GetTicketQueryHandler>();
            container.AddTransient<IRequestHandler<GetTicketByIdQuery, Ticket>, GetTicketByIdQueryHandler>();
            container.AddTransient<IRequestHandler<CreateTicketCommand, Ticket>, CreateTicketCommandHandler>();           

            // Domain

            container.AddTransient(typeof(IBaseService<>), typeof(BaseService<>));
            container.AddTransient<ITicketService, TicketService>();

            // Infrastructure            

            container.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            container.AddTransient<ITicketRepository, TicketRepository>();

            container.AddTransient<ITicketCreateSender, TicketCreateSender>();
        }
    }
}
