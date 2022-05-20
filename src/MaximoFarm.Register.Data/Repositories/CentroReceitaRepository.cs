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
    public class CentroReceitaRepository :
        IGenericRepository<CentroReceita>,
        ICacheRepository<CentroReceita>,
        IDisposable
    {
        private readonly RegisterContext _context;
        private readonly DbSet<CentroReceita> _dbSet;
        private readonly IDistributedCache _cache;
        public CentroReceitaRepository(RegisterContext context, IDistributedCache cache)
        {
            _context = context;
            _dbSet = _context.Set<CentroReceita>();
            _cache = cache;
        }
       
        public void Insert(CentroReceita entity)
        {
            _dbSet.AddAsync(entity);
        }
        public void Update(CentroReceita entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        public async Task<CentroReceita> Delete(int codigo)
        {
            var entity = await _dbSet.AsNoTracking().Where(p => p.CodCentroReceita == codigo).FirstOrDefaultAsync();
            var response = entity is not null ? _dbSet.Remove(entity) : throw new Exception();//==> será tratado ainda! 

            return entity;
        }
        public async Task<List<CentroReceita>> GetAll()
        {
            var key = typeof(CentroReceita).Name.ToLower() + ":" + GetType().Name.ToString();
            var response = await IsCached(key);
            if (!response)
            {
                var entity = await _dbSet.AsNoTracking().ToListAsync();
                await SendByCache(key, entity);
                return entity;
            }
            return await GetByCache(key);
        }
        public async Task<List<CentroReceita>> GetByCode(int codigo)
        {
            var key = typeof(CentroReceita).Name.ToLower() + ":" + codigo.ToString() + ":" + GetType().Name.ToString();
            var response = await IsCached(key);
            if (!response)
            {
                var entity = await _dbSet.AsNoTracking().Where(p => p.CodCentroReceita == codigo).ToListAsync();
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
        public async Task<List<CentroReceita>> GetByCache(string key)
        {
            var response = await _cache.GetStringAsync(key);

            return JsonSerializer.Deserialize<List<CentroReceita>>(response);
        }
        public async Task SendByCache(string key, List<CentroReceita> entity)
        {
            var serializedObject = JsonSerializer.Serialize(entity);
            var expirationTime = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15),
                SlidingExpiration = TimeSpan.FromMinutes(12)
            };
            await _cache.SetStringAsync(key, serializedObject, expirationTime);
        }
        public async Task SendByCache(string key, CentroReceita entity)
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
