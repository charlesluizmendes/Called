using Called.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Called.Domain.Interfaces.Sender.EventBus
{
    public interface ITicketCreateSender
    {
        void SendMessage(Ticket ticket);
    }
}
