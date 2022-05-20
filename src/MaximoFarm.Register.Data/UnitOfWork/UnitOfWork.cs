using FluentValidation;
using MaximoFarm.Register.Core.Communication;
using MaximoFarm.Register.Core.Messages;
using MaximoFarm.Register.Core.Messages.CommonMessages.Notifications;
using MaximoFarm.Register.Data.Context;
using MaximoFarm.Register.Data.Repositories;
using MaximoFarm.Register.Domain.Entities;
using MaximoFarm.Register.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        //METODO TEM Q APARECER DENTRO DA CLASSE DE VALIDAÇÃO. VALIDATION RESULT
        private readonly RegisterContext _context;
        private readonly ILogger<UnitOfWork> _logging;
        private readonly IMediatorHandler _mediatorHandler;
        public UnitOfWork(RegisterContext context, ILogger<UnitOfWork> logging, IMediatorHandler mediatorHandler)
        {
            _context = context;
            _logging = logging;
            _mediatorHandler = mediatorHandler;
        }
        public async Task<bool> Commit()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification(LogLevel.Error.ToString(), ex.InnerException.Message.ToString()));
                return false;
            }
        }
        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
