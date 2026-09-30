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
        [HttpGet]
        public ActionResult Login()
        {
            //Esta acción es un GET porque me permite entrar a la vista
            return View();
        }

        [HttpPost]
        public ActionResult Login(UsuarioModel model)
        {
            //Esta acción es un POST porque me permite recibir datos de la vista
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }     

    }
}