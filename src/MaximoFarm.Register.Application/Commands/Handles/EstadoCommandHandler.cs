using MaximoFarm.Register.Application.Commands.Entities.Estados;
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
    public class EstadoCommandHandler :
        IRequestHandler<CadastrarEstadoCommand, bool>,
        IRequestHandler<AlterarEstadoCommand, bool>,
        IRequestHandler<ExcluirEstadoCommand, bool>
    {
        private readonly IGenericRepository<Estados> _repository;
        private readonly IValidation _validation;
        private readonly IUnitOfWork _uow;
        private readonly ICacheRepository<Estados> _cache;
        public EstadoCommandHandler(
            IGenericRepository<Estados> repository,
            IUnitOfWork uow,
            IValidation validation,
            ICacheRepository<Estados> cache)
        {
            _repository = repository;
            _uow = uow;
            _validation = validation;
            _cache = cache;
        }
        public async Task<bool> Handle(CadastrarEstadoCommand message, CancellationToken cancellationToken)
        {
            if (!_validation.ValidarComando(message))
            {
                return false;
            }
            else
            {
                var estados = new Estados(
                    message.CodEstado,
                    message.DescAbrevEstado,
                    message.DescEstado);

                _repository.Insert(estados);

                var key = typeof(Estados).Name.ToLower() + ":" + message.CodEstado.ToString() + ":" + GetType().Name.ToString();
                await _cache.SendByCache(key, estados);

                return await _uow.Commit();
            }
        }
        public async Task<bool> Handle(AlterarEstadoCommand message, CancellationToken cancellationToken)
        {
            if (!_validation.ValidarComando(message))
            {
                return false;
            }
            else
            {
                var estados = new Estados(
                    message.CodEstado,
                    message.DescAbrevEstado,
                    message.DescEstado);

                _repository.Update(estados);

                return await _uow.Commit();
            }
        }
        public async Task<bool> Handle(ExcluirEstadoCommand message, CancellationToken cancellationToken)
        {
            if (!_validation.ValidarComando(message))
            {
                return false;
            }
            else
            {
               await _repository.Delete(message.CodEstado);

                return await _uow.Commit();
            }
        }
    }
}
