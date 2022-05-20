using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Data.Cache
{
    public interface ICacheRepository<T> where T : class
    {
        Task<List<T>> GetByCache(string key) ;
        Task SendByCache(string key, List<T> entity) ;
        Task SendByCache(string key, T entity);
        Task<bool> IsCached(string key) ;
        //Task RemoveByCache<T>(string key, T entity) where T : class;
    }
}
