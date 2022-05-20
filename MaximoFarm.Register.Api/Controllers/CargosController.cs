using MaximoFarm.Register.Application.Commands.Entities.Cargos;
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
    [Route("cadastros/v1/cargos")]
    public class CargosController : ControllerBase
    {
        private readonly IMediatorHandler _mediartorHandler;
        private readonly ICargosQueries _queries;
        public CargosController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediartorHandler,
            ICargosQueries queries) : base(notifications, mediartorHandler)

        {
            _mediartorHandler = mediartorHandler;
            _queries = queries;
        }

        /// <summary>
        /// Retorna uma lista com todos os itens existentes na base.
        /// </summary>
        /// <returns>200 if sucess, 204 if error</returns>
        [HttpGet]
        public async Task<ActionResult> ObterTodos()
        {
            var entity = await _queries.ConsultarCargos();

            if (entity.Count == 0)
            {
                return NotFound("Não existem registros.");
            }
            return Ok(entity);
        }

        /// <summary>
        /// Retorna uma lista com os itens que atendem o critério da pesquisa
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns>200 if sucess, 204 if error</returns>
        [HttpGet("{codigo:int}")]
        public async Task<ActionResult> ObterPorCodigo(int codigo)
        {
            var entity = await _queries.ConsultarCargosPorCodigo(codigo);

            if (entity.Count == 0)
            {
                return NotFound("Cargo não localizado.");
            }
            return Ok(entity);
        }

        /// <summary>
        /// Adiciona um novo item
        /// </summary>
        /// <param name="cargosDto"></param>
        /// <returns>201 if sucess, 400 if error</returns>
        [HttpPost("cadastrar")]
        public async Task<ActionResult> CadastrarCargo(int codigo, string descricao)
        {

            var command = new CadastrarCargoCommand(codigo, descricao);
            await _mediartorHandler.EnviarComando(command);
            if (OperacaoValida())
            {
                return CreatedAtAction("CadastrarCargo", command);
            }
            var erros = ObterMensagensErro();
            return BadRequest(erros);
        }

        /// <summary>
        /// Atualiza um item existente
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="descricao"></param>
        /// <returns>200 if sucess, 204 if error</returns>
        [HttpPut("atualizar")]
        public async Task<ActionResult> AtualizarCargo(int codigo, string descricao)
        {
            if (ModelState.IsValid)
            {
                var command = new AlterarCargoCommand(codigo, descricao);
                await _mediartorHandler.EnviarComando(command);
                return Ok(command);
            }
            return NoContent();
        }

        /// <summary>
        /// Exclui um item existente através do codigo
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns>200 if sucess, 204 if error</returns>
        [HttpDelete("excluir/{id:int}")]
        public async Task<ActionResult> ExcluirCargo(int codigo)
        {
            var command = new ExcluirCargoCommand(codigo);

            if (command is not null)
            {
                await _mediartorHandler.EnviarComando(command);
                return Ok(command);
            }
            return NoContent();
        }
    }
}

