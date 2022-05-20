using System;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Chama o método SaveChangesAsync do EntityFrameWork Core.
        /// </summary>
        /// <returns>Bool</returns>
        Task<bool> Commit();

    }
}
