using BackVentas.Models;
using BackVentasADO.Models.Clases.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackVentas.Controllers
{

    [ApiController]
    public class categoriaController : ControllerBase
    {
        private readonly VentasDbContext _context;

        public categoriaController(VentasDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/categoria")]
        public ListaCategoria GetCategorias()
        {
            var res = new ListaCategoria();
            try
            {
                var lista = _context.Categorias
                    .Select(x => new CategoriaDTO
                    {
                        Id = x.Id,
                        Nombre = x.Nombre,
                    })
                    .ToList();

                res.Lista_Categoria = lista;
                res.Respuesta = "OK";
            }
            catch (Exception ex)
            {
                res.Mensaje = ex.Message;
                res.Respuesta = "Error";
            }

            return res;
        }
    }
}
