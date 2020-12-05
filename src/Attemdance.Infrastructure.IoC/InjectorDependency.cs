using Attemdance.Domain.Interfaces.Repository;
using Attemdance.Domain.Interfaces.Services;
using Attemdance.Domain.Services;
using Attemdance.Infrastructure.EventBus.Receiver;
using Attemdance.Infrastructure.Repository;
using Attemdance.Infrastructure.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attemdance.Infrastructure.IoC
{
    public class InjectorDependency
    {
        public static void Register(IServiceCollection container)
        {
            // Domain

            container.AddTransient(typeof(IBaseService<>), typeof(BaseService<>));
            container.AddTransient<ITicketService, TicketService>();

            // Infrastructure 

            container.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            container.AddTransient<ITicketRepository, TicketRepository>();

            container.AddHostedService<TicketCreateReceiver>();

            container.AddTransient<IEmailService, EmailService>();
        }
    }
}
