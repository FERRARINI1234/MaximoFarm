using MaximoFarm.Register.Application.Commands.Entities.Cidades;
using MaximoFarm.Register.Application.Commands.Entities.Safras;
using MaximoFarm.Register.Application.Queries;
using MaximoFarm.Register.Application.Queries.Interfaces;
using MaximoFarm.Register.Core.Communication;
using MaximoFarm.Register.Core.Messages.CommonMessages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Api.Controllers
{
    [ApiController]
    [Route("cadastros/v1/cidades")]
    public class CidadesController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly ICidadeQueries _queries;

        public CidadesController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediatorHandler,
            ICidadeQueries queries) : base(notifications, mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _queries = queries;
        }

        [HttpGet]
        public async Task<ActionResult> ObterTodos()
        {
            var entity = await _queries.ConsultarCidades();
            if (entity.Count == 0)
            {
                return NoContent();
            }
            return Ok(entity);
        }

        [HttpGet("{codigo:int}")]
        public async Task<ActionResult> ObterPorCodigo(int codigo)
        {
            var entity = await _queries.ConsultarCidadesPorCodigo(codigo);

            if (entity.Count == 0)
            {
                return NotFound("Cidade não localizada.");
            }
            return Ok(entity);
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult> CadastrarCidade(int codigo, string descricao,int codEstado)
        {
            if (ModelState.IsValid)
            {
                var command = new CadastrarCidadeCommand(codigo, descricao,codEstado);
                await _mediatorHandler.EnviarComando(command);
                return CreatedAtAction("CadastrarCidade", command);
            }
            return BadRequest();
        }

        [HttpPut("atualizar")]
        public async Task<ActionResult> AtualizarCidade(int codigo, string descricao, int codEstado)
        {
            if (ModelState.IsValid)
            {
                var command = new AlterarCidadeCommand(codigo, descricao,codEstado);
                await _mediatorHandler.EnviarComando(command);
                return Ok(command);
            }
            return NoContent();
        }

        [HttpDelete("excluir/{id:int}")]
        public async Task<ActionResult> ExcluirCidade(int codigo)
        {
            if (ModelState.IsValid)
            {
                var command = new ExcluirCidadeCommand(codigo);
                await _mediatorHandler.EnviarComando(command);
                return Ok(command);
            }
            return NoContent();
        }
    }
}
