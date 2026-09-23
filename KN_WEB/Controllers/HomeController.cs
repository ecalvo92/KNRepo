using KN_WEB.Models;
using KN_WEB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KN_WEB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var matriculaModel = new Matricula
            {
                CantidadCursos = 3,
                NombreUniversidad = "Universidad Fidélitas",
                MontoCancelar = 350000M
            };

            var matriculaService = new MatriculaService();
            matriculaModel.MontoCancelar = matriculaService.CalcularDescuento(matriculaModel.MontoCancelar);

            return View(matriculaModel);
        }     

        public ActionResult About()
        {
            return View();
        }        

        public ActionResult Contact()
        {
            return View();
        }

    }
}