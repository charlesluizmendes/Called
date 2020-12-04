using Called.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Called.Application.Services.Command
{
    public class CreateTicketCommand : IRequest<Ticket>
    {
        public Ticket Ticket { get; set; }
    }
}
