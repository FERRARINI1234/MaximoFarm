using MaximoFarm.Register.Application.Commands.Entities.ContaReceita;
using MaximoFarm.Register.Application.Queries.Interfaces;
using MaximoFarm.Register.Core.Communication;
using MaximoFarm.Register.Core.Messages.CommonMessages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Api.Controllers
{
    [ApiController]
    [Route("cadastros/v1/conta-receita")]
    public class ContaReceitaController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IContaReceitaQueries _queries;

        public ContaReceitaController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediatorHandler,
            IContaReceitaQueries queries) : base(notifications, mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _queries = queries;
        }
        [HttpGet]
        public async Task<ActionResult> ObterTodos()
        {
            var entity = await _queries.ConsultarContaReceita();
            if (entity.Count == 0)
            {
                return NoContent();
            }
            return Ok(entity);
        }

        [HttpGet("{codigo:int}")]
        public async Task<ActionResult> ObterPorCodigo(int codigo)
        {
            var entity = await _queries.ConsultarContaReceitaPorCodigo(codigo);

            if (entity.Count == 0)
            {
                return NotFound("Conta Receita não localizada.");
            }
            return Ok(entity);
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult> CadastrarContaReceita(int codigo, string descricao, bool ativo)
        {
            if (ModelState.IsValid)
            {
                var command = new CadastrarContaReceitaCommand(codigo, descricao, ativo);
                await _mediatorHandler.EnviarComando(command);
                return CreatedAtAction("CadastrarContaReceita", command);
            }
            return BadRequest();
        }

        [HttpPut("atualizar")]
        public async Task<ActionResult> AtualizarContaReceita(int codigo, string descricao, bool ativo)
        {
            if (ModelState.IsValid)
            {
                var command = new AlterarContaReceitaCommand(codigo, descricao, ativo);
                await _mediatorHandler.EnviarComando(command);
                return Ok(command);
            }
            return NoContent();
        }

        [HttpDelete("excluir/{id:int}")]
        public async Task<ActionResult> ExcluirContaReceita(int codigo)
        {
            if (ModelState.IsValid)
            {
                var command = new ExcluirContaReceitaCommand(codigo);
                await _mediatorHandler.EnviarComando(command);
                return Ok(command);
            }
            return NoContent();
        }
    }
}
