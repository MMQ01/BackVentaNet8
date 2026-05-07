using BackVentas.Modelos;
using BackVentas.Modelos.ViewModel_DTO_;
using BackVentas.Servicios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProductosController : ControllerBase
    {
        private readonly IProductos productosServices;

        public ProductosController(IProductos productosServices)
        {

            this.productosServices  = productosServices;

        }

        [HttpPost]
        [Route("Crear")]
        public IActionResult createProducto([FromBody]ProductoViewModel prod)
        {
            Resultado res = new Resultado();
            try
            {

                var producto = this.productosServices.crearProducto(prod);


                res.Respuesta = producto;
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
        [Route("ProductosActivos")]
        public IActionResult getProductosActivos()
        {
            Resultado res = new Resultado();
            try
            {

                var lista = this.productosServices.getProductosActivos();
                res.Respuesta = lista;
                res.Mensaje = "OK";
            }
            catch (Exception)
            {

                res.Mensaje ="Error";
                return BadRequest(res);
            }

            return Ok(res);

        }

        [HttpGet]
        [Route("ProductosAll")]
        public IActionResult getProductosAll()
        {
            Resultado res = new Resultado();
            try
            {

                var lista = this.productosServices.getProductosAll();
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

        [HttpGet("{id}")]
        public IActionResult getProducto(int id)
        {
            Resultado res = new Resultado();
            try
            {

                var producto = this.productosServices.getProducto(id);

               

                res.Respuesta = producto;
                if (producto == null)
                {
                    res.Respuesta = "Producto no encontrado";
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
        [Route("InactivarProducto")]
  
        public IActionResult inactivarProducto([FromBody] int id)
        {
            Resultado res=new Resultado();
            try
            {

                var producto = this.productosServices.inactivarProducto(id);

                res.Respuesta = producto;
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
        [Route("ActivarProducto")]
        public IActionResult activarProducto([FromBody] int id)
        {
            Resultado res = new Resultado();
            try
            {

                var producto = this.productosServices.activarProducto(id);

                res.Respuesta = producto;
                res.Mensaje = "OK";
            }
            catch (Exception)
            {

                res.Mensaje = "Error";
                return BadRequest(res);
            }

            return Ok(res);

        }

        [HttpPut]
        public IActionResult editarProducto([FromBody]  ProductoViewModel prod)
        {
            Resultado res = new Resultado();
            try
            {

                var producto = this.productosServices.editProducto(prod);

                res.Respuesta = producto;
                if (producto ==  null)
                {
                    res.Respuesta = "Producto no existe";
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

        [HttpDelete("{id}")]
        public IActionResult deleteProducto( int id)
        {
            Resultado res = new Resultado();
            try
            {

                var producto = this.productosServices.deleteProducto(id);

                res.Respuesta = producto;
                if (producto == null)
                {
                    res.Respuesta = "Producto no encontrado";
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
