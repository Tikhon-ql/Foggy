using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foggy.DataProvider.Interfaces
{
    public interface IRepository<T>
    {
        Task Create(T entity);
        Task<T?> GetById(Guid id);
        Task Delete(Guid id);
        Task<List<T>> GetAll();
    }
}
