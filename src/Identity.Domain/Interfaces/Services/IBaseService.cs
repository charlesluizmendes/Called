using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Interfaces.Services
{
    public interface IBaseService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(object id);

        Task<T> InsertAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<T> DeleteAsync(T entity);

        void Dispose();
    }
}
