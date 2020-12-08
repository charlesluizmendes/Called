using Called.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Called.Domain.Interfaces.Sender.EventBus
{
    public interface ITicketCreateSender
    {
        Task SendMessageAsync(Ticket ticket);
    }
}
