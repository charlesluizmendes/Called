using Called.Domain.Entities;
using Called.Domain.Interfaces.Repository;
using Called.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Called.Domain.Services
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
