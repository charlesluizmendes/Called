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

        public override async Task<Ticket> InsertAsync(Ticket ticket)
        {
            var _ticket = await _ticketRepository.InsertAsync(ticket);

            if (_ticket != null)
            {
                await _ticketCreateSender.SendMessageAsync(ticket);
                await _chatHubService.SendChatAsync(ticket.Email, ticket.Complaint);

                return _ticket;
            }           

            return null;
        }
    }
}
