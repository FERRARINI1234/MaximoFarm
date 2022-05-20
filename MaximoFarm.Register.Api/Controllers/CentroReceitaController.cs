using MaximoFarm.Register.Application.Commands.Entities.CentroReceita;
using MaximoFarm.Register.Application.Queries.Interfaces;
using MaximoFarm.Register.Application.Queries.ViewModels;
using MaximoFarm.Register.Core.Communication;
using MaximoFarm.Register.Core.Messages.CommonMessages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Api.Controllers
{
    [ApiController]
    [Route("cadastros/v1/centroreceita")]
    public class CentroReceitaController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly ICentroReceitaQueries _queries;

        public CentroReceitaController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediartorHandler,
            ICentroReceitaQueries queries) : base(notifications, mediartorHandler)
        {
            _mediatorHandler = mediartorHandler;
            _queries = queries;
        }

        [HttpGet]
        public async Task<ActionResult> ObterTodos()
        {
            var entity = await _queries.ConsultarCentroReceita();

            if (entity.Count == 0)
            {
                return NotFound("Não ");
            }
            return Ok(entity);
        }

        [HttpGet("{codigo:int}")]
        public async Task<ActionResult> ObterPorCodigo(int codigo)
        {
            var entity = await _queries.ConsultarCentroReceitaPorCodigo(codigo);

            if (entity.Count == 0)
            {
                return NotFound("Centro de receita não localizado.");
            }
            return Ok(entity);
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult> CadastrarCentroreceita(int codigo, string descricao, bool ativo)
        {
            if (ModelState.IsValid)
            {
                var command = new CadastrarCentroReceitaCommand(codigo, descricao, ativo);
                await _mediatorHandler.EnviarComando(command);
                return CreatedAtAction("CadastrarCentroreceita", command);
            }
            return BadRequest();
        }

        [HttpPut("atualizar")]
        public async Task<ActionResult> AtualizarCentroReceita(int codigo, string descricao, bool ativo)
        {
            if (ModelState.IsValid)
            {
                var command = new AlterarCentroReceitaCommand(codigo, descricao, ativo);
                await _mediatorHandler.EnviarComando(command);
                return Ok(command);
            }
            return NoContent();
        }

        [HttpDelete("excluir/{id:int}")]
        public async Task<ActionResult> ExcluirCentroreceita(int codigo)
        {
            if (ModelState.IsValid)
            {
                var command = new ExcluirCentroReceitaCommand(codigo);
                await _mediatorHandler.EnviarComando(command);
                return Ok(command);
            }
            return NoContent();
        }
    }
}
