using MaximoFarm.Register.Data.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using System;
using MaximoFarm.Register.Domain.Interfaces;
using MaximoFarm.Register.Data.Repositories;
using MaximoFarm.Register.Domain.Entities;
using MaximoFarm.Register.Application.Commands.Handles;
using MaximoFarm.Register.Application.Commands.Entities.CadEstoque;

using MediatR;
using MaximoFarm.Register.Core.Messages.CommonMessages.Notifications;
using MaximoFarm.Register.Core.Communication;
using MaximoFarm.Register.Application.Queries.Interfaces;
using MaximoFarm.Register.Application.Queries;
using MaximoFarm.Register.Application.Commands.Entities.Cargos;
using MaximoFarm.Register.Application.Commands.Entities.CentroCusto;
using MaximoFarm.Register.Application.Commands.Entities.CentroReceita;
using MaximoFarm.Register.Application.Commands.Entities.Ciclo;
using MaximoFarm.Register.Application.Commands.Entities.Cidades;
using MaximoFarm.Register.Application.Commands.Entities.Estados;
using MaximoFarm.Register.Core.Messages;
using MaximoFarm.Register.Data.Cache;
using MaximoFarm.Register.Application.Commands.Entities.ClasseManutencao;
using MaximoFarm.Register.Application.Commands.Entities.ContaDebito;
using MaximoFarm.Register.Application.Commands.Entities.ContaReceita;
using MaximoFarm.Register.Application.Commands.Entities.Safras;

