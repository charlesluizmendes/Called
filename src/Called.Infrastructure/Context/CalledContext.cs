using Called.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace Called.Infrastructure.Context
{
    public class CalledContext : DbContext, IDisposable
    {
        public virtual DbSet<Ticket> Ticket { get; set; }

        public CalledContext(DbContextOptions<CalledContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Ticket>(e =>
            {
                e.ToTable("Ticket");
                e.Property(p => p.DateHour).ValueGeneratedOnAddOrUpdate().HasComputedColumnSql("GETDATE()");
                e.Property(p => p.DateHour).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
            });
        }
    }
}
