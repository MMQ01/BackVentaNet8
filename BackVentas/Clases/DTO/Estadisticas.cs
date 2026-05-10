using BackVentasADO.Models.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackVentasADO.Clases.DTO
{
    public class Estadisticas
    {
    }

    public class csEstadisticaEnc : Resultado
    {
        public double ventaTotales { get; set; }
        public int pedidoTotales { get; set; }
        public int clientesTotales { get; set; }
        public int productosTotales { get; set; }

        public csEstadisticaEnc() { }
    }


    public class csUltimasVentas : Resultado
    {
        public List<csUltimasVentasDetalle> Detalle { get; set; }
    }

    public class csUltimasVentasDetalle
    {
        public int Id { get; set; }
        public string NombreCliente { get; set; }
        public string Origen { get; set; }
        public string NombreUsuario { get; set; }
        public decimal Total { get; set; }
    }


    public class csTopUsuarios : Resultado
    {
        public List<csTopUsuarioDetalle> Detalle { get; set; }
    }

    public class csTopUsuarioDetalle
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public int CantidadPedidos { get; set; }
    }

    public class csReportesStock : Resultado
    {
        public List<csReporteStockDetalle> Detalle { get; set; }
    }

    public class csReporteStockDetalle
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public double Stock { get; set; }
        public string Msg { get; set; }
    }
}