using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApi.Domain.Models;
using WebApi.Domain.Services;

namespace WebApi.Controllers
{
    [Route("api/client")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        //dependencies
        private readonly ILogger<ClienteController> _logger;
        private readonly IClienteService _services;

        public ClienteController(ILogger<ClienteController> logger, IClienteService services)
        {
            _logger = logger;
            _services = services;
        }

        [HttpPost()]
        public ActionResult Create(Cliente cliente)
        {
            try
            {

                if (cliente == null)
                    return BadRequest("Cliente vazio");

                var clienteNew = _services.Insert(cliente);

                if (clienteNew != null)
                {
                    return Ok("Cliente Criado");
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

                var cliente = _services.GetById(id);

                if (cliente == null)
                {
                    return NotFound($"Nenhum cliente para esse Id");
                }

                cliente.cliente_dados.ToList().ForEach(e => e.cliente = null);
                return Ok(JsonSerializer.Serialize(cliente, new JsonSerializerOptions()
                {
                    MaxDepth = 0,
                    IgnoreReadOnlyProperties = true
                }));
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
                var clientes = _services.GetAll<Cliente>();

                if (clientes.Count() > 0)
                {
                    return Ok(JsonSerializer.Serialize(clientes, new JsonSerializerOptions()
                    {
                        MaxDepth = 0,
                        IgnoreReadOnlyProperties = true
                    }));
                }

                return NotFound("Sem registros.");

            }
            catch (Exception ex)
            {
                BadRequest("Ocorreu um erro \n" + ex.Message);
                throw ex;
            }
        }

        [HttpPut]
        public IActionResult Update(Cliente cliente)
        {
            try
            {
                if (cliente == null)
                    return BadRequest("Cliente vazio.");

                var usu = _services.Update(cliente);

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
                return Ok("Cliente Excluido.");
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