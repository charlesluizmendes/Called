using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Infrastructure.Services.Options
{
    public class AudienceConfiguration
    {
        public string Secret { get; set; }

        public string Iss { get; set; }

        public string Aud { get; set; }
    }
}
