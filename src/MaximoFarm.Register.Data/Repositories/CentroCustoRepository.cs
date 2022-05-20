using MaximoFarm.Register.Data.Cache;
using MaximoFarm.Register.Data.Context;
using MaximoFarm.Register.Data.UnitOfWork;
using MaximoFarm.Register.Domain.Entities;
using MaximoFarm.Register.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Data.Repositories
{
    public class CentroCustoRepository : 
        IGenericRepository<CentroCusto>,
        ICacheRepository<CentroCusto>, IDisposable
    {
        private readonly RegisterContext _context;
        private readonly DbSet<CentroCusto> _dbSet;
        private readonly IDistributedCache _cache;
        public CentroCustoRepository(RegisterContext context, IDistributedCache cache)
        {
            _context = context;
            _dbSet = _context.Set<CentroCusto>();
            _cache = cache;
        }
        public async Task<List<CentroCusto>> GetAll()
        {
            var key = typeof(CadEstoque).Name.ToLower() + ":" + GetType().Name.ToString();
            var response = await IsCached(key);
            if (!response)
            {
                var entity = await _dbSet.AsNoTracking().ToListAsync();
                await SendByCache(key, entity);
                return entity;
            }
            return await GetByCache(key);
        }
        public async Task<List<CentroCusto>> GetByCode(int codigo)
        {
            var key = typeof(CadEstoque).Name.ToLower() + ":" + codigo.ToString() + ":" + GetType().Name.ToString();
            var response = await IsCached(key);
            if (!response)
            {
                var entity = await _dbSet.AsNoTracking().Where(p => p.CodCentroCusto == codigo).ToListAsync();
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
        public void Insert(CentroCusto entity)
        {
            _dbSet.AddAsync(entity);
           
        }
        public void Update(CentroCusto entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _dbSet.Update(entity);
        }
        public async Task<CentroCusto> Delete(int codigo)
        {
            var entity = await _dbSet.AsNoTracking().Where(p => p.CodCentroCusto == codigo).FirstOrDefaultAsync();
            var response = entity is not null ? _dbSet.Remove(entity) : throw new Exception();//==> será tratado ainda! 

            return entity;
        }
        public async Task<List<CentroCusto>> GetByCache(string key)
        {
            var response = await _cache.GetStringAsync(key);

            return JsonSerializer.Deserialize<List<CentroCusto>>(response);
        }
        public async Task SendByCache(string key, List<CentroCusto> entity)
        {
            var serializedObject = JsonSerializer.Serialize(entity);
            var expirationTime = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15),
                SlidingExpiration = TimeSpan.FromMinutes(12)
            };
            await _cache.SetStringAsync(key, serializedObject, expirationTime);
        }

        public async Task SendByCache(string key, CentroCusto entity)
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
