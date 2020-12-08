using Identity.Domain.Entities;
using Identity.Domain.Extensions;
using Identity.Domain.Interfaces.Repository;
using Identity.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly IdentityContext _context;

        public UserRepository(IdentityContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<User> GetUserByLoginAsync(User user)
        {
            var _user = await _context.Users.FirstOrDefaultAsync(x => x.Email.Equals(user.Email));

            var result = HasherExtension.VerifyHashedPassword(_user.PasswordHash, user.PasswordHash);

            if (result)
            {
                return _user;
            }

            return null;
        }
    }
}
