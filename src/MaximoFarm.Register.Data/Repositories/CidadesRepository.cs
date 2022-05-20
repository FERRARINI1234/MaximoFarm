using MaximoFarm.Register.Data.Cache;
using MaximoFarm.Register.Data.Context;
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
    public class CidadesRepository :
        IGenericRepository<Cidades>,
        ICacheRepository<Cidades>,
        IDisposable
    {
        private readonly RegisterContext _context;
        private readonly DbSet<Cidades> _dbSet;
        private readonly IDistributedCache _cache;
        public CidadesRepository(RegisterContext context, IDistributedCache cache)
        {
            _context=context;
            _cache=cache;
            _dbSet = _context.Set<Cidades>();
        }
        public void Insert(Cidades entity)
        {
            _dbSet.AddAsync(entity);
        }
        public void Update(Cidades entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        public async Task<Cidades> Delete(int codigo)
        {
            var entity = await _dbSet.AsNoTracking().Where(p => p.CodCidade == codigo).FirstOrDefaultAsync();
            var response = entity is not null ? _dbSet.Remove(entity) : throw new Exception();//==> será tratado ainda! 

            return entity;
        }
        public async Task<List<Cidades>> GetByCode(int codigo)
        {
            var key = typeof(Ciclo).Name.ToLower() + ":" + codigo.ToString() + ":" + GetType().Name.ToString();
            var response = await IsCached(key);
            if (!response)
            {
                var entity = await _dbSet.AsNoTracking().Where(p => p.CodCidade == codigo).ToListAsync();
                await SendByCache(key, entity);
                return entity;
            }
            return await GetByCache(key);
        }
        public Task<List<Cidades>> GetAll()
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }
        public async Task<List<Cidades>> GetByCache(string key)
        {
            var response = await _cache.GetStringAsync(key);

            return JsonSerializer.Deserialize<List<Cidades>>(response);
        }
        public async Task<bool> IsCached(string key)
        {
            var response = await _cache.GetStringAsync(key);
            if (!string.IsNullOrWhiteSpace(response)) return true;
            return false;
        }
        public async Task SendByCache(string key, List<Cidades> entity)
        {
            var serializedObject = JsonSerializer.Serialize(entity);
            var expirationTime = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15),
                SlidingExpiration = TimeSpan.FromMinutes(12)
            };
            await _cache.SetStringAsync(key, serializedObject, expirationTime);
        }
        public async Task SendByCache(string key, Cidades entity)
        {
            var serializedObject = JsonSerializer.Serialize(entity);
            var expirationTime = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15),
                SlidingExpiration = TimeSpan.FromMinutes(12)
            };
            await _cache.SetStringAsync(key, serializedObject, expirationTime);
        }
    }
}
