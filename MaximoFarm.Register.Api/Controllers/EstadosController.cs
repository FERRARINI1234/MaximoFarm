using MaximoFarm.Register.Application.Commands.Entities.Estados;
using MaximoFarm.Register.Application.Queries.Interfaces;
using MaximoFarm.Register.Core.Communication;
using MaximoFarm.Register.Core.Messages.CommonMessages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Api.Controllers
{
    [ApiController]
    [Route("cadastros/v1/estados")]
    public class EstadosController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IEstadosQueries _queries;

        public EstadosController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediatorHandler,
            IEstadosQueries queries) : base(notifications, mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _queries = queries;
        }
        [HttpGet]
        public async Task<ActionResult> ObterTodos()
        {
            var entity = await _queries.ConsultarEstados();
            if (entity.Count == 0)
            {
                return NoContent();
            }
            return Ok(entity);
        }
        [HttpGet("{codigo:int}")]
        public async Task<ActionResult> ObterPorCodigo(int codigo)
        {
            var entity = await _queries.ConsultarEstadosPorCodigo(codigo);

            if (entity.Count == 0)
            {
                return NotFound("Estado não localizado.");
            }
            return Ok(entity);
        }
        [HttpPost("cadastrar")]
        public async Task<ActionResult> CadastrarEstado(int codigo, string descricao, string abreviacao)
        {
            if (ModelState.IsValid)
            {
                var command = new CadastrarEstadoCommand(codigo, descricao, abreviacao);
                await _mediatorHandler.EnviarComando(command);
                return CreatedAtAction("CadastrarEstado", command);
            }
            return BadRequest();
        }
        [HttpPut("atualizar")]
        public async Task<ActionResult> AtualizarEstado(int codigo, string descricao, string abreviacao)
        {
            if (ModelState.IsValid)
            {
                var command = new AlterarEstadoCommand(codigo, descricao, abreviacao);
                await _mediatorHandler.EnviarComando(command);
                return Ok(command);
            }
            return NoContent();
        }
        [HttpDelete("excluir/{id:int}")]
        public async Task<ActionResult> ExcluirEstados(int codigo)
        {
            if (ModelState.IsValid)
            {
                var command = new ExcluirEstadoCommand(codigo);
                await _mediatorHandler.EnviarComando(command);
                return Ok(command);
            }
            return NoContent();
        }
    }
}

