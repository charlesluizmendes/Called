using Identity.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Application.Services.Command
{
    public class CreateUserCommand : IRequest<User>
    {
        public User User { get; set; }
    }
}
