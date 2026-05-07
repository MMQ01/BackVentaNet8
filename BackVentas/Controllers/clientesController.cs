using BackVentas.Modelos;
using BackVentas.Modelos.ViewModel_DTO_;
using BackVentas.Servicios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class clientesController : ControllerBase
    {
        private readonly IClientes clientesService;

        public clientesController(IClientes clientesServices)
        {
            this.clientesService = clientesServices;
        }


        [HttpGet]
       
        public IActionResult getClientes()
        {
            Resultado res = new Resultado();
            try
            {

                var lista = this.clientesService.GetClientes();
                res.Respuesta = lista;
                res.Mensaje = "OK";
            }
            catch (Exception)
            {

                res.Mensaje = "Error";
                return BadRequest(res);
            }

            return Ok(res);
        }

        [HttpPost]
        public IActionResult crearCliente([FromBody] crearClienteViewModel cli)
        {
            Resultado res = new Resultado();
            try
            {

                var cliente = this.clientesService.crearCliente(cli);
                res.Respuesta = cliente;
                res.Mensaje = "OK";
                if (cliente == null)
                {
                    res.Respuesta= "Identificacion del cliente ya existe";
                }
            }
            catch (Exception)
            {

                res.Mensaje = "Error";
                return BadRequest(res);
            }

            return Ok(res);
        }


        [HttpGet("{id}")]
        public ActionResult getCliente(int id)
        {
            Resultado res = new Resultado();
            try
            {

                var cliente = this.clientesService.getCliente(id);
                res.Respuesta = cliente;
                res.Mensaje = "OK";

                if (cliente == null)
                {
                    res.Respuesta = "Cliente no existe";
                }
            }
            catch (Exception)
            {

                res.Mensaje = "Error";
                return BadRequest(res);
            }

            return Ok(res);
        }

        [HttpPut]
        public ActionResult editarCliente(editarClienteViewModel cli)
        {
            Resultado res = new Resultado();
            try
            {

                var cliente = this.clientesService.editarCliente(cli);
                res.Respuesta = cliente;
                res.Mensaje = "OK";
            }
            catch (Exception)
            {

                res.Mensaje = "Error";
                return BadRequest(res);
            }

            return Ok(res);
        }

        [HttpPost]
        [Route("InactivarCliente")]
        public IActionResult inactivarCliente([FromBody] int id)
        {
            Resultado res = new Resultado();
            try
            {

                var cliente = this.clientesService.inactivarCliente(id);

                res.Respuesta = cliente;
                res.Mensaje = "OK";
            }
            catch (Exception)
            {

                res.Mensaje = "Error";
                return BadRequest(res);
            }

            return Ok(res);

        }

        [HttpPost]
        [Route("ActivarCliente")]
        public IActionResult activarCliente([FromBody] int id)
        {
            Resultado res = new Resultado();
            try
            {

                var cliente = this.clientesService.activarCliente(id);

                res.Respuesta = cliente;
                res.Mensaje = "OK";
            }
            catch (Exception)
            {

                res.Mensaje = "Error";
                return BadRequest(res);
            }

            return Ok(res);

        }

        [HttpDelete("{id}")]
        public IActionResult deleteCliente( int id)
        {
            Resultado res = new Resultado();
            try
            {

                var cliente = this.clientesService.deleteCliente(id);

                res.Respuesta = cliente;
                res.Mensaje = "OK";
            }
            catch (Exception)
            {

                res.Mensaje = "Error";
                return BadRequest(res);
            }

            return Ok(res);
        }
    }
}
