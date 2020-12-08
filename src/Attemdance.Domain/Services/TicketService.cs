using Attemdance.Domain.Entities;
using Attemdance.Domain.Interfaces.Repository;
using Attemdance.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Attemdance.Domain.Services
{
    public class TicketService : BaseService<Ticket>, ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IEmailService _emailService;

        public TicketService(ITicketRepository ticketRepository,
            IEmailService emailService)
            : base(ticketRepository)
        {
            _ticketRepository = ticketRepository;
            _emailService = emailService;
        }

        public override async Task<Ticket> InsertAsync(Ticket ticket)
        {
            var _ticket = await _ticketRepository.InsertAsync(ticket);

            if (_ticket != null)
            {
                await _emailService.SendAsync("no-replay@called.com",
                    ticket.Email,
                    "Called",
                    ticket.Complaint);

                return _ticket;
            }

            return null;
        }
    }
}
