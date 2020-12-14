using Identity.Domain.Entities;
using Identity.Domain.Extensions;
using Identity.Domain.Interfaces.Repository;
using Identity.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public UserService(IUserRepository userRepository,
            ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }        

        public async Task<User> InsertUserAsync(User user)
        {
            user.PasswordHash = HasherExtension.HashPassword(user, 
                user.PasswordHash);

            return await _userRepository.InsertUserAsync(user);
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            user.PasswordHash = HasherExtension.HashPassword(user, 
                user.PasswordHash);

            return await _userRepository.UpdateUserAsync(user);
        }

        public async Task<User> DeleteUserAsync(string id)
        {
            return await _userRepository.DeleteUserAsync(id);
        }

        public async Task<AcessToken> GetAcessTokenByLoginAsync(User user)
        {
            var _user = await _userRepository.GetUserByEmailAsync(user);

            if (_user != null)
            {
                var result = HasherExtension.VerifyHashedPassword(_user,
                    _user.PasswordHash, user.PasswordHash);

                if (result)
                {
                    return await _tokenService.CreateTokenByEmailAsync(_user);
                }
            }

            return null;
        }

        public void Dispose()
        {
            _userRepository.Dispose();
        }
    }
}
