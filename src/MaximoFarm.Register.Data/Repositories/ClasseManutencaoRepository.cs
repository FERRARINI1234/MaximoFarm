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
    public class ClasseManutencaoRepository : 
        IGenericRepository<ClasseManutencao>,
        ICacheRepository<ClasseManutencao>,
        IDisposable
    {
        private readonly RegisterContext _context;
        private readonly DbSet<ClasseManutencao> _dbSet;
        private readonly IDistributedCache _cache;
        public ClasseManutencaoRepository(RegisterContext context, IDistributedCache cache)
        {
            _context = context; 
            _dbSet = _context.Set<ClasseManutencao>();
            _cache = cache;
        }
        public void Insert(ClasseManutencao entity)
        {
            _dbSet.AddAsync(entity); ;
        }
        public void Update(ClasseManutencao entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        public async Task<ClasseManutencao> Delete(int codigo)
        {
            var entity = await _dbSet.AsNoTracking().Where(p => p.CodClasseManutencao == codigo).FirstOrDefaultAsync();
            var response = entity is not null ? _dbSet.Remove(entity) : throw new Exception();//==> será tratado ainda! 

            return entity;
        }
        public async Task<List<ClasseManutencao>> GetAll()
        {
            var key = typeof(ClasseManutencao).Name.ToLower() + ":" + GetType().Name.ToString();
            var response = await IsCached(key);
            if (!response)
            {
                var entity = await _dbSet.AsNoTracking().ToListAsync();
                await SendByCache(key, entity);
                return entity;
            }
            return await GetByCache(key);
        }
        public async Task<List<ClasseManutencao>> GetByCode(int codigo)
        {
            var key = typeof(ClasseManutencao).Name.ToLower() + ":" + codigo.ToString() + ":" + GetType().Name.ToString();
            var response = await IsCached(key);
            if (!response)
            {
                var entity = await _dbSet.AsNoTracking().Where(p => p.CodClasseManutencao == codigo).ToListAsync();
                await SendByCache(key, entity);
                return entity;
            }
            return await GetByCache(key);
        }
        public void Dispose() => _context?.Dispose();
        public async Task<List<ClasseManutencao>> GetByCache(string key)
        {
            var response = await _cache.GetStringAsync(key);

            return JsonSerializer.Deserialize<List<ClasseManutencao>>(response);
        }
        public async Task SendByCache(string key, List<ClasseManutencao> entity)
        {
            var serializedObject = JsonSerializer.Serialize(entity);
            var expirationTime = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15),
                SlidingExpiration = TimeSpan.FromMinutes(12)
            };
            await _cache.SetStringAsync(key, serializedObject, expirationTime);
        }
        public async Task SendByCache(string key, ClasseManutencao entity)
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
