using MaximoFarm.Register.Data.Context;
using MaximoFarm.Register.Data.UnitOfWork;
using MaximoFarm.Register.Domain.Entities;
using MaximoFarm.Register.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Data.Repositories
{
    public class EspacamentoRepository : IGenericRepository<Espacamento>, IDisposable
    {
        private readonly RegisterContext _context;
        private readonly DbSet<Espacamento> _dbSet;

        public EspacamentoRepository(RegisterContext context)
        {
            _context = context;
            _dbSet = _context.Set<Espacamento>();
        }
        public void Insert(Espacamento entity)
        {
              _dbSet.AddAsync(entity);
             
        }
        public void Update(Espacamento entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        public async Task<Espacamento> Delete(int codigo)
        {
            var entity = await _dbSet.AsNoTracking().Where(p => p.CodEspacamento == codigo).FirstOrDefaultAsync();
            var response = entity is not null ? _dbSet.Remove(entity) : throw new Exception();//==> será tratado ainda! 

            return entity;
        }
        public async Task<List<Espacamento>> GetAll()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }
        public async Task<List<Espacamento>> GetByCode(int codigo)
        {
           return await _dbSet.AsNoTracking().Where(p=>p.CodEspacamento==codigo).ToListAsync();
        }
        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
