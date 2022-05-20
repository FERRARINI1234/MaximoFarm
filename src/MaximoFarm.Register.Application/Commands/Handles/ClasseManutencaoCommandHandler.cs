using MaximoFarm.Register.Application.Commands.Entities.Cargos;
using MaximoFarm.Register.Application.Commands.Entities.ClasseManutencao;
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
    public class ClasseManutencaoCommandHandler :
        IRequestHandler<CadastrarClasseManutencaoCommand, bool>,
        IRequestHandler<AlterarClasseManutencaoCommand, bool>,
        IRequestHandler<ExcluirClasseManutencaoCommand, bool>

    {
        private readonly IGenericRepository<ClasseManutencao> _repository;
        private readonly IUnitOfWork _uow;
        private readonly IValidation _validation;
        private readonly ICacheRepository<ClasseManutencao> _cache;
        public ClasseManutencaoCommandHandler(
            IGenericRepository<ClasseManutencao> repository,
            IUnitOfWork uow,
            IValidation validation,
            ICacheRepository<ClasseManutencao> cache)
        {
            _repository = repository;
            _uow = uow;
            _validation = validation;
            _cache = cache;
        }
        public async Task<bool> Handle(CadastrarClasseManutencaoCommand message, CancellationToken cancellationToken)
        {
            if (!_validation.ValidarComando(message))
            {
                return false; // LOG
            }
            else
            {
                var classeManutencao = new ClasseManutencao(
                    message.CodClasseManutencao, 
                    message.DescClasseManutencao);

                _repository.Insert(classeManutencao);

                var key = typeof(ClasseManutencao).Name.ToLower() + ":" + message.CodClasseManutencao.ToString() + ":" + GetType().Name.ToString();
                await _cache.SendByCache(key, classeManutencao);

                return await _uow.Commit();
            }
        }
        public async Task<bool> Handle(AlterarClasseManutencaoCommand message, CancellationToken cancellationToken)
        {
            if (!_validation.ValidarComando(message))
            {
                return false;
            }
            else
            {
                var classeManutencao = new ClasseManutencao(
                message.CodClasseManutencao,
                message.DescClasseManutencao);

                _repository.Update(classeManutencao);

                return await _uow.Commit();
            }
        }
        public async Task<bool> Handle(ExcluirClasseManutencaoCommand message, CancellationToken cancellationToken)
        {
            if (_validation.ValidarComando(message)) // se o comando for valido
            {
                await _repository.Delete(message.CodClasseManutencao);
                return await _uow.Commit();
            }
            else
            {
                return false;
            }
        }
    }
}
