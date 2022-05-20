using MaximoFarm.Register.Application.Commands.Entities.Safras;
using MaximoFarm.Register.Application.Queries.Interfaces;
using MaximoFarm.Register.Core.Communication;
using MaximoFarm.Register.Core.Messages.CommonMessages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Api.Controllers
{
    [ApiController]
    [Route("cadastros/v1/safras")]
    public class SafraController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly ISafraQueries _queries;

        public SafraController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediatorHandler,
            ISafraQueries queries) : base(notifications, mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _queries = queries;
        }

        [HttpGet]
        public async Task<ActionResult> ObterTodos()
        {
            var entity = await _queries.ConsultarSafras();
            if (entity.Count == 0)
            {
                return NoContent();
            }
            return Ok(entity);
        }

        [HttpGet("{codigo:int}")]
        public async Task<ActionResult> ObterPorCodigo(int codigo)
        {
            var entity = await _queries.ConsultarSafrasPorCodigo(codigo);

            if (entity.Count == 0)
            {
                return NotFound("Safra não localizada.");
            }
            return Ok(entity);
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult> CadastrarSafra(int codigo, string descricao)
        {
            if (ModelState.IsValid)
            {
                var command = new CadastrarSafraCommand(codigo, descricao);
                await _mediatorHandler.EnviarComando(command);
                return CreatedAtAction("CadastrarSafra", command);
            }
            return BadRequest();
        }

        [HttpPut("atualizar")]
        public async Task<ActionResult> AtualizarSafra(int codigo, string descricao)
        {
            if (ModelState.IsValid)
            {
                var command = new AlterarSafraCommand(codigo, descricao);
                await _mediatorHandler.EnviarComando(command);
                return Ok(command);
            }
            return NoContent();
        }

        [HttpDelete("excluir/{id:int}")]
        public async Task<ActionResult> ExcluirSafra(int codigo)
        {
            if (ModelState.IsValid)
            {
                var command = new ExcluirSafraCommand(codigo);
                await _mediatorHandler.EnviarComando(command);
                return Ok(command);
            }
            return NoContent();
        }
    }
}
