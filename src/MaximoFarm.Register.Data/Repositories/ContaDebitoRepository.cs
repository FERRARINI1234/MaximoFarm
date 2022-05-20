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
    public class ContaDebitoRepository : 
        IGenericRepository<ContaDebito>,
        ICacheRepository<ContaDebito>, 
        IDisposable
    {
        private readonly RegisterContext _context;
        private readonly DbSet<ContaDebito> _dbSet;
        private readonly IDistributedCache _cache;
        public ContaDebitoRepository(RegisterContext context, IDistributedCache cache)
        {
            _context = context;
            _dbSet = _context.Set<ContaDebito>();
            _cache = cache;
        }
        public void Insert(ContaDebito entity)
        {
            _dbSet.AddAsync(entity);

        }
        public void Update(ContaDebito entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        public async Task<ContaDebito> Delete(int codigo)
        {
            var entity = await _dbSet.AsNoTracking().Where(p => p.CodContaDebito == codigo).FirstOrDefaultAsync();
            var response = entity is not null ? _dbSet.Remove(entity) : throw new Exception();//==> será tratado ainda! 

            return entity;
        }
        public async Task<List<ContaDebito>> GetAll()
        {
            var key = typeof(ContaDebito).Name.ToLower() + ":" + GetType().Name.ToString();
            var response = await IsCached(key);
            if (!response)
            {
                var entity = await _dbSet.AsNoTracking().ToListAsync();
                await SendByCache(key, entity);
                return entity;
            }
            return await GetByCache(key);
        }
        public async Task<List<ContaDebito>> GetByCode(int codigo)
        {
            var key = typeof(ContaDebito).Name.ToLower() + ":" + codigo.ToString() + ":" + GetType().Name.ToString();
            var response = await IsCached(key);
            if (!response)
            {
                var entity = await _dbSet.AsNoTracking().Where(p => p.CodContaDebito == codigo).ToListAsync();
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
        public async Task<List<ContaDebito>> GetByCache(string key)
        {
            var response = await _cache.GetStringAsync(key);

            return JsonSerializer.Deserialize<List<ContaDebito>>(response);
        }
        public async Task SendByCache(string key, List<ContaDebito> entity)
        {
            var serializedObject = JsonSerializer.Serialize(entity);
            var expirationTime = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15),
                SlidingExpiration = TimeSpan.FromMinutes(12)
            };
            await _cache.SetStringAsync(key, serializedObject, expirationTime);
        }
        public async Task SendByCache(string key, ContaDebito entity)
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
