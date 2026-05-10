using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackVentasADO.Models.Clases.DTO
{
    public class CategoriaDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public CategoriaDTO()
        {
            
        }

    }

    public class ListaCategoria : Resultado
    {
        public List<CategoriaDTO> Lista_Categoria { get; set; }

        public ListaCategoria()
        {
        }
    }

}