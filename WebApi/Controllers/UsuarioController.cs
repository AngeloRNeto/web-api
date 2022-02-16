using Microsoft.AspNetCore.Mvc;
using WebApi.Domain.Models;
using WebApi.Domain.Services;

namespace WebApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        //dependencies
        private readonly ILogger<UsuarioController> _logger;
        private readonly IUsuarioService _services;
      
        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioService service)
        {
            _logger = logger;
            _services = service;
        }

        [HttpPost()]
        public ActionResult Create(Usuario usuario)
        {
            try
            {

                if (usuario == null)
                    return BadRequest("Usuário vazio");

                var userNew = _services.Insert(usuario);

                if (userNew != null)
                {
                    return Ok("Usuário Criado");
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

                var usuario = _services.GetById(id);

                if (usuario == null)
                {
                    return NotFound($"Nenhum usuário para esse Id");
                }

                return Ok(usuario);
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
                var usuarios = _services.GetAll<Usuario>();

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
        public IActionResult Update(Usuario usuario)
        {
            try
            {
                if (usuario == null)
                    return BadRequest("Usuário vazio.");

                var usu = _services.Update(usuario);

                if (usu == null)
                    return BadRequest("Ocorreu um erro.");

                return Ok(usu);

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
                    return Ok("Usuário Excluido.");
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