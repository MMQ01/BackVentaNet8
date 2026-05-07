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
    public class PedidosController : ControllerBase
    {
        IPedidos pedidoServicio;
        public PedidosController(IPedidos pedidosServicio)
        {
            this.pedidoServicio=pedidosServicio;
        }

        [HttpPost]
        public IActionResult guardarPedido(CrearPedidoViewModel pedido)
        {
            Resultado res = new Resultado();
            try
            {

               
                res.Respuesta = this.pedidoServicio.guardarPedido(pedido);
                res.Mensaje = "OK";
               
            }
            catch (Exception)
            {

                res.Mensaje = "Error";
                return BadRequest(res);
            }

            return Ok(res);

        }

        [HttpGet("{identificacion}")]
        
        public IActionResult listarPedidosXCliente(int identificacion)
        {
            Resultado res = new Resultado();
            try
            {

                var lista = this.pedidoServicio.verPedidosXCliente(identificacion);
                res.Respuesta = lista;
                if(lista == null)
                {
                    res.Respuesta="Sin pedidos";
                }
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
        [Route("InactivarPedido")]
        public IActionResult inactivarPedido([FromBody]  int id)
        {
            Resultado res = new Resultado();
            try
            {

                var pedido = this.pedidoServicio.inactivarPedido(id);

                res.Respuesta = pedido;
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
        [Route("ActivarPedido")]
        public IActionResult activarPedido([FromBody] int id)
        {
            Resultado res = new Resultado();
            try
            {

                var pedido = this.pedidoServicio.activarPedido(id);

                res.Respuesta = pedido;
                res.Mensaje = "OK";
            }
            catch (Exception)
            {

                res.Mensaje = "Error";
                return BadRequest(res);
            }

            return Ok(res);

        }

        [HttpDelete]
        public IActionResult borrarPedido(int id)
        {
            Resultado res = new Resultado();
            try
            {

                var pedido = this.pedidoServicio.borrarPedido(id);

                res.Respuesta = pedido;
                res.Mensaje = "OK";
            }
            catch (Exception)
            {

                res.Mensaje = "Error";
                return BadRequest(res);
            }

            return Ok(res);
        }

        [HttpGet]
    
        public IActionResult listarPedidose()
        {
            Resultado res = new Resultado();
            try
            {

                var lista = this.pedidoServicio.verPedidos();
                res.Respuesta = lista;
                if (lista == null)
                {
                    res.Respuesta = "Sin pedidos";
                }
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
