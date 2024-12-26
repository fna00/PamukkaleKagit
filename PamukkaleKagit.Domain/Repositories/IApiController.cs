using PamukkaleKagit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Domain.Repositories
{
    public interface IApiController<T> where T : BaseEntity
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> Get(int id);
        public Task<T> Post(T entity);
        public Task<T> Put(T entity);
        public Task<T> Delete(int id);
    }
}
