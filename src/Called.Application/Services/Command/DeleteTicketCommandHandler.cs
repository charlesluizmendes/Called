using Called.Domain.Entities;
using Called.Domain.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Called.Application.Services.Command
{
    public class DeleteTicketCommandHandler : IRequestHandler<DeleteTicketCommand, Ticket>
    {
        private readonly ITicketService _ticketService;

        public DeleteTicketCommandHandler(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public async Task<Ticket> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
        {
            return await _ticketService.DeleteAsync(request.Ticket);
        }
    }
}
