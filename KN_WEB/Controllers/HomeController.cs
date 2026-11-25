using KN_WEB.EF;
using KN_WEB.Filters;
using KN_WEB.Models;
using KN_WEB.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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
                    {
                        Session["IdUsuario"] = response.IdUsuario;
                        Session["NombreUsuario"] = response.NombreCompleto;
                        Session["IdRol"] = response.IdRol;
                        Session["NombreRol"] = response.NombreRol;
                        return RedirectToAction("Index", "Home");
                    }
                }

                ViewBag.Message = "No se autenticó su información, consulte con el administrador.";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Se presentó un error, consulte con el administrador.";
                userIdService.RegistrarError(ex.Message, RouteData.Values["controller"] + " - " + RouteData.Values["action"]);
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
            catch (Exception ex)
            {
                ViewBag.Message = "Se presentó un error, consulte con el administrador.";
                userIdService.RegistrarError(ex.Message, RouteData.Values["controller"] + " - " + RouteData.Values["action"]);
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
        public async Task<ActionResult> ForgotPassword(UsuarioModel model)
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

                        var ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "recursos", "RecuperarContrasena.html");

                        var html = System.IO.File.ReadAllText(ruta, Encoding.UTF8)
                            .Replace("{{Nombre}}", WebUtility.HtmlEncode(response.NombreCompleto))
                            .Replace("{{Link}}", WebUtility.HtmlEncode(link))
                            .Replace("{{Anio}}", DateTime.Now.Year.ToString());

                        await userIdService.EnviarCorreo(response.CorreoElectronico, "Recuperación de Contraseña", html);
                        return RedirectToAction("Login", "Home");
                    }
                }

                ViewBag.Message = "No se validó su información, consulte con el administrador.";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Se presentó un error, consulte con el administrador.";
                userIdService.RegistrarError(ex.Message, RouteData.Values["controller"] + " - " + RouteData.Values["action"]);
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

                        if (updateResponse > 0)
                            return RedirectToAction("Login", "Home");
                    }
                }

                ViewBag.Message = "No se actualizó su información, consulte con el administrador.";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Se presentó un error, consulte con el administrador.";
                userIdService.RegistrarError(ex.Message, RouteData.Values["controller"] + " - " + RouteData.Values["action"]);
            }

            return View();
        }

        #endregion

        [ValidarSesion]
        public ActionResult CerrarSesion()
        {
            Session.Clear();
            return RedirectToAction("Login", "Home");
        }

        private string ClaveCarrito => "CarritoLibros:" + Session["IdUsuario"];

        [HttpGet]
        [ValidarSesion]
        public ActionResult Index()
        {
            if (Session["IdRol"].ToString() == "2")
                return RedirectToAction("Monitor", "Admin");

            var catalogo = new CatalogoLibrosModel();

            try
            {
                using (var context = new KN_BDEntities())
                {
                    catalogo.Libros = context.tLibro.Where(x => x.Estado && x.Inventario > 0).OrderBy(x => x.IdLibro).ToList();
                }

                if (Session[ClaveCarrito] is HashSet<int> seleccion)
                    catalogo.Carrito = catalogo.Libros.Where(x => seleccion.Contains(x.IdLibro)).ToList();
            }
            catch (System.Data.DataException ex)
            {
                ViewBag.Message = "No se pudo cargar el catálogo. Inténtalo más tarde.";
                userIdService.RegistrarError(ex.Message, RouteData.Values["controller"] + " - " + RouteData.Values["action"]);
            }

            return View(catalogo);
        }

        [HttpPost]
        [ValidarSesion]
        [ValidateAntiForgeryToken]
        public ActionResult ActualizarCarrito(int? id, bool quitar = false)
        {
            if (Session["IdRol"].ToString() == "2")
                return RedirectToAction("Monitor", "Admin");

            var urlCarrito = Url.Action("Index", "Home") + "#carrito";
            if (!ModelState.IsValid || !id.HasValue || id.Value <= 0)
            {
                TempData["ErrorCarrito"] = "No se pudo identificar el libro seleccionado.";
                return Redirect(urlCarrito);
            }

            var seleccion = Session[ClaveCarrito] as HashSet<int> ?? new HashSet<int>();
            if (quitar)
            {
                seleccion.Remove(id.Value);
            }
            else
            {
                var idLibro = id.Value;
                try
                {
                    using (var context = new KN_BDEntities())
                    {
                        if (!context.tLibro.Any(x => x.IdLibro == idLibro && x.Estado))
                        {
                            TempData["ErrorCarrito"] = "Este libro ya no está disponible.";
                            return Redirect(urlCarrito);
                        }
                    }
                }
                catch (System.Data.DataException ex)
                {
                    TempData["ErrorCarrito"] = "No se pudo agregar el libro. Inténtalo más tarde.";
                    userIdService.RegistrarError(ex.Message, RouteData.Values["controller"] + " - " + RouteData.Values["action"]);
                    return Redirect(urlCarrito);
                }

                seleccion.Add(idLibro);
            }

            Session[ClaveCarrito] = seleccion;
            return Redirect(urlCarrito);
        }

    }
}