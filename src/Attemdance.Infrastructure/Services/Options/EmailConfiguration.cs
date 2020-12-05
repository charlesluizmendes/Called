using System;
using System.Collections.Generic;
using System.Text;

namespace Attemdance.Infrastructure.Service.Options
{
    public class EmailConfiguration
    {
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUser { get; set; }
        public string SmtpPass { get; set; }
    }
}
