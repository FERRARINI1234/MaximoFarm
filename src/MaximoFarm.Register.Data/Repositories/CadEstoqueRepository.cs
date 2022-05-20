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
    public class CadEstoqueRepository :
        IGenericRepository<CadEstoque>,
        ICacheRepository<CadEstoque>,
        IDisposable
    {
        private readonly RegisterContext _context;
        private readonly DbSet<CadEstoque> _dbSet;
        private readonly IDistributedCache _cache;

        public CadEstoqueRepository(RegisterContext context, IDistributedCache cache)
        {
            _context = context;
            _cache = cache;
            _dbSet = _context.Set<CadEstoque>();
        }
        public void Insert(CadEstoque cadEstoque)
        {
            _dbSet.AddAsync(cadEstoque);
        }
        public void Update(CadEstoque cadEstoque)
        {
            _context.Entry(cadEstoque).State = EntityState.Modified;
        }
        public async Task<CadEstoque> Delete(int codigo)
        {
            var entity = await _dbSet.AsNoTracking().Where(p => p.CodCadEstoque == codigo).FirstOrDefaultAsync();

            var response = entity is not null ? _dbSet.Remove(entity) : throw new Exception();

            return entity;
        }
        public async Task<List<CadEstoque>> GetAll()
        {
            var key = typeof(CadEstoque).Name.ToLower() + ":" + GetType().Name.ToString();
            var response = await IsCached(key);
            if (!response)
            {
                var entity = await _dbSet.AsNoTracking().ToListAsync();
                await SendByCache(key,entity);
                return entity;
            }
            return await GetByCache(key);
        }
        public async Task<List<CadEstoque>> GetByCode(int codigo)
        {
            var key = typeof(CadEstoque).Name.ToLower() + ":" + codigo.ToString() + ":" + GetType().Name.ToString();
            var response = await IsCached(key);
            if (!response)
            {
                var entity = await _dbSet.AsNoTracking().Where(p => p.CodCadEstoque == codigo).ToListAsync();
                await SendByCache(key,entity);
                return entity;
            }
            return await GetByCache(key);
        }
        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }
        public async Task<List<CadEstoque>> GetByCache(string key)
        {
            var response = await _cache.GetStringAsync(key);

            return JsonSerializer.Deserialize<List<CadEstoque>>(response);
        }
        public async Task SendByCache(string key, List<CadEstoque> entity)
        {
            var serializedObject = JsonSerializer.Serialize(entity);
            var expirationTime = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15),
                SlidingExpiration = TimeSpan.FromMinutes(12)
            };
            await _cache.SetStringAsync(key, serializedObject, expirationTime);
        }
        public async Task SendByCache(string key, CadEstoque entity)
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
