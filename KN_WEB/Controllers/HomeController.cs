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
        #region Login

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

        #endregion

        #region Registro

        [HttpGet]
        public ActionResult Register()
        {
            //Esta acción es un GET porque me permite entrar a la vista
            return View();
        }

        [HttpPost]
        public ActionResult Register(UsuarioModel model)
        {
            //Esta acción es un POST porque me permite recibir datos de la vista
            return View();
        }

        #endregion

        public ActionResult Index()
        {
            return View();
        }

    }
}