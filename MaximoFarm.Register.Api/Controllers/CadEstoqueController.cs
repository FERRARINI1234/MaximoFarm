using MaximoFarm.Register.Application.Commands.Entities.CadEstoque;
using MaximoFarm.Register.Application.Queries.Interfaces;
using MaximoFarm.Register.Core.Communication;
using MaximoFarm.Register.Core.Messages.CommonMessages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Threading.Tasks;
using System.Text.Json;
using MaximoFarm.Register.Domain.Entities;
using MaximoFarm.Register.Data.Cache;

namespace MaximoFarm.Register.Api.Controllers
{
    [ApiController]
    [Route("cadastros/v1/estoque")]
    public class CadEstoqueController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly ICadEstoqueQueries _queries;

        public CadEstoqueController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediatorHandler,
            ICadEstoqueQueries queries) : base(notifications, mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _queries = queries;
        }

        [HttpGet]
        public async Task<ActionResult> ObterTodos()
        {
            var entity = await _queries.ConsultarCadastroEstoque();
            if (entity.Count == 0)
            {
                return NoContent();
            }
            return Ok(entity);
        }

        [HttpGet("{codigo:int}")]
        public async Task<ActionResult> ObterPorCodigo(int codigo)
        {
            var entity = await _queries.ConsultarCadastroEstoquePorCodigo(codigo);

            if (entity.Count == 0)
            {
                return NotFound("Estoque não localizado.");
            }
            return Ok(entity);
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult> CadastrarEstoque(int codigo, string descricao)
        {

            if (ModelState.IsValid)
            {
                var command = new CadastrarEstoqueCommand(codigo, descricao);
                await _mediatorHandler.EnviarComando(command);
                return CreatedAtAction("CadastrarEstoque", command);
            }
            return BadRequest();
        }

        [HttpPut("atualizar")]
        public async Task<ActionResult> AtualizarEstoque(int codigo, string descricao)
        {
            if (ModelState.IsValid)
            {
                var command = new AlterarEstoqueCommand(codigo, descricao);
                await _mediatorHandler.EnviarComando(command);
                return Ok(command);
            }
            return NoContent();
        }

        [HttpDelete("{codigo:int}")]
        public async Task<ActionResult> ExcluirEstoque(int codigo)
        {
            if (ModelState.IsValid)
            {
                var command = new ExcluirEstoqueCommand(codigo);
                await _mediatorHandler.EnviarComando(command);
                return Ok(command);
            }
            return NoContent();
        }
    }
}
