using MaximoFarm.Register.Application.Commands.Entities.CentroCusto;
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
    [Route("cadastros/v1/centrocusto")]
    public class CentroCustoController : ControllerBase
    {
        private readonly IMediatorHandler _mediartorHandler;
        private readonly ICentroCustoQueries _queries;
        public CentroCustoController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediartorHandler,
            ICentroCustoQueries queries) : base(notifications, mediartorHandler)

        {
            _mediartorHandler = mediartorHandler;
            _queries = queries;
        }

        [HttpGet]
        public async Task<ActionResult> ObterTodos()
        {
            var entity = await _queries.ConsultarCentroCusto();
            if (entity.Count == 0)
            {
                return NoContent();
            }
            return Ok(entity);
        }

        [HttpGet("{codigo:int}")]
        public async Task<ActionResult> ObterPorCodigo(int codigo)
        {
            var entity = await _queries.ConsultarCentroCustoPorCodigo(codigo);

            if (entity.Count == 0)
            {
                return NotFound("Centro de custo não localizado.");
            }
            return Ok(entity);
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult> CadastrarCentroCusto(int codigo, string descricao,bool ativo)
        {
            var command = new CadastrarCentroCustoCommand(codigo, descricao,ativo);
            await _mediartorHandler.EnviarComando(command);
            if (OperacaoValida())
            {
                return CreatedAtAction("CadastrarCentroCusto", command);
            }
            var erros = ObterMensagensErro();
            return BadRequest(erros);
        }

        [HttpPut("atualizar")]
        public async Task<ActionResult> AtualizarCentroCusto(int codigo, string descricao, bool ativo)
        {
            if (ModelState.IsValid)
            {
                var command = new AlterarCentroCustoCommand(codigo, descricao,ativo);
                await _mediartorHandler.EnviarComando(command);
                return Ok(command);
            }
            return NoContent();
        }

        [HttpDelete("excluir/{id:int}")]
        public async Task<ActionResult> ExcluirCentroCusto(int codigo)
        {
            var command = new ExcluirCentroCustoCommand(codigo);

            if (command is not null)
            {
                await _mediartorHandler.EnviarComando(command);
                return Ok(command);
            }
            return NoContent();
        }
    }
}
