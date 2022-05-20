using MaximoFarm.Register.Application.Commands.Entities.Cidades;
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
    public class CidadeCommandHandler :
        IRequestHandler<CadastrarCidadeCommand, bool>,
        IRequestHandler<AlterarCidadeCommand, bool>,
        IRequestHandler<ExcluirCidadeCommand, bool>
    {
        private readonly IGenericRepository<Cidades> _repository;
        private readonly IValidation _validation;
        private readonly IUnitOfWork _uow;
        private readonly ICacheRepository<Cidades> _cache;
        public CidadeCommandHandler(
                        IGenericRepository<Cidades> repository,
                        IUnitOfWork uow,
                        IValidation validation,
                        ICacheRepository<Cidades> cache)
        {
            _repository = repository;
            _uow = uow;
            _validation = validation;
            _cache = cache;
        }
        public async Task<bool> Handle(CadastrarCidadeCommand message, CancellationToken cancellationToken)
        {
            if (!_validation.ValidarComando(message))
            {
                return false;
            }
            else
            {
                var cidades = new Cidades(
                    message.CodCidade,
                    message.DescCidade);

                _repository.Insert(cidades);

                var key = typeof(Cidades).Name.ToLower() + ":" + message.CodCidade.ToString() + ":" + GetType().Name.ToString();
                await _cache.SendByCache(key, cidades);

                return await _uow.Commit();
            }
        }
        public async Task<bool> Handle(AlterarCidadeCommand message, CancellationToken cancellationToken)
        {
            if (!_validation.ValidarComando(message))
            {
                return false;
            }
            else
            {
                var cidades = new Cidades(
                    message.CodCidade,
                    message.DescCidade);

                _repository.Update(cidades);

                return await _uow.Commit();
            }
        }
        public async Task<bool> Handle(ExcluirCidadeCommand message, CancellationToken cancellationToken)
        {
            if (!_validation.ValidarComando(message))
            {
                return false;
            }
            else
            {
                await _repository.Delete(message.CodCidade);

                return await _uow.Commit();
            }
        }
    }
}
