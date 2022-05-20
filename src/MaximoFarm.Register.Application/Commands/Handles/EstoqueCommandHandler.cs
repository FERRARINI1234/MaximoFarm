using MaximoFarm.Register.Application.Commands.Entities.CadEstoque;
using MaximoFarm.Register.Core.Communication;
using MaximoFarm.Register.Core.Messages;
using MaximoFarm.Register.Core.Messages.CommonMessages.Notifications;
using MaximoFarm.Register.Data.Cache;
using MaximoFarm.Register.Data.Repositories;
using MaximoFarm.Register.Data.UnitOfWork;
using MaximoFarm.Register.Domain.Entities;
using MaximoFarm.Register.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Commands.Handles
{
    public class EstoqueCommandHandler :
        IRequestHandler<CadastrarEstoqueCommand, bool>,
        IRequestHandler<AlterarEstoqueCommand, bool>,
        IRequestHandler<ExcluirEstoqueCommand, bool>
    {
        private readonly IGenericRepository<CadEstoque> _repository;
        private readonly IUnitOfWork _uow;
        private readonly IValidation _validation;
        private readonly ICacheRepository<CadEstoque> _cache;
        public EstoqueCommandHandler(
            IGenericRepository<CadEstoque> repository,
            IUnitOfWork uow,
            IValidation validation,
            ICacheRepository<CadEstoque> cache
)
        {
            _repository = repository;
            _uow = uow;
            _validation = validation;
            _cache = cache;
        }
        public async Task<bool> Handle(CadastrarEstoqueCommand message, CancellationToken cancellationToken)
        {
            if (!_validation.ValidarComando(message))
            {
                return false; // LOG
            }
            else
            {
                var estoque = new CadEstoque(message.CodCadEstoque, message.DescCadEstoque);
                _repository.Insert(estoque);

                var key = typeof(CadEstoque).Name.ToLower() + ":" + message.CodCadEstoque.ToString() + ":" + GetType().Name.ToString();
                await _cache.SendByCache(key, estoque);

                return await _uow.Commit();
            }
        }
        public async Task<bool> Handle(AlterarEstoqueCommand message, CancellationToken cancellationToken)
        {
            if (!_validation.ValidarComando(message))
            {
                return false;
            }
            else
            {
                var estoque = new CadEstoque(
                message.CodCadEstoque,
                message.DescCadEstoque);

                _repository.Update(estoque);

                
                return await _uow.Commit();
            }
        }
        public async Task<bool> Handle(ExcluirEstoqueCommand message, CancellationToken cancellationToken)
        {
            if (_validation.ValidarComando(message)) // se o comando for valido
            {
                await _repository.Delete(message.CodCadEstoque);
                return await _uow.Commit();
            }
            else
            {
                return false;
            }
        }

    }
}
