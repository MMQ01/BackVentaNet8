using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackVentasADO.Models.Clases.DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Login { get; set; }
        public bool Estado { get; set; }
        public string NombreCategoria { get; set; }
        public int CategoriaId { get; set; }

        public UsuarioDTO()
        {
            
        }
    }


    public class ListaUsuarios:Resultado
    {

        public List<UsuarioDTO> Lista_Usuarios { get; set; }

        public ListaUsuarios()
        {
            
        }

    }

    public class ResultadoUsuarioDTO : Resultado
    {

        public UsuarioDTO Usuario { get; set; }

        public ResultadoUsuarioDTO()
        {

        }

    }

    public class crearUsuario : UsuarioDTO
    {

        public string Contrasena { get; set; }

        public crearUsuario()
        {

        }

    }

    public class editarUsuario : UsuarioDTO
    {

        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public bool Estado { get; set; }
        public int CategoriaId { get; set; }
        public string Contrasena { get; set; }

        public editarUsuario()
        {

        }

    }

    public class csAsignacioCliente
    {

        public int UsuarioID { get; set; }
        public int ClienteID { get; set; }
        public string Resultado { get; set; }
        public string Mensaje { get; set; }
   

        public csAsignacioCliente()
        {

        }

    }

    public class ResultadoAsignacionCliente : Resultado
    {

        public csAsignacioCliente Asignacion_Cliente { get; set; }
        public ResultadoAsignacionCliente()
        {
            
        }
    }

    public class userSelected
    {
        public int ID { get; set; }
        public string Login { get; set; }
    }

    public class AsignacionCliente
    {
        public int UsuarioID { get; set; }
        public int ClienteID { get; set; }
    }

}