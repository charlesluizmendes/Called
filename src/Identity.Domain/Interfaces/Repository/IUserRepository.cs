using Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();

        Task<User> GetUserByIdAsync(string id);

        Task<User> InsertUserAsync(User user);

        Task<User> UpdateUserAsync(User user);

        Task<User> DeleteUserAsync(string id);

        Task<User> GetUserByEmailAsync(User user);

        void Dispose();
    }
}
