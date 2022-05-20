using MaximoFarm.Register.Application.Commands.Entities.Cargos;
using MaximoFarm.Register.Core.Communication;
using MaximoFarm.Register.Core.Messages;
using MaximoFarm.Register.Core.Messages.CommonMessages.Notifications;
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
    public class CargoCommandHandler : 
        IRequestHandler<CadastrarCargoCommand, bool>,
        IRequestHandler<AlterarCargoCommand, bool>,
        IRequestHandler<ExcluirCargoCommand, bool>
    {
        private readonly IGenericRepository<Cargos> _repository;
        private readonly IValidation _validation;
        private readonly IUnitOfWork _uow;
        private readonly ICacheRepository<Cargos> _cache;

        public CargoCommandHandler(
            IGenericRepository<Cargos> repository,
            IUnitOfWork uow,
            IValidation validation,
            ICacheRepository<Cargos> cache)
        {
            _repository = repository;
            _validation = validation;
            _uow = uow;
            _cache = cache;
        }

        public async Task<bool> Handle(CadastrarCargoCommand message, CancellationToken cancellationToken)
        {
            if (!_validation.ValidarComando(message))
            {
                return false;
            }
            else
            {
                var cargos = new Cargos(
                    message.CodCargo, 
                    message.DescCargo);

                var key = typeof(CadEstoque).Name.ToLower() + ":" + message.CodCargo.ToString() + ":" + GetType().Name.ToString();
                await _cache.SendByCache(key, cargos);

                _repository.Insert(cargos);

                return await _uow.Commit();
            }
        }

        public async Task<bool> Handle(AlterarCargoCommand message, CancellationToken cancellationToken)
        {
            if (!_validation.ValidarComando(message))
            {
                return false;
            }
            else
            {
                var cargos = new Cargos(
                    message.CodCargo,
                    message.DescCargo);

                _repository.Update(cargos);
               return await _uow.Commit();
            }
        }

        public async Task<bool> Handle(ExcluirCargoCommand message, CancellationToken cancellationToken)
        {
            if (!_validation.ValidarComando(message))
            {
                return false;
            }
            else
            {
                await _repository.Delete(message.CodCargo);
                return await _uow.Commit();
            }
        }
    }
}
