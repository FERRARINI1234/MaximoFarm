using MaximoFarm.Register.Application.Commands.Entities.ClasseManutencao;
using MaximoFarm.Register.Application.Queries.Interfaces;
using MaximoFarm.Register.Application.Queries.ViewModels;
using MaximoFarm.Register.Core.Communication;
using MaximoFarm.Register.Core.Messages.CommonMessages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Api.Controllers
{
    [ApiController]
    [Route("cadastros/v1/classemanutencao")]
    public class ClasseManutencaoController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IClasseManutencaoQueries _queries;

        public ClasseManutencaoController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediatorHandler,
            IClasseManutencaoQueries queries) : base(notifications, mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _queries = queries;
        }

        [HttpGet]
        public async Task<ActionResult> ObterTodos()
        {
            var entity = await _queries.ConsultarClasseManutencao();
            if (entity.Count == 0)
            {
                return NoContent();
            }
            return Ok(entity);
        }

        [HttpGet("{codigo:int}")]
        public async Task<ActionResult> ObterPorCodigo(int codigo)
        {
            var entity = await _queries.ConsultarClasseManutencaoPorCodigo(codigo);

            if (entity.Count == 0)
            {
                return NotFound("Classe de manutenção não localizada.");
            }
            return Ok(entity);
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult> CadastrarClasseManutencao(int codigo, string descricao)
        {
            if (ModelState.IsValid)
            {
                var command = new CadastrarClasseManutencaoCommand(codigo, descricao);
                await _mediatorHandler.EnviarComando(command);
                return CreatedAtAction("CadastrarClasseManutencao", command);
            }
            return BadRequest();
        }

        [HttpPut("atualizar")]
        public async Task<ActionResult> AtualizarClasseManutencao(int codigo, string descricao)
        {
            if (ModelState.IsValid)
            {
                var command = new AlterarClasseManutencaoCommand(codigo, descricao);
                await _mediatorHandler.EnviarComando(command);
                return Ok(command);
            }
            return NoContent();
        }

        [HttpDelete("excluir/{id:int}")]
        public async Task<ActionResult> ExcluirClasseManutencao(int codigo)
        {
            if (ModelState.IsValid)
            {
                var command = new ExcluirClasseManutencaoCommand(codigo);
                await _mediatorHandler.EnviarComando(command);
                return Ok(command);
            }
            return NoContent();
        }

    }
}
