using Identity.Domain.Entities;
using Identity.Domain.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Infrastructure.Context
{
    public class IdentityContext : IdentityDbContext<User>
    {
        public virtual DbSet<User> User { get; set; }

        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().HasData(
                new User
                {
                    Email = "charlesluizmendes@gmail.com",
                    PasswordHash = HasherExtension.HashPassword("123"),
                });
        }
    }
}
