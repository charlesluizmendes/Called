using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Application.Dto
{
    public class CreateUserDto
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
