using Identity.Domain.Entities;
using Identity.Domain.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.Application.Services.Query
{
    public class GetAcessTokenByLoginQueryHandler : IRequestHandler<GetAcessTokenByLoginQuery, AcessToken>
    {
        private readonly IUserService _userService;

        public GetAcessTokenByLoginQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<AcessToken> Handle(GetAcessTokenByLoginQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetAcessTokenByLoginAsync(request.User);
        }
    }
}
