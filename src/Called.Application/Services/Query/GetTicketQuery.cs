using Called.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Called.Application.Services.Query
{
    public class GetTicketQuery : IRequest<IEnumerable<Ticket>>
    {       
    }
}
