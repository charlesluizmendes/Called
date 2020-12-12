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

        Task<User> DeleteUserAsync(User user);

        Task<User> GetUserByLoginAsync(User user);

        void Dispose();
    }
}
