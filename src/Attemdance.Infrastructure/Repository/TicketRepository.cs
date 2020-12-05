using Attemdance.Domain.Entities;
using Attemdance.Domain.Interfaces.Repository;
using Attemdance.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attemdance.Infrastructure.Repository
{
    public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
    {
        private readonly AttemdanceContext _context;

        public TicketRepository(AttemdanceContext context)
            : base (context)
        {
            _context = context;
        }
    }
}
