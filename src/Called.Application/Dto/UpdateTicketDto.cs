using System;
using System.Collections.Generic;
using System.Text;

namespace Called.Application.Dto
{
    public class UpdateTicketDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Complaint { get; set; }
    }
}
