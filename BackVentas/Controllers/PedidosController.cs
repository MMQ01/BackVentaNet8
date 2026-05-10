using BackVentasADO.Clases.DTO;
using BackVentas.Services;
using BackVentasADO.Models.Clases;
using BackVentasADO.Models.Clases.DTO;
using Microsoft.AspNetCore.Mvc;


namespace BackVentasADO.Controllers
{

    [ApiController]
    public class PedidosController : ControllerBase
    {

        private readonly PedidoServices _pedidoServices;



        public PedidosController(PedidoServices pedidoServices)
        {
            _pedidoServices = pedidoServices;
        }


        [HttpGet]
        [Route("api/Pedidos")]
        public csListaPedidos listarPedidos()
        {
            csListaPedidos res = new csListaPedidos();
            try
            {

                var lista = _pedidoServices.getListaPedidos();

                if (lista.Respuesta == "OK")
                {

                    res.Respuesta = "OK";
                    res.Lista_Pedidos = lista.Lista_Pedidos;

                }
                else
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = lista.Mensaje;
                }

            }
            catch (Exception ex)
            {

                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
                return res;
            }
            return res;
        }

        [HttpGet]
        [Route("api/Pedidos/Cliente")]
        public csListaPedidos listarPedidosXCliente(int identificacion)
        {
            csListaPedidos res = new csListaPedidos();
            try
            {

                var lista = _pedidoServices.getListaPedidosXCliente(identificacion);

                if (lista.Respuesta == "OK")
                {

                    res.Respuesta = "OK";
                    res.Lista_Pedidos = lista.Lista_Pedidos;

                }
                else
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = lista.Mensaje;
                }

            }
            catch (Exception ex)
            {

                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
                return res;
            }
            return res;
        }

        [HttpGet]
        [Route("api/Pedidos/Usuario")]
        public csListaPedidos listarPedidosXUsuario(int identificacion)
        {
            csListaPedidos res = new csListaPedidos();
            try
            {

                var lista = _pedidoServices.getListaPedidosXUsuario(identificacion);

                if (lista.Respuesta == "OK")
                {

                    res.Respuesta = "OK";
                    res.Lista_Pedidos = lista.Lista_Pedidos;

                }
                else
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = lista.Mensaje;
                }

            }
            catch (Exception ex)
            {

                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
                return res;
            }
            return res;
        }

        [HttpGet]
        [Route("api/Pedido")]
        public csPedido getPedido(int pedidoID)
        {
            csPedido res = new csPedido();
            try
            {

                var lPedido = _pedidoServices.getPedido(pedidoID);

                if (lPedido.Respuesta == "OK")
                {

                    res.Respuesta = "OK";
                    res.Pedido = lPedido.Pedido;

                }
                else
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = lPedido.Mensaje;
                }

            }
            catch (Exception ex)
            {

                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
                return res;
            }
            return res;
        }

        [HttpPost]
        [Route("api/Pedidos")]
        public Resultado guardarPedido(PedidoDTO pedido)
        {
            Resultado res = new Resultado();
            try
            {


                var respuesta = _pedidoServices.guardarPedido(pedido);


                if (respuesta.Respuesta == "OK")
                {

                    res.Respuesta = "OK";

                }
                else
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = respuesta.Mensaje;
                }

            }
            catch (Exception ex)
            {

                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
                return res;
            }
            return res;
        }



        [HttpPost]
        [Route("api/Pedidos/InactivarPedido/{PedidoID:int}")]
        public Resultado inactivarPedido([FromBody] int PedidoID)
        {
            Resultado res = new Resultado();
            try
            {

                var lista = _pedidoServices.inactivarPedido(PedidoID);

                if (lista.Respuesta == "OK")
                {

                    res.Respuesta = "OK";

                }
                else
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = lista.Mensaje;
                }

            }
            catch (Exception ex)
            {

                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
                return res;
            }

            return res;
        }

        [HttpPost]
        [Route("api/Pedidos/ActivarPedido/{PedidoID:int}")]
        public Resultado activarPedido([FromBody] int PedidoID)
        {
            Resultado res = new Resultado();
            try
            {

                var lista = _pedidoServices.activarPedido(PedidoID);

                if (lista.Respuesta == "OK")
                {

                    res.Respuesta = "OK";

                }
                else
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = lista.Mensaje;
                }

            }
            catch (Exception ex)
            {

                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
                return res;
            }
            return res;

        }



        //=== CARRITO ===

        [HttpGet]
        [Route("api/Pedidos/Carrito")]
        public csCarrito getCarritoXUsuario(int UsuarioID)
        {
            csCarrito res = new csCarrito();
            try
            {

                var lista = _pedidoServices.getListaProductosCarrito(UsuarioID);

                if (lista.Respuesta == "OK")
                {

                    res.Respuesta = "OK";
                    res.Lista_Productos = lista.Lista_Productos;

                }
                else
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = lista.Mensaje;
                }

            }
            catch (Exception ex)
            {

                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
                return res;
            }
            return res;
        }


        [HttpDelete]
        [Route("api/Pedidos/Carrito/Producto")]
        public Resultado eliminarProductoCarrito(int UsuarioID, int ProductoID)
        {
            Resultado res = new Resultado();
            try
            {

                var lista = _pedidoServices.eliminarProductoCarrito(UsuarioID, ProductoID);

                if (lista.Respuesta == "OK")
                {

                    res.Respuesta = lista.Respuesta;
                    res.Mensaje = lista.Mensaje;
                }
                else
                {
                    res.Respuesta = lista.Respuesta;
                    res.Mensaje = lista.Mensaje;
                }

            }
            catch (Exception ex)
            {

                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
                return res;
            }
            return res;
        }

        [HttpDelete]
        [Route("api/Pedidos/Carrito")]
        public Resultado eliminarCarrito(int UsuarioID)
        {
            Resultado res = new Resultado();
            try
            {

                var lista = _pedidoServices.eliminarCarrito(UsuarioID);

                if (lista.Respuesta == "OK")
                {

                    res.Respuesta = lista.Respuesta;
                    res.Mensaje = lista.Mensaje;
                }
                else
                {
                    res.Respuesta = lista.Respuesta;
                    res.Mensaje = lista.Mensaje;
                }

            }
            catch (Exception ex)
            {

                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
                return res;
            }
            return res;
        }


        [HttpPost]
        [Route("api/Pedidos/Carrito")]
        public Resultado setProductoCarrito([FromBody] csCarritoUpdate carrito)
        {
            Resultado res = new Resultado();
            try
            {

                var lista = _pedidoServices.actualizarProductoCarrito(carrito.Usuario_ID, carrito.Producto_ID, carrito.Cantidad);

                if (lista.Respuesta == "OK")
                {

                    res.Respuesta = lista.Respuesta;
                    res.Mensaje = lista.Mensaje;
                }
                else
                {
                    res.Respuesta = lista.Respuesta;
                    res.Mensaje = lista.Mensaje;
                }

            }
            catch (Exception ex)
            {

                res.Respuesta = "ERROR";
                res.Mensaje = ex.ToString();
                return res;
            }
            return res;
        }

    }
}
