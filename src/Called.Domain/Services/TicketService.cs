using Called.Domain.Entities;
using Called.Domain.Interfaces.Repository;
using Called.Domain.Interfaces.Sender.EventBus;
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
        private readonly ITicketCreateSender _ticketCreateSender;
        private readonly IHubService _chatHubService;

        public TicketService(ITicketRepository ticketRepository,
            ITicketCreateSender ticketCreateSender,
            IHubService chatHubService)
            : base(ticketRepository)
        {
            _chatHubService = chatHubService;
            _ticketCreateSender = ticketCreateSender;
            _ticketRepository = ticketRepository;
        }

        public override async Task<Ticket> InsertAsync(Ticket entity)
        {
            var ticket = await _ticketRepository.InsertAsync(entity);

            if (ticket != null)
            {
                _ticketCreateSender.SendTicket(ticket);
                await _chatHubService.SendMessageAsync(ticket.Email, ticket.Complaint);
            }           

            return ticket;
        }
    }
}
