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

        public override async Task<Ticket> InsertAsync(Ticket entity)
        {
            var ticket = await _ticketRepository.InsertAsync(entity);

            if (ticket != null)
            {
                await _emailService.SendAsync(
                    "noreplay@ticket.com",
                    ticket.Email,
                    "Attemdance",
                    ticket.Complaint
                    );
            }

            return ticket;
        }
    }
}
