using MaximoFarm.Register.Application.Commands.Entities.Cargos;
using MaximoFarm.Register.Application.Commands.Entities.Ciclo;
using MaximoFarm.Register.Core.Messages;
using MaximoFarm.Register.Data.Cache;
using MaximoFarm.Register.Data.UnitOfWork;
using MaximoFarm.Register.Domain.Entities;
using MaximoFarm.Register.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Commands.Handles
{
    public class CicloCommandHandler :
        IRequestHandler<CadastrarCicloCommand, bool>,
        IRequestHandler<AlterarCicloCommand, bool>,
        IRequestHandler<ExcluirCicloCommand, bool>
    {
        private readonly IGenericRepository<Ciclo> _repository;
        private readonly IValidation _validation;
        private readonly IUnitOfWork _uow;
        private readonly ICacheRepository<Ciclo> _cache;
        public CicloCommandHandler(
            IGenericRepository<Ciclo> repository,
            IUnitOfWork uow,
            IValidation validation,
            ICacheRepository<Ciclo> cache)
        {
            _repository = repository;
            _uow = uow;
            _validation = validation;
            _cache = cache;
        }
        public async Task<bool> Handle(CadastrarCicloCommand message, CancellationToken cancellationToken)
        {
            if (!_validation.ValidarComando(message))
            {
                return false;
            }
            else
            {
                var ciclo = new Ciclo(
                    message.CodCiclo,
                    message.DescCiclo,
                    message.Ativo);

                _repository.Insert(ciclo);

                var key = typeof(Ciclo).Name.ToLower() + ":" + message.CodCiclo.ToString() + ":" + GetType().Name.ToString();
                await _cache.SendByCache(key, ciclo);

                return await _uow.Commit();
            }
        }
        public async Task<bool> Handle(AlterarCicloCommand message, CancellationToken cancellationToken)
        {
            if (!_validation.ValidarComando(message))
            {
                return false;
            }
            else
            {
                var ciclo = new Ciclo(
                    message.CodCiclo,
                    message.DescCiclo,
                    message.Ativo);

                _repository.Update(ciclo);

                return await _uow.Commit();
            }
        }
        public async Task<bool> Handle(ExcluirCicloCommand message, CancellationToken cancellationToken)
        {

            if (!_validation.ValidarComando(message))
            {
                return false;
            }
            else
            {
                await _repository.Delete(message.CodCiclo);

                return await _uow.Commit();
            }
        }
    }
}
