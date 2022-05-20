using MaximoFarm.Register.Application.Commands.Entities.Ciclo;
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
    [Route("cadastros/v1/ciclos")]
    public class CicloController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly ICicloQueries _queries;
        public CicloController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediatorHandler,
            ICicloQueries queries) : base(notifications, mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _queries = queries;
        }

        [HttpGet]
        public async Task<ActionResult> ObterTodos()
        {
            var entity = await _queries.ConsultarCiclos();
            if (entity.Count == 0)
            {
                return NoContent();
            }
            return Ok(entity);
        }

        [HttpGet("{codigo:int}")]
        public async Task<ActionResult> ObterPorCodigo(int codigo)
        {
            var entity = await _queries.ConsultarCiclosPorCodigo(codigo);

            if (entity.Count == 0)
            {
                return NotFound("Ciclo não localizado.");
            }
            return Ok(entity);
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult> CadastrarCiclo(int codigo, string descricao, bool ativo)
        {
            if (ModelState.IsValid)
            {
                var command = new CadastrarCicloCommand(codigo, descricao, ativo);
                await _mediatorHandler.EnviarComando(command);
                return CreatedAtAction("CadastrarCiclo", command);
            }
            return BadRequest();
        }

        [HttpPut("atualizar")]
        public async Task<ActionResult> AtualizarCiclo(int codigo, string descricao, bool ativo)
        {
            if (ModelState.IsValid)
            {
                var command = new AlterarCicloCommand(codigo, descricao, ativo);
                await _mediatorHandler.EnviarComando(command);
                return Ok(command);
            }
            return NoContent();
        }

        [HttpDelete("excluir/{cod:int}")]
        public async Task<ActionResult> ExcluirCiclo(int codigo)
        {
            if (ModelState.IsValid)
            {
                var command = new ExcluirCicloCommand(codigo);
                await _mediatorHandler.EnviarComando(command);
                return Ok(command);
            }
            return NoContent();
        }
    }
}
