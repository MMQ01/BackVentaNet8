using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackVentasADO.Models.Clases.DTO
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public bool Estado { get; set; }
        public string Nit { get; set; }

        public ClienteDTO()
        {
            
        }
    }

    public class csCliente : Resultado
    {
        public ClienteDTO Cliente { get; set; }

        public csCliente()
        {
            
        }
    }


    public class csListaCliente : Resultado
    {
        public List<ClienteDTO> Lista_Clientes { get; set; }

        public csListaCliente()
        {
            Lista_Clientes = new List<ClienteDTO>();
        }
    }

}