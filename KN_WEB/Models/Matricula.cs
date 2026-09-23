using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KN_WEB.Models
{
    //Entidad, Objeto, Clase
    public class Matricula
    {
        //Atributos, Propiedades, Campos
        public int CantidadCursos { get; set; }
        public string NombreUniversidad { get; set; }
        public decimal MontoCancelar { get; set; }
    }
}