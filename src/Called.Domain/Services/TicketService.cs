using Called.Domain.Entities;
using Called.Domain.Interfaces.Repository;
using Called.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Called.Domain.Services
{
    public class TicketService : BaseService<Ticket>, ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IChatHubService _chatHubService;

        public TicketService(ITicketRepository ticketRepository,
            IChatHubService chatHubService)
            : base(ticketRepository)
        {
            _chatHubService = chatHubService;
            _ticketRepository = ticketRepository;
        }

        public override async Task<Ticket> InsertAsync(Ticket entity)
        {
            var ticket = await _ticketRepository.InsertAsync(entity);

            if (ticket != null)
            {
                await _chatHubService.SendMessage(ticket.Email, ticket.Complaint);
            }           

            return ticket;
        }
    }
}
