using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Attemdance.Domain.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> InsertAsync(T entity);        

        void Dispose();
    }
}
