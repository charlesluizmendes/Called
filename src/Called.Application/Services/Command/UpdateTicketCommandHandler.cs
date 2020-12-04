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
    public class UpdateTicketCommandHandler : IRequestHandler<UpdateTicketCommand, Ticket>
    {
        private readonly ITicketService _ticketService;

        public UpdateTicketCommandHandler(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public async Task<Ticket> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
        {
            return await _ticketService.UpdateAsync(request.Ticket);
        }
    }
}
