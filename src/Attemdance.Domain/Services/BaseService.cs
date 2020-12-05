using Attemdance.Domain.Interfaces.Repository;
using Attemdance.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Attemdance.Domain.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }    

        public virtual async Task<T> InsertAsync(T entidade)
        {
            return await _repository.InsertAsync(entidade);
        }     

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
