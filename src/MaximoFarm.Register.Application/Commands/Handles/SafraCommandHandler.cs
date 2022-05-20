using MaximoFarm.Register.Application.Commands.Entities.Safras;
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
    public class SafraCommandHandler : 
        IRequestHandler<CadastrarSafraCommand,bool>,
        IRequestHandler<AlterarSafraCommand, bool>,
        IRequestHandler<ExcluirSafraCommand, bool>
    {
        private readonly IGenericRepository<Safra> _repository;
        private readonly IValidation _validation;
        private readonly IUnitOfWork _uow;
        private readonly ICacheRepository<Safra> _cache;
        public SafraCommandHandler(
            IGenericRepository<Safra> repository,
            IUnitOfWork uow,
            IValidation validation,
            ICacheRepository<Safra> cache)
        {
            _repository = repository;
            _uow = uow;
            _validation = validation;
            _cache = cache;
        }

        public async Task<bool> Handle(CadastrarSafraCommand message, CancellationToken cancellationToken)
        {
            if (!_validation.ValidarComando(message))
            {
                return false; // LOG
            }
            else
            {
                var safra = new Safra(message.CodSafra, message.DescSafra);
                _repository.Insert(safra);

                var key = typeof(Safra).Name.ToLower() + ":" + message.CodSafra.ToString() + ":" + GetType().Name.ToString();
                await _cache.SendByCache(key, safra);

                return await _uow.Commit();
            }
        }

        public async Task<bool> Handle(AlterarSafraCommand message, CancellationToken cancellationToken)
        {
            if (!_validation.ValidarComando(message))
            {
                return false;
            }
            else
            {
                var safra = new Safra(
                message.CodSafra,
                message.DescSafra);

                _repository.Update(safra);


                return await _uow.Commit();
            }
        }

        public async Task<bool> Handle(ExcluirSafraCommand message, CancellationToken cancellationToken)
        {
            if (_validation.ValidarComando(message)) // se o comando for valido
            {
                await _repository.Delete(message.CodSafra);
                return await _uow.Commit();
            }
            else
            {
                return false;
            }
        }
    }
}
