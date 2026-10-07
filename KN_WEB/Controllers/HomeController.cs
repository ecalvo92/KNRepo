using KN_WEB.EF;
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
        #region Inicio de Sesión

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

        #region Registro de Usuarios

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UsuarioModel model)
        {
            using (var context = new KN_BDEntities())
            {
                context.tUsuario.Add(new tUsuario
                {
                    CorreoElectronico = model.CorreoElectronico,
                    Contrasenna = model.Contrasenna,
                    NombreCompleto = model.NombreCompleto,
                    Identificacion = model.Identificacion,
                    Estado = true
                });
                context.SaveChanges();
            }

            return View();
        }

        #endregion

        #region Olvido de Contraseña

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            //Esta acción es un GET porque me permite entrar a la vista
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(UsuarioModel model)
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