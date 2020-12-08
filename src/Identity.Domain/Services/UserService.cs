using Identity.Domain.Entities;
using Identity.Domain.Interfaces.Repository;
using Identity.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public UserService(IUserRepository userRepository,
            ITokenService tokenService)
            : base(userRepository)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<AcessToken> GetTokenByEmailAsync(User user)
        {
            var _user = await _userRepository.GetUserByLoginAsync(user);

            if (_user != null)
            {
                var token = await _tokenService.CreateTokenByEmailAsync(user);

                return token;
            }

            return null;
        }
    }
}
