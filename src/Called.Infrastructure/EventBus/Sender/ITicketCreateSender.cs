using Called.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Called.Infrastructure.EventBus.Sender
{
    public interface ITicketCreateSender
    {
        void SendTicket(Ticket ticket);
    }
}
