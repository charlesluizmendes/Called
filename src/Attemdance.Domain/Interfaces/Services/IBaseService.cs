using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Attemdance.Domain.Interfaces.Services
{
    public interface IBaseService<T> where T : class
    {        
        Task<T> InsertAsync(T entity);     

        void Dispose();
    }
}
