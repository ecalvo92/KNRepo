using KN_WEB.EF;
using KN_WEB.Filters;
using KN_WEB.Models;
using KN_WEB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KN_WEB.Controllers
{
    [ValidarSesion]
    public class UsuarioController : Controller
    {
        UserIdService userIdService = new UserIdService();

        [HttpGet]
        public ActionResult CambiarContrasenna()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CambiarContrasenna(UsuarioModel model)
        {
            try
            {
                var idUsuario = int.Parse(Session["IdUsuario"].ToString());
                ViewBag.Message = "No se actualizó su información, consulte con el administrador.";

                using (var context = new KN_BDEntities())
                {
                    var response = context.tUsuario.Where(x => x.IdUsuario == idUsuario).FirstOrDefault();

                    if (response != null)
                    {
                        response.Contrasenna = model.Contrasenna;
                        var updateResponse = context.SaveChanges();

                        if (updateResponse > 0)
                        {
                            ViewBag.Success = true;
                            ViewBag.Message = "Su información se actualizó correctamente.";
                        }
                    }
                }                
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Se presentó un error, consulte con el administrador.";
                userIdService.RegistrarError(ex.Message, RouteData.Values["controller"] + " - " + RouteData.Values["action"]);
            }

            return View();
        }

        [HttpGet]
        public ActionResult CambiarDatosPersonales()
        {
            var idUsuario = int.Parse(Session["IdUsuario"].ToString());
            var usuario = new UsuarioModel();

            try
            {
                using (var context = new KN_BDEntities())
                {
                    var response = context.tUsuario.FirstOrDefault(x => x.IdUsuario == idUsuario);

                    usuario.IdUsuario = response.IdUsuario;
                    usuario.NombreCompleto = response.NombreCompleto;
                    usuario.Identificacion = response.Identificacion;
                    usuario.CorreoElectronico = response.CorreoElectronico;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Se presentó un error, consulte con el administrador.";
                userIdService.RegistrarError(ex.Message, RouteData.Values["controller"] + " - " + RouteData.Values["action"]);
            }

            return View(usuario);
        }

        [HttpPost]
        public ActionResult CambiarDatosPersonales(UsuarioModel model)
        {
            try
            {
                var idUsuario = int.Parse(Session["IdUsuario"].ToString());
                ViewBag.Message = "No se actualizó su información, consulte con el administrador.";

                using (var context = new KN_BDEntities())
                {
                    var response = context.tUsuario.Where(x => x.IdUsuario == idUsuario).FirstOrDefault();

                    if (response != null)
                    {
                        response.Identificacion = model.Identificacion;
                        response.NombreCompleto = model.NombreCompleto;
                        response.CorreoElectronico = model.CorreoElectronico;
                        var updateResponse = context.SaveChanges();

                        if (updateResponse > 0)
                        {
                            Session["NombreUsuario"] = response.NombreCompleto;
                            ViewBag.Success = true;
                            ViewBag.Message = "Su información se actualizó correctamente.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Se presentó un error, consulte con el administrador.";
                userIdService.RegistrarError(ex.Message, RouteData.Values["controller"] + " - " + RouteData.Values["action"]);
            }

            return View(model);
        }
    }
}