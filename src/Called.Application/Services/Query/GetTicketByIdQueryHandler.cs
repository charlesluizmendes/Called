using Called.Domain.Entities;
using Called.Domain.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Called.Application.Services.Query
{
    public class GetTicketByIdQueryHandler : IRequestHandler<GetTicketByIdQuery, Ticket>
    {
        private readonly ITicketService _ticketService;

        public GetTicketByIdQueryHandler(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public async Task<Ticket> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
        {
            return await _ticketService.GetByIdAsync(request.Id);
        }
    }
}
