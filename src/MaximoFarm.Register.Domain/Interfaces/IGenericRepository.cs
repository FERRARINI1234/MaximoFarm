using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        void Insert(T entity);

        void Update(T entity);

        Task<T> Delete(int codigo);

        Task<List<T>> GetAll();

        Task<List<T>> GetByCode(int codigo);
    }
}