namespace MaximoFarm.Register.Api.Ioc
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {

            //UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Repositorios
            services.AddScoped<IGenericRepository<Safra>, SafraRepository>();
            services.AddScoped<IGenericRepository<CadEstoque>, CadEstoqueRepository>();
            services.AddScoped<IGenericRepository<Cargos>, CargosRepository>();
            services.AddScoped<IGenericRepository<CentroCusto>, CentroCustoRepository>();
            services.AddScoped<IGenericRepository<CentroReceita>, CentroReceitaRepository>();
            services.AddScoped<IGenericRepository<Ciclo>, CicloRepository>();
            services.AddScoped<IGenericRepository<ClasseManutencao>, ClasseManutencaoRepository>();
            services.AddScoped<IGenericRepository<Estados>, EstadosRepository>();
            services.AddScoped<IGenericRepository<Cidades>, CidadesRepository>();
            services.AddScoped<IGenericRepository<ContaReceita>, ContaReceitaRepository>();
            services.AddScoped<IGenericRepository<ContaDebito>, ContaDebitoRepository>();
            services.AddScoped<IGenericRepository<Espacamento>, EspacamentoRepository>();

            //Cache
            services.AddScoped<ICacheRepository<CadEstoque>,CadEstoqueRepository>();
            services.AddScoped<ICacheRepository<ClasseManutencao>, ClasseManutencaoRepository>();
            services.AddScoped<ICacheRepository<CentroCusto>, CentroCustoRepository>();
            services.AddScoped<ICacheRepository<CentroReceita>, CentroReceitaRepository>();
            services.AddScoped<ICacheRepository<ContaDebito>, ContaDebitoRepository>();
            services.AddScoped<ICacheRepository<ContaReceita>, ContaReceitaRepository>();
            services.AddScoped<ICacheRepository<Cargos>, CargosRepository>();
            services.AddScoped<ICacheRepository<Ciclo>, CicloRepository>();
            services.AddScoped<ICacheRepository<Estados>, EstadosRepository>();
            services.AddScoped<ICacheRepository<Cidades>, CidadesRepository>();
            services.AddScoped<ICacheRepository<Safra>, SafraRepository>();
            //AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Notifications
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            
            //Validataionts
            services.AddScoped<IValidation, Validation>();

            //MediatorHandler
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            //Commands - CQRS
            //Estoque
            services.AddScoped<IRequestHandler<CadastrarEstoqueCommand, bool>, EstoqueCommandHandler>();
            services.AddScoped<IRequestHandler<AlterarEstoqueCommand, bool>, EstoqueCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirEstoqueCommand, bool>, EstoqueCommandHandler>();
            //Cargos
            services.AddScoped<IRequestHandler<CadastrarCargoCommand, bool>, CargoCommandHandler>();
            services.AddScoped<IRequestHandler<AlterarCargoCommand, bool>, CargoCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirCargoCommand, bool>, CargoCommandHandler>();
            //CentroCusto
            services.AddScoped<IRequestHandler<CadastrarCentroCustoCommand, bool>, CentroCustoCommandHandler>();
            services.AddScoped<IRequestHandler<AlterarCentroCustoCommand, bool>, CentroCustoCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirCentroCustoCommand, bool>, CentroCustoCommandHandler>();
            //CentroReceita
            services.AddScoped<IRequestHandler<CadastrarCentroReceitaCommand, bool>, CentroReceitaCommandHandler>();
            services.AddScoped<IRequestHandler<AlterarCentroReceitaCommand, bool>, CentroReceitaCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirCentroReceitaCommand, bool>, CentroReceitaCommandHandler>();
            //Ciclo
            services.AddScoped<IRequestHandler<CadastrarCicloCommand, bool>, CicloCommandHandler>();
            services.AddScoped<IRequestHandler<AlterarCicloCommand, bool>, CicloCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirCicloCommand, bool>, CicloCommandHandler>();
            //Cidade
            services.AddScoped<IRequestHandler<CadastrarCidadeCommand, bool>, CidadeCommandHandler>();
            services.AddScoped<IRequestHandler<AlterarCidadeCommand, bool>, CidadeCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirCidadeCommand, bool>, CidadeCommandHandler>();
            //Estado
            services.AddScoped<IRequestHandler<CadastrarEstadoCommand, bool>, EstadoCommandHandler>();
            services.AddScoped<IRequestHandler<AlterarEstadoCommand, bool>, EstadoCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirEstadoCommand, bool>, EstadoCommandHandler>();
            ///ClasseManutencao
            services.AddScoped<IRequestHandler<CadastrarClasseManutencaoCommand, bool>, ClasseManutencaoCommandHandler>();
            services.AddScoped<IRequestHandler<AlterarClasseManutencaoCommand, bool>, ClasseManutencaoCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirClasseManutencaoCommand, bool>, ClasseManutencaoCommandHandler>();
            ///ContaDebito
            services.AddScoped<IRequestHandler<CadastrarContaDebitoCommand, bool>, ContaDebitoCommandHandler>();
            services.AddScoped<IRequestHandler<AlterarContaDebitoCommand, bool>, ContaDebitoCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirContaDebitoCommand, bool>, ContaDebitoCommandHandler>();
            ///Contareceita
            services.AddScoped<IRequestHandler<CadastrarContaReceitaCommand, bool>, ContaReceitaCommandHandler>();
            services.AddScoped<IRequestHandler<AlterarContaReceitaCommand, bool>, ContaReceitaCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirContaReceitaCommand, bool>, ContaReceitaCommandHandler>();
            ///Safra
            services.AddScoped<IRequestHandler<CadastrarSafraCommand, bool>, SafraCommandHandler>();
            services.AddScoped<IRequestHandler<AlterarSafraCommand, bool>, SafraCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirSafraCommand, bool>, SafraCommandHandler>();

            ///Queries - CQRS
            services.AddScoped<ICadEstoqueQueries, CadEstoqueQueries>();
            services.AddScoped<ICargosQueries, CargosQueries>();
            services.AddScoped<ICentroCustoQueries, CentroCustoQueries>();
            services.AddScoped<ICentroReceitaQueries, CentroReceitaQueries>();
            services.AddScoped<ICicloQueries, CicloQueries>();
            services.AddScoped<ICidadeQueries, CidadeQueries>();
            services.AddScoped<IEstadosQueries, EstadosQueries>();
            services.AddScoped<IClasseManutencaoQueries, ClasseManutencaoQueries>();
            services.AddScoped<IContaDebitoQueries, ContaDebitoQueries>();
            services.AddScoped<ISafraQueries, SafraQueries>();
        }
    }
}
