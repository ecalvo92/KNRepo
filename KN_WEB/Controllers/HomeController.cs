using KN_WEB.EF;
using KN_WEB.Models;
using KN_WEB.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KN_WEB.Controllers
{
    public class HomeController : Controller
    {
        UserIdService userIdService = new UserIdService();

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
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(UsuarioModel model)
        {
            try
            {
                using (var context = new KN_BDEntities())
                {
                    var response = context.tUsuario.Where(x => x.Identificacion == model.Identificacion
                                                          && x.Estado == true).FirstOrDefault();

                    if (response != null)
                    {
                        var userIdCifrado = userIdService.Cifrar(response.IdUsuario, TimeSpan.FromHours(1));
                        var link = ConfigurationManager.AppSettings["UrlSistema"] + "Home/ChangePassword/" + userIdCifrado;

                        //Envío del correo con un mensaje que diga que ese código expira en 1 hora
                    }
                }

                ViewBag.Message = "No se validó su información, consulte con el administrador.";
            }
            catch (Exception)
            {
                ViewBag.Message = "Se presentó un error, consulte con el administrador.";
            }

            return View();
        }

        #endregion

        #region Cambio de Contraseña Externo

        [HttpGet]
        public ActionResult ChangePassword(string id)
        {
            //Se guarda el id en la sesión
            Session["IdUsuarioCifrado"] = id;
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(UsuarioModel model)
        {
            try
            {
                //Se lee el id de la sesión y se valida
                var idUsuarioDescrifrado = userIdService.Descifrar(Session["IdUsuarioCifrado"].ToString());

                if (idUsuarioDescrifrado == null)
                {
                    ViewBag.Message = "El enlace utilizado no es válido o ya expiró.";
                    return View();
                }

                using (var context = new KN_BDEntities())
                {
                    var response = context.tUsuario.Where(x => x.IdUsuario == idUsuarioDescrifrado).FirstOrDefault();

                    if (response != null)
                    {
                        response.Contrasenna = model.Contrasenna;
                        var updateResponse = context.SaveChanges();

                        if(updateResponse > 0)
                            return RedirectToAction("Login", "Home");
                    }
                }

                ViewBag.Message = "No se actualizó su información, consulte con el administrador.";
            }
            catch (Exception)
            {
                ViewBag.Message = "Se presentó un error, consulte con el administrador.";
            }

            return View();
        }

        #endregion

        public ActionResult Index()
        {
            return View();
        }

    }
}