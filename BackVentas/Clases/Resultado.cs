using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackVentasADO.Models.Clases
{
    public class Resultado
    {
        public string Respuesta { get; set; }

        public string Mensaje { get; set; }
    }

    public class ResultadoBoolean
    {
        public string Respuesta { get; set; }

        public Boolean Valor { get; set; }
    }
}