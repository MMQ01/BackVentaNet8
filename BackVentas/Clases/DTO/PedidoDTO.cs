using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackVentasADO.Models.Clases.DTO
{
    public class PedidoDTO
    {
        public int Id { get; set; }
        public int ClienteID { get; set; }

        public decimal total { get; set; }

        public DateTime fechaCreacion { get; set; }
        public string Origen { get; set; }
        public int UsuarioID { get; set; }
        public string NombreCliente { get; set; }

        public List<DetallePedido> detallesPedido { get; set; }


        public PedidoDTO()
        {
            this.detallesPedido = new List<DetallePedido>();
        }

    }

    public class DetallePedido
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public int IdPedido { get; set; }
        public decimal cantidad { get; set; }
        public decimal Precio { get; set; }

        public DetallePedido()
        {
            
        }
    }

    public class csPedido : Resultado
    {
        public PedidoDTO Pedido { get; set; }
        public csPedido()
        {
            
        }
    }

    public class csListaPedidos:Resultado
    {
        public List<PedidoDTO> Lista_Pedidos { get; set; }

        public csListaPedidos()
        {
            
        }
    }

    public class PedidoEnc
    {
        public int Id { get; set; }
        public int ClienteID { get; set; }

        public decimal total { get; set; }

        public DateTime fechaCreacion { get; set; }
        public string Origen { get; set; }
        public int UsuarioID { get; set; }
        public string NombreCliente { get; set; }




    }

}