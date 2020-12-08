using Identity.Domain.Interfaces.Repository;
using Identity.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public virtual async Task<T> GetByIdAsync(object id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public virtual async Task<T> InsertAsync(T entidade)
        {
            return await _repository.InsertAsync(entidade);
        }

        public virtual async Task<T> UpdateAsync(T entidade)
        {
            return await _repository.UpdateAsync(entidade);
        }
        public virtual async Task<T> DeleteAsync(T entidade)
        {
            return await _repository.DeleteAsync(entidade);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
