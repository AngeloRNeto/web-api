using Microsoft.AspNetCore.Mvc;
using WebApi.Domain.Models;
using WebApi.Domain.Services;

namespace WebApi.Controllers
{
    [Route("api/address")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        //dependencies
        private readonly ILogger<EnderecoController> _logger;
        private readonly IEnderecoService _services;
      
        public EnderecoController(ILogger<EnderecoController> logger, IEnderecoService services)
        {
            _logger = logger;
            _services = services;
        }

        [HttpPost()]
        public ActionResult Create(Endereco endereco)
        {
            try
            {

                if (endereco == null)
                    return BadRequest("Usuário vazio");

                var enderecoNew = _services.Insert(endereco);

                if (enderecoNew != null)
                {
                    return Ok("Endereço Criado");
                }
                else
                {
                    return BadRequest("Ocorreu um erro.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro. \n" + ex.Message);
                throw ex;
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                if (id == null)
                    return BadRequest("Id vazio");

                var endereco = _services.GetById(id);

                if (endereco == null)
                {
                    return NotFound($"Nenhum endereço para esse Id");
                }

                return Ok(endereco);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro \n" + ex.Message);
                //throw ex;
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var enderecos = _services.GetAll<Endereco>();

                if (enderecos.Count() > 0)
                    return Ok(enderecos);

                return NotFound("Sem registros.");

            }
            catch (Exception ex)
            {
                BadRequest("Ocorreu um erro \n" + ex.Message);
                throw ex;
            }
        }

        [HttpPut]
        public IActionResult Update(Endereco endereco)
        {
            try
            {
                if (endereco == null)
                    return BadRequest("Endereço vazio.");

                var end = _services.Update(endereco);

                if (end == null)
                    return BadRequest("Ocorreu um erro.");

                return Ok(end);

            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro. \n" + ex.Message);
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                //if (_services.HasProduto(id))
                //{
                    _services.Delete(id);
                    return Ok("Endereço Excluido.");
                //}
                //else
                //{

                //    return BadRequest("Não é possivel fazer a exclusão, categoria anexada a um produto.");
                //}


            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro \n" + ex.Message);
                //throw ex;
            }
        }
    }
}