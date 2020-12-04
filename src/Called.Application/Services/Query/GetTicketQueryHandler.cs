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
    public class GetTicketQueryHandler : IRequestHandler<GetTicketQuery, IEnumerable<Ticket>>
    {
        private readonly ITicketService _ticketService;

        public GetTicketQueryHandler(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public async Task<IEnumerable<Ticket>> Handle(GetTicketQuery request, CancellationToken cancellationToken)
        {
            return await _ticketService.GetAllAsync();
        }
    }
}
