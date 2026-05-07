using BackVentas.Modelos;
using BackVentas.Modelos.ViewModel_DTO_;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class categoriaController : ControllerBase
    {

        VentasContext _context;

        public categoriaController(VentasContext context)
        {
              _context = context;
        }

        [HttpGet]
        public IActionResult getCategorias()
        {

            Resultado res = new Resultado();
            try
            {
                var lista = _context.Categorias
                .Select(x => new CategoriaViewModel
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                })
                .ToList();

                res.Respuesta = lista;
                res.Mensaje = "OK";

            }
            catch (Exception ex)
            {
                res.Respuesta = ex.Message;
                res.Mensaje = "Error";
                return BadRequest(res);
                
            }

            return Ok(res);
        }
    }
}
