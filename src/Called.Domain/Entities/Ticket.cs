using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Called.Domain.Entities
{
    public class Ticket
    {
        [Key]
        public virtual Guid Id { get; set; }

        [Required]
        public virtual string Name { get; set; }

        [Required]
        public virtual string Email { get; set; }

        [Required]
        public virtual string Complaint { get; set; }

        public virtual DateTime DateHour { get; set; }
    }
}
