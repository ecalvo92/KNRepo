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
            return View();
        }

        [HttpPost]
        public ActionResult Login(UsuarioModel model)
        {
            try
            {
                using (var context = new KN_BDEntities())
                { 
                    //var response = context.tUsuario.Where(x => x.CorreoElectronico == model.CorreoElectronico
                    //                                      && x.Contrasenna == model.Contrasenna
                    //                                      && x.Estado == true).FirstOrDefault();

                    var response = context.sp_IniciarSesionUsuario(model.CorreoElectronico, model.Contrasenna).FirstOrDefault();

                    if (response != null)
                        return RedirectToAction("Index", "Home");
                }

                ViewBag.Message = "No se autenticó su información, consulte con el administrador.";
            }
            catch (Exception)
            {
                ViewBag.Message = "Se presentó un error, consulte con el administrador.";
            }

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
            try
            {
                using (var context = new KN_BDEntities())
                {
                    //context.tUsuario.Add(new tUsuario
                    //{
                    //    CorreoElectronico = model.CorreoElectronico,
                    //    Contrasenna = model.Contrasenna,
                    //    NombreCompleto = model.NombreCompleto,
                    //    Identificacion = model.Identificacion,
                    //    Estado = true
                    //});
                    //var response = context.SaveChanges();

                    var response = context.sp_RegistrarUsuario(model.Identificacion, model.NombreCompleto, model.CorreoElectronico, model.Contrasenna);

                    if (response > 0)
                        return RedirectToAction("Login", "Home");
                }

                ViewBag.Message = "No se registró su información, consulte con el administrador.";
            }
            catch (Exception)
            {
                ViewBag.Message = "Se presentó un error, consulte con el administrador.";
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