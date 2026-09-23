using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KN_WEB.Services
{
    //Entidad, Objeto, Clase
    public class MatriculaService
    {
        public decimal CalcularDescuento(decimal montoCancelado)
        {
            return montoCancelado - (montoCancelado * 0.30M);
        }
    }
}