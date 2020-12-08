using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Application.Dto
{
    public class AcessTokenDto
    {
        public string Token { get; set; }

        public DateTime TokenExpires { get; set; }
    }
}
