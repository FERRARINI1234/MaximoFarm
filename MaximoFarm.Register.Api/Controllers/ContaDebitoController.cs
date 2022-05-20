using MaximoFarm.Register.Application.Commands.Entities.ContaDebito;
using MaximoFarm.Register.Application.Queries.Interfaces;
using MaximoFarm.Register.Core.Communication;
using MaximoFarm.Register.Core.Messages.CommonMessages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Api.Controllers
{
    [ApiController]
    [Route("cadastros/v1/conta-debito")]
    public class ContaDebitoController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IContaDebitoQueries _queries;

        public ContaDebitoController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediatorHandler,
            IContaDebitoQueries queries) : base(notifications, mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _queries = queries;
        }
        [HttpGet]
        public async Task<ActionResult> ObterTodos()
        {
            var entity = await _queries.ConsultarContaDebito();
            if (entity.Count == 0)
            {
                return NoContent();
            }
            return Ok(entity);
        }

        [HttpGet("{codigo:int}")]
        public async Task<ActionResult> ObterPorCodigo(int codigo)
        {
            var entity = await _queries.ConsultarContaDebitoPorCodigo(codigo);

            if (entity.Count == 0)
            {
                return NotFound("Conta Débito não localizada.");
            }
            return Ok(entity);
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult> CadastrarContaDebito(int codigo, string descricao, bool ativo)
        {
            if (ModelState.IsValid)
            {
                var command = new CadastrarContaDebitoCommand(codigo, descricao,ativo);
                await _mediatorHandler.EnviarComando(command);
                return CreatedAtAction("CadastrarContaDebito", command);
            }
            return BadRequest();
        }

        [HttpPut("atualizar")]
        public async Task<ActionResult> AtualizarContaDebito(int codigo, string descricao, bool ativo)
        {
            if (ModelState.IsValid)
            {
                var command = new AlterarContaDebitoCommand(codigo, descricao,ativo);
                await _mediatorHandler.EnviarComando(command);
                return Ok(command);
            }
            return NoContent();
        }

        [HttpDelete("excluir/{id:int}")]
        public async Task<ActionResult> ExcluirContaDebito(int codigo)
        {
            if (ModelState.IsValid)
            {
                var command = new ExcluirContaDebitoCommand(codigo);
                await _mediatorHandler.EnviarComando(command);
                return Ok(command);
            }
            return NoContent();
        }
    }
}
