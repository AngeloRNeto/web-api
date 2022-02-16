using Microsoft.AspNetCore.Mvc;
using WebApi.Domain.Models;
using WebApi.Domain.Services;

namespace WebApi.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CarrinhoController : ControllerBase
    {
        //dependencies
        private readonly ILogger<CarrinhoController> _logger;
        private readonly ICarrinhoService _services;
      
        public CarrinhoController(ILogger<CarrinhoController> logger, ICarrinhoService services)
        {
            _logger = logger;
            _services = services;
        }

        [HttpPost()]
        public ActionResult Create(Carrinho carrinho)
        {
            try
            {

                if (carrinho == null)
                    return BadRequest("Carrinho sem valores");

                var categoriaNew = _services.Insert(carrinho);

                if (categoriaNew != null)
                {
                    return Ok("Carrinho Criado");
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

                var categoria = _services.GetById(id);

                if (categoria == null)
                {
                    return NotFound($"Nenhum carrinho para esse Id");
                }

                return Ok(categoria);
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
                var usuarios = _services.GetAll<Carrinho>();

                if (usuarios.Count() > 0)
                    return Ok(usuarios);

                return NotFound("Sem registros.");

            }
            catch (Exception ex)
            {
                BadRequest("Ocorreu um erro \n" + ex.Message);
                throw ex;
            }
        }

        [HttpPut]
        public IActionResult Update(Carrinho carrinho)
        {
            try
            {
                if (carrinho == null)
                    return BadRequest("carrinho vazio.");

                var car = _services.Update(carrinho);

                if (car == null)
                    return BadRequest("Ocorreu um erro.");

                return Ok(car);

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
                    return Ok("Carrinho Excluido.");
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