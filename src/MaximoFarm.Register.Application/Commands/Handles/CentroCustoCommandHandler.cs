using MaximoFarm.Register.Application.Commands.Entities.CentroCusto;
using MaximoFarm.Register.Core.Communication;
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
    public class CentroCustoCommandHandler :
        IRequestHandler<CadastrarCentroCustoCommand, bool>,
        IRequestHandler<AlterarCentroCustoCommand, bool>,
        IRequestHandler<ExcluirCentroCustoCommand, bool>
    {
        private readonly IGenericRepository<CentroCusto> _repository;
        private readonly IValidation _validation;
        private readonly IUnitOfWork _uow;
        private readonly ICacheRepository<CentroCusto> _cache;
        public CentroCustoCommandHandler(
            IGenericRepository<CentroCusto> repository, 
            IUnitOfWork uow,
            IValidation validation,
            ICacheRepository<CentroCusto> cache)
        {
            _repository=repository;
            _uow=uow;
            _validation = validation;
            _cache = cache;
        }
        public async Task<bool> Handle(CadastrarCentroCustoCommand message, CancellationToken cancellationToken)
        {
            if (!_validation.ValidarComando(message))
            {
                return false;
            }
            else
            {
                var centroCusto = new CentroCusto(
                    message.CodCentroCusto, 
                    message.DescCentroCusto, 
                    message.Ativo);

                _repository.Insert(centroCusto);

                var key = typeof(CentroCusto).Name.ToLower() + ":" + message.CodCentroCusto.ToString() + ":" + GetType().Name.ToString();
                await _cache.SendByCache(key, centroCusto);

                return await _uow.Commit();
            }
        }

        public async Task<bool> Handle(AlterarCentroCustoCommand message, CancellationToken cancellationToken)
        {
            if (!_validation.ValidarComando(message))
            {
                return false;
            }
            else
            {
                var centroCusto = new CentroCusto(
                    message.CodCentroCusto,
                    message.DescCentroCusto,
                    message.Ativo);

                _repository.Update(centroCusto);

                return await _uow.Commit();
            }
        }

        public async Task<bool> Handle(ExcluirCentroCustoCommand message, CancellationToken cancellationToken)
        {
            if (!_validation.ValidarComando(message))
            {
                return false;
            }
            else
            {
                await _repository.Delete(message.CodCentroCusto);
                return await _uow.Commit();
            }
        }
    }
}
