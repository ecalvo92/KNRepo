using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KN_WEB.Models
{
    //Entidad, Objeto, Clase
    public class UsuarioModel
    {
        //Atributos, Propiedades, Campos
        public string CorreoElectronico { get; set; }
        public string Contrasenna { get; set; }
        public string NombreCompleto { get; set; }
        public string Identificacion { get; set; }
    }
}