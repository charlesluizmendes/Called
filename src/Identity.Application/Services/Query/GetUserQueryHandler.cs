using Identity.Domain.Entities;
using Identity.Domain.Interfaces.Repository;
using Identity.Domain.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.Application.Services.Query
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, IEnumerable<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUsersAsync();
        }
    }
}
