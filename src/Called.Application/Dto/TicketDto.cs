using System;
using System.Collections.Generic;
using System.Text;

namespace Called.Application.Dto
{
    public class TicketDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Complaint { get; set; }

        public DateTime DateHour { get; set; }
    }
}
