using Attemdance.Domain.Entities;
using Attemdance.Domain.Interfaces.Repository;
using Attemdance.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attemdance.Domain.Services
{
    public class TicketService : BaseService<Ticket>, ITicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
            : base(ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
    }
}
