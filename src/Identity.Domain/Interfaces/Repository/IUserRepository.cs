using Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Interfaces.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUserAsync(User user);
    }
}
