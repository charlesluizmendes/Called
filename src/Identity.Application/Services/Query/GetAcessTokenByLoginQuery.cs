using Identity.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Application.Services.Query
{
    public class GetAcessTokenByLoginQuery : IRequest<AcessToken>
    {
        public User User { get; set; }
    }
}
