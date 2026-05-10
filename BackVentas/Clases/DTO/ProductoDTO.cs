using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackVentasADO.Models.Clases.DTO
{
    public class ProductoDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public decimal Precio { get; set; }

        public string Descripcion { get; set; }

        public bool Estado { get; set; }
        public decimal Stock { get; set; }
        public string SKU { get; set; }
        public bool Favorito { get; set; }

        public ProductoDTO()
        {

        }
    }

    public class csProducto : Resultado
    {
        public ProductoDTO Producto { get; set; }

        public csProducto()
        {

        }

    } 

    public class csListaProducto : Resultado
    {
        public List<ProductoDTO> Lista_Productos { get; set; }

        public csListaProducto()
        {

        }
    }

    public class ProductoID 
    {
        public int Id { get; set; }
        public string SKU { get; set; }

        public ProductoID()
        {

        }
    }

    public class ProductoFavoritoRequest
    {
        public int ProductoID { get; set; }
        public int UsuarioID { get; set; }
        public bool Activar { get; set; }
    }

}