using Attemdance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attemdance.Infrastructure.Context
{
    public class AttemdanceContext : DbContext, IDisposable
    {
        public virtual DbSet<Ticket> Ticket { get; set; }

        public AttemdanceContext(DbContextOptions<AttemdanceContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Ticket>(e =>
            {
                e.ToTable("Ticket");
                e.Property(p => p.DateHour).HasDefaultValueSql("GETDATE()");
            });
        }
    }
}
