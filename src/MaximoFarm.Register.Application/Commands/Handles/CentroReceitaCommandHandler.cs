using MaximoFarm.Register.Application.Commands.Entities.CentroReceita;
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
    public class CentroReceitaCommandHandler :
        IRequestHandler<CadastrarCentroReceitaCommand, bool>,
        IRequestHandler<AlterarCentroReceitaCommand, bool>,
        IRequestHandler<ExcluirCentroReceitaCommand, bool>
    {
        private readonly IGenericRepository<CentroReceita> _repository;
        private readonly IValidation _validation;
        private readonly IUnitOfWork _uow;
        private readonly ICacheRepository<CentroReceita> _cache;
        public CentroReceitaCommandHandler(
            IGenericRepository<CentroReceita> repository,
            IUnitOfWork uow,
            IValidation validation,
             ICacheRepository<CentroReceita> cache)
        {
            _repository = repository;
            _uow = uow;
            _validation = validation;
            _cache = cache;
        }
        public async Task<bool> Handle(CadastrarCentroReceitaCommand message, CancellationToken cancellationToken)
        {
            if (!_validation.ValidarComando(message))
            {
                return false;
            }
            else
            {
                var centroReceita = new CentroReceita(
                    message.CodCentroReceita,
                    message.DescCentroReceita,
                    message.Ativo);

                _repository.Insert(centroReceita);

                var key = typeof(CentroReceita).Name.ToLower() + ":" + message.CodCentroReceita.ToString() + ":" + GetType().Name.ToString();
                await _cache.SendByCache(key, centroReceita);

                return await _uow.Commit();
            }
        }

        public async Task<bool> Handle(AlterarCentroReceitaCommand message, CancellationToken cancellationToken)
        {
            if (!_validation.ValidarComando(message))
            {
                return false;
            }
            else
            {
                var centroReceita = new CentroReceita(
                    message.CodCentroReceita,
                    message.DescCentroReceita,
                    message.Ativo);

                _repository.Update(centroReceita);

                return await _uow.Commit();
            }
        }

        public async Task<bool> Handle(ExcluirCentroReceitaCommand message, CancellationToken cancellationToken)
        {
            if (!_validation.ValidarComando(message))
            {
                return false;
            }
            else
            {
               await _repository.Delete(message.CodCentroReceita);
                return await _uow.Commit();
            }
        }
    }
}
