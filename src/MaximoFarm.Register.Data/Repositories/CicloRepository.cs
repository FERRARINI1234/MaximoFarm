using MaximoFarm.Register.Data.Cache;
using MaximoFarm.Register.Data.Context;
using MaximoFarm.Register.Data.UnitOfWork;
using MaximoFarm.Register.Domain.Entities;
using MaximoFarm.Register.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Data.Repositories
{
    public class CicloRepository :
        IGenericRepository<Ciclo>,
        ICacheRepository<Ciclo>,
        IDisposable
    {
        private readonly RegisterContext _context;
        private readonly DbSet<Ciclo> _dbset;
        private readonly IDistributedCache _cache;

        public CicloRepository(RegisterContext context, IDistributedCache cache)
        {
            _context = context;
            _dbset = _context.Set<Ciclo>();
            _cache = cache;
        }
        public void Insert(Ciclo entity)
        {
             _dbset.AddAsync(entity);
        }
        public void Update(Ciclo entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        public async Task<Ciclo> Delete(int codigo)
        {
            var entity = await _dbset.AsNoTracking().Where(p => p.CodCiclo == codigo).FirstOrDefaultAsync();
            var response = entity is not null ? _dbset.Remove(entity) : throw new Exception();//==> será tratado ainda! 

            return entity;
        }
        public async Task<List<Ciclo>> GetAll()
        {
            var key = typeof(Ciclo).Name.ToLower() + ":" + GetType().Name.ToString();
            var response = await IsCached(key);
            if (!response)
            {
                var entity = await _dbset.AsNoTracking().ToListAsync();
                await SendByCache(key, entity);
                return entity;
            }
            return await GetByCache(key);
        }
        public async Task<List<Ciclo>> GetByCode(int codigo)
        {
            var key = typeof(Ciclo).Name.ToLower() + ":" + codigo.ToString() + ":" + GetType().Name.ToString();
            var response = await IsCached(key);
            if (!response)
            {
                var entity = await _dbset.AsNoTracking().Where(p => p.CodCiclo == codigo).ToListAsync();
                await SendByCache(key, entity);
                return entity;
            }
            return await GetByCache(key);
        }
        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }
        public async Task<List<Ciclo>> GetByCache(string key)
        {
            var response = await _cache.GetStringAsync(key);

            return JsonSerializer.Deserialize<List<Ciclo>>(response);
        }
        public async Task SendByCache(string key, List<Ciclo> entity)
        {
            var serializedObject = JsonSerializer.Serialize(entity);
            var expirationTime = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15),
                SlidingExpiration = TimeSpan.FromMinutes(12)
            };
            await _cache.SetStringAsync(key, serializedObject, expirationTime);
        }
        public async Task SendByCache(string key, Ciclo entity)
        {
            var serializedObject = JsonSerializer.Serialize(entity);
            var expirationTime = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15),
                SlidingExpiration = TimeSpan.FromMinutes(12)
            };
            await _cache.SetStringAsync(key, serializedObject, expirationTime);
        }
        public async Task<bool> IsCached(string key)
        {
            var response = await _cache.GetStringAsync(key);
            if (!string.IsNullOrWhiteSpace(response)) return true;
            return false;
        }
    }
}
