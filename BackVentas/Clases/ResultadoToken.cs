using BackVentasADO.Models.Clases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackVentasADO.Models.Clases
{
    public class ResultadoToken:Resultado
    {
        public string Token { get; set; }
        public UsuarioDTO Usuario { get; set; }
    }
}