using BackVentasADO.Models.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackVentasADO.Clases.DTO
{
    public class CarritoDTO
    {

        public int ID { get; set; }
        public int Usuario_ID { get; set; }
        public string Nombre_Usuario { get; set; }
        public int Producto_ID { get; set; }
        public string Nombre_Producto { get; set; }
        public double Precio { get; set; }
        public string SKU { get; set; }
        public double Cantidad { get; set; }

    }



    public class csCarrito: Resultado
    {
        public List<CarritoDTO> Lista_Productos { get; set; }

        public csCarrito()
        {
            Lista_Productos = new List<CarritoDTO>();
        }

    }

    public class csCarritoUpdate
    {
        public int Usuario_ID { get; set; }
        public int Producto_ID { get; set; }
        public double Cantidad { get; set; }
    }
}