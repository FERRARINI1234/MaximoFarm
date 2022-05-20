using MaximoFarm.Register.Application.Commands.Entities.ContaReceita;
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
    public class ContaReceitaCommandHandler :
        IRequestHandler<CadastrarContaReceitaCommand, bool>,
        IRequestHandler<AlterarContaReceitaCommand, bool>,
        IRequestHandler<ExcluirContaReceitaCommand, bool>
    {
        private readonly IGenericRepository<ContaReceita> _repository;
        private readonly IUnitOfWork _uow;
        private readonly IValidation _validation;
        private readonly ICacheRepository<ContaReceita> _cache;

        public ContaReceitaCommandHandler(
            IGenericRepository<ContaReceita> repository,
            IUnitOfWork uow,
            IValidation validation,
            ICacheRepository<ContaReceita> cache
            )
        {
            _repository = repository;
            _uow = uow;
            _validation = validation;
            _cache = cache;
        }

        public async Task<bool> Handle(CadastrarContaReceitaCommand message, CancellationToken cancellationToken)
        {
            if (!_validation.ValidarComando(message))
            {
                return false; // LOG
            }
            else
            {
                var contaReceita = new ContaReceita(message.CodContaReceita, message.DescContaReceita,message.Ativo);
                _repository.Insert(contaReceita);

                var key = typeof(ContaReceita).Name.ToLower() + ":" + message.CodContaReceita.ToString() + ":" + GetType().Name.ToString();
                await _cache.SendByCache(key, contaReceita);

                return await _uow.Commit();
            }
        }

        public async Task<bool> Handle(AlterarContaReceitaCommand message, CancellationToken cancellationToken)
        {
            if (!_validation.ValidarComando(message))
            {
                return false;
            }
            else
            {
                var estoque = new ContaReceita(
                message.CodContaReceita,
                message.DescContaReceita,
                message.Ativo);

                _repository.Update(estoque);
                return await _uow.Commit();
            }
        }

        public async Task<bool> Handle(ExcluirContaReceitaCommand message, CancellationToken cancellationToken)
        {
            if (_validation.ValidarComando(message)) // se o comando for valido
            {
                await _repository.Delete(message.CodContaReceita);
                return await _uow.Commit();
            }
            else
            {
                return false;
            }
        }
    }
}
