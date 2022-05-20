//using MaximoFarm.Register.Application.AppServices.Interfaces;
//using MaximoFarm.Register.Application.DTOs;
//using Microsoft.AspNetCore.Mvc;
//using System.Threading.Tasks;

//namespace MaximoFarm.Register.Api.Controllers
//{
//    [ApiController]
//    [Route("cadastros/v1/espacamentos")]
//    public class EspacamentoController : ControllerBase
//    {
//        private readonly IEspacamentoService _service;
//        public EspacamentoController(IEspacamentoService service)
//        {
//            _service = service;
//        }

//        [HttpGet]
//        public async Task<ActionResult> ObterTodos()
//        {
//            var entity = await _service.ConsultarEspacamento();

//            if (entity.Count == 0)
//            {
//                return NoContent();
//            }
//            return Ok(entity);
//        }

//        [HttpGet("{codigo:int}")]
//        public async Task<ActionResult> ObterPorCodigo(int codigo)
//        {
//            var entity = await _service.ConsultarEspacamentoPorCodigo(codigo);

//            if (entity.Count == 0)
//            {
//                return NotFound("Espacamento não localizada.");
//            }
//            return Ok(entity);
//        }

//        [HttpPost("cadastrar")]
//        public async Task<ActionResult> CadastrarEspacamento(EspacamentoDto espacamentoDto)
//        {
//            if (ModelState.IsValid)
//            {
//                await _service.CadastrarNovoEspacamento(espacamentoDto);
//                return CreatedAtAction("CadastrarEspacamento", espacamentoDto);
//            }
//            return BadRequest();
//        }

//        [HttpPut("atualizar")]
//        public ActionResult AtualizarEspacamento(EspacamentoDto espacamentoDto)
//        {
//            if (ModelState.IsValid)
//            {
//                _service.AtualizarEspacamento(espacamentoDto);
//                return Ok(espacamentoDto);
//            }
//            return NoContent();
//        }

//        [HttpDelete("excluir/{id:int}")]
//        public async Task<ActionResult<EspacamentoDto>> ExcluirEspacamento(int codigo)
//        {
//            var entity = await _service.ExcluirEspacamento(codigo);
//            if (entity is null)
//            {
//                return NoContent();
//            }
//            return Ok(entity);
//        }

//    }
//}
//}
