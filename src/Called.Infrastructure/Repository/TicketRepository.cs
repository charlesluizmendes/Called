using Called.Domain.Entities;
using Called.Domain.Interfaces.Repository;
using Called.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Called.Infrastructure.Repository
{
    public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
    {
        private readonly CalledContext _context;

        public TicketRepository(CalledContext context)
            : base (context)
        {
            _context = context;
        }
    }
}
