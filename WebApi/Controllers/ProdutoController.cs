using Microsoft.AspNetCore.Mvc;
using WebApi.Domain.Models;
using WebApi.Domain.Services;

namespace WebApi.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        //dependencies
        private readonly ILogger<ProdutoController> _logger;
        private readonly IProdutoService _services;

        public ProdutoController(ILogger<ProdutoController> logger, IProdutoService services)
        {
            _logger = logger;
            _services = services;
        }

        [HttpPost()]
        public ActionResult Create(Produto produto)
        {
            try
            {

                if (produto == null)
                    return BadRequest("Produto vazio");

                var produtoNew = _services.Insert(produto);

                if (produtoNew != null)
                {
                    return Ok("Produto Criado");
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

                var produto = _services.GetById(id);

                if (produto == null)
                {
                    return NotFound($"Nenhum produto para esse Id");
                }

                return Ok(produto);
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
                var produtos = _services.GetAll<Produto>();

                if (produtos.Count() > 0)
                    return Ok(produtos);

                return NotFound("Sem registros.");

            }
            catch (Exception ex)
            {
                BadRequest("Ocorreu um erro \n" + ex.Message);
                throw ex;
            }
        }

        [HttpPut]
        public IActionResult Update(Produto produto)
        {
            try
            {
                if (produto == null)
                    return BadRequest("Produto vazio.");

                var prod = _services.Update(produto);

                if (prod == null)
                    return BadRequest("Ocorreu um erro.");

                return Ok(prod);

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
                _services.Delete(id);
                return Ok("Produto Excluido.");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro \n" + ex.Message);
                //throw ex;
            }
        }
    }
}