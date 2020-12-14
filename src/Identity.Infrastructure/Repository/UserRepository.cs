using Identity.Domain.Entities;
using Identity.Domain.Extensions;
using Identity.Domain.Interfaces.Repository;
using Identity.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Repository
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private readonly UserManager<User> _userManager;

        public UserRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            try
            {
                return await _userManager.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            try
            {
                return await _userManager.FindByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> InsertUserAsync(User user)
        {
            try
            {
                var result = await _userManager.CreateAsync(user, user.PasswordHash);

                if (result.Succeeded)
                {
                    return user;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            try
            {
                var _user = await _userManager.FindByIdAsync(user.Id);               

                if (_user != null)
                {
                    _user.UserName = user.UserName;
                    _user.Email = user.Email;
                    _user.PasswordHash = user.PasswordHash;

                    var result = await _userManager.UpdateAsync(_user);

                    if (result.Succeeded)
                    {
                        return user;
                    }

                    return null;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> DeleteUserAsync(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);

                if (user != null)
                {
                    var result = await _userManager.DeleteAsync(user);

                    if (result.Succeeded)
                    {
                        return user;
                    }
                }                

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> GetUserByEmailAsync(User user)
        {
            try
            {
               return await _userManager.Users.FirstOrDefaultAsync(x =>
                    x.Email.Equals(user.Email));                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Dispose

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _userManager.Dispose();
                }
            }

            this.disposed = true;
        }

        #endregion
    }
}
