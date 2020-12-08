using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Domain.Entities
{
    public class AcessToken
    {
        public string Token { get; set; }

        public DateTime TokenExpires { get; set; }
    }
}
