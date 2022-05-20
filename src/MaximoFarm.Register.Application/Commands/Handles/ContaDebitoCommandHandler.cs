using MaximoFarm.Register.Application.Commands.Entities.ContaDebito;
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
    public class ContaDebitoCommandHandler : 
        IRequestHandler<CadastrarContaDebitoCommand,bool>,
        IRequestHandler<AlterarContaDebitoCommand, bool>,
        IRequestHandler<ExcluirContaDebitoCommand, bool>
    {
        private readonly IGenericRepository<ContaDebito> _repository;
        private readonly IUnitOfWork _uow;
        private readonly IValidation _validation;
        private readonly ICacheRepository<ContaDebito> _cache;
        public ContaDebitoCommandHandler(
            IGenericRepository<ContaDebito> repository,
            IUnitOfWork uow,
            IValidation validation,
            ICacheRepository<ContaDebito> cache)
        {
            _repository=repository;
            _uow=uow;
            _validation=validation;
            _cache=cache;
        }
        public async Task<bool> Handle(CadastrarContaDebitoCommand message, CancellationToken cancellationToken)
        {
            if (!_validation.ValidarComando(message))
            {
                return false; // LOG
            }
            else
            {
                var contaDebito = new ContaDebito(
                    message.CodContaDebito, 
                    message.DescContaDebito,
                    message.Ativo);

                _repository.Insert(contaDebito);

                var key = typeof(ContaDebito).Name.ToLower() + ":" + message.CodContaDebito.ToString() + ":" + GetType().Name.ToString();
                await _cache.SendByCache(key, contaDebito);

                return await _uow.Commit();
            }
        }
        public async Task<bool> Handle(AlterarContaDebitoCommand message, CancellationToken cancellationToken)
        {
            if (!_validation.ValidarComando(message))
            {
                return false;
            }
            else
            {
                var contaDebito = new ContaDebito(
                 message.CodContaDebito,
                    message.DescContaDebito,
                    message.Ativo);

                _repository.Update(contaDebito);

                return await _uow.Commit();
            }
        }
        public async Task<bool> Handle(ExcluirContaDebitoCommand message, CancellationToken cancellationToken)
        {
            if (_validation.ValidarComando(message)) // se o comando for valido
            {
                await _repository.Delete(message.CodContaDebito);
                return await _uow.Commit();
            }
            else
            {
                return false;
            }
        }
    }
}
