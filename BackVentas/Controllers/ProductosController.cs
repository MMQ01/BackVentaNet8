using BackVentas.Services;
using BackVentasADO.Models.Clases;
using BackVentasADO.Models.Clases.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BackVentas.Controllers
{
    public class ProductosController : ControllerBase
    {

        private readonly ProductosServices _productoService;



        public ProductosController(ProductosServices productosServices)
        {
            _productoService = productosServices;
        }

        [HttpGet]
        [Route("api/Produsctos/ProductosAll")]
        public csListaProducto getProductosAll()
        {

            csListaProducto res = new csListaProducto();
            try
            {

                var lista = _productoService.getProductos(null, null);

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

        [HttpGet]
        [Route("api/Productos/ProductosAllWeb")]
        public csListaProducto getProductosAllWeb()
        {

            csListaProducto res = new csListaProducto();
            try
            {

                var lista = _productoService.getProductosWeb(null, null);

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


        [HttpGet]
        [Route("api/Productos/ProductoPalabraClave")]
        public csListaProducto getProductosPalabraClave(string pPalabraClave)
        {

            csListaProducto res = new csListaProducto();
            try
            {

                var lista = _productoService.getProductosPalabraClave(pPalabraClave);

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

        [HttpGet]
        [Route("api/Productos/getProductosSync")]
        public csListaProducto getProductosSync(int UsuarioID)
        {

            csListaProducto res = new csListaProducto();
            try
            {

                var lista = _productoService.getProductosSync(true, UsuarioID);

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

        [HttpGet]
        [Route("api/Productos/ProductosActivos")]
        public csListaProducto getProductosActivos(int UsuarioID)
        {

            csListaProducto res = new csListaProducto();
            try
            {

                var lista = _productoService.getProductos(true, UsuarioID);

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



        [HttpGet]
        [Route("api/Productos")]
        public csProducto getProducto(int Id, string SKU)
        {
            csProducto res = new csProducto();
            try
            {

                var producto = _productoService.getProducto(Id, SKU);

                if (producto.Respuesta == "OK")
                {

                    res.Respuesta = "OK";
                    res.Producto = producto.Producto;

                }
                else
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = producto.Mensaje;
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
        [Route("api/Productos/Crear")]
        public Resultado createProducto([FromBody] ProductoDTO prod)
        {
            Resultado res = new Resultado();
            try
            {


                var producto = _productoService.crearProducto(prod);


                if (producto.Respuesta == "OK")
                {

                    res.Respuesta = "OK";

                }
                else
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = producto.Mensaje;
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
        [Route("api/Productos/InactivarProducto")]

        public Resultado inactivarProducto([FromBody] ProductoID prod)
        {
            Resultado res = new Resultado();
            try
            {

                var producto = _productoService.inactivarProducto(prod.Id, prod.SKU);

                if (producto.Respuesta == "OK")
                {

                    res.Respuesta = "OK";

                }
                else
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = producto.Mensaje;
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
        [Route("api/Productos/ActivarProducto")]
        public Resultado activarProducto([FromBody] ProductoID prod)
        {
            Resultado res = new Resultado();
            try
            {

                var producto = _productoService.activarProducto(prod.Id, prod.SKU);

                if (producto.Respuesta == "OK")
                {

                    res.Respuesta = "OK";

                }
                else
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = producto.Mensaje;
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

        [HttpPut]
        [Route("api/Productos")]
        public Resultado editarProducto([FromBody] ProductoDTO prod)
        {
            Resultado res = new Resultado();
            try
            {

                var producto = _productoService.editProducto(prod);

                if (producto.Respuesta == "OK")
                {

                    res.Respuesta = "OK";

                }
                else
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = producto.Mensaje;
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
        [Route("api/Productos/ProductosFavoritos")]
        public csListaProducto getProductosFavoritos(int UsuarioID)
        {

            csListaProducto res = new csListaProducto();
            try
            {

                var lista = _productoService.getProductosFavoritos(UsuarioID);

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

        [HttpPost]
        [Route("api/Productos/setProductoFavorito")]
        public Resultado setProductoFavorito([FromBody] ProductoFavoritoRequest req)
        {
            Resultado producto = new Resultado();

            Resultado res = new Resultado();
            try
            {

                if (req.Activar)
                {

                    producto = _productoService.agregarFavorito(req.ProductoID, req.UsuarioID);
                }
                else
                {

                    producto = _productoService.eliminarFavorito(req.ProductoID, req.UsuarioID);
                }


                if (producto.Respuesta == "OK")
                {

                    res.Respuesta = "OK";

                }
                else
                {
                    res.Respuesta = "ERROR";
                    res.Mensaje = producto.Mensaje;
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
