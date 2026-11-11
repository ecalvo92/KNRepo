using KN_WEB.EF;
using KN_WEB.Models;
using KN_WEB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace KN_WEB.Controllers
{
    public class LibroController : Controller
    {
        UserIdService userIdService = new UserIdService();

        #region Consulta de Libros

        [HttpGet]
        public ActionResult ConsultarLibros()
        {
            var libros = new List<tLibro>();

            try
            {
                using (var context = new KN_BDEntities())
                {
                    libros = context.tLibro.ToList();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Se presentó un error, consulte con el administrador.";
                userIdService.RegistrarError(ex.Message, RouteData.Values["controller"] + " - " + RouteData.Values["action"]);
            }

            return View(libros);
        }

        #endregion

        #region Registro de Libros

        [HttpGet]
        public ActionResult RegistrarLibros()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ConsultarLibrosAPI(LibroApi model)
        {
            try
            {
                ViewBag.TituloBusqueda = model.Titulo;
                ViewBag.Resultados = userIdService.BuscarLibros(model.Titulo);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Se presentó un error, consulte con el administrador.";
                userIdService.RegistrarError(ex.Message, RouteData.Values["controller"] + " - " + RouteData.Values["action"]);
            }

            return View("RegistrarLibros", new LibroApi());
        }

        [HttpPost]
        public ActionResult RegistrarLibros(LibroApi model)
        {
            try
            {
                using (var context = new KN_BDEntities())
                {
                    context.tLibro.Add(new tLibro
                    {
                        Titulo = model.Titulo,
                        Autor = model.Autor,
                        Sinopsis = model.Sinopsis,
                        Genero = model.Genero,
                        Portada = model.Portada,
                        Precio = model.Precio,
                        Estado = true
                    });
                    var response = context.SaveChanges();

                    if (response > 0)
                        return RedirectToAction("ConsultarLibros", "Libro");
                }

                ViewBag.Message = "No se registró la información del libro, consulte con el administrador.";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Se presentó un error, consulte con el administrador.";
                userIdService.RegistrarError(ex.Message, RouteData.Values["controller"] + " - " + RouteData.Values["action"]);
            }

            return View();
        }

        #endregion

        #region Actualizar Libros

        [HttpGet]
        public ActionResult ActualizarLibros(int id)
        {
            var libro = new LibroApi();

            try
            {
                using (var context = new KN_BDEntities())
                {
                    var response = context.tLibro.FirstOrDefault(x => x.IdLibro == id);

                    libro.IdLibro = response.IdLibro;
                    libro.Titulo = response.Titulo;
                    libro.Autor = response.Autor;
                    libro.Sinopsis = response.Sinopsis;
                    libro.Portada = response.Portada;
                    libro.Genero = response.Genero;
                    libro.Precio = response.Precio;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Se presentó un error, consulte con el administrador.";
                userIdService.RegistrarError(ex.Message, RouteData.Values["controller"] + " - " + RouteData.Values["action"]);
            }

            return View(libro);
        }

        [HttpPost]
        public ActionResult ActualizarLibros(LibroApi model)
        {
            try
            {
                using (var context = new KN_BDEntities())
                {
                    var response = context.tLibro.Where(x => x.IdLibro == model.IdLibro).FirstOrDefault();

                    if (response != null)
                    {
                        response.Titulo = model.Titulo;
                        response.Autor = model.Autor;
                        response.Sinopsis = model.Sinopsis;
                        response.Portada = model.Portada;
                        response.Genero = model.Genero;
                        response.Precio = model.Precio;
                        var updateResponse = context.SaveChanges();

                        if (updateResponse > 0)
                            return RedirectToAction("ConsultarLibros", "Libro");
                    }
                }

                ViewBag.Message = "No se actualizó la información del libro, consulte con el administrador.";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Se presentó un error, consulte con el administrador.";
                userIdService.RegistrarError(ex.Message, RouteData.Values["controller"] + " - " + RouteData.Values["action"]);
            }

            return View();
        }

        #endregion

        #region Inactivar Libros

        [HttpGet]
        public ActionResult InactivarLibros(int id)
        {
            try
            {
                using (var context = new KN_BDEntities())
                {
                    var response = context.tLibro.Where(x => x.IdLibro == id).FirstOrDefault();

                    if (response != null)
                    {
                        response.Estado = false;
                        var updateResponse = context.SaveChanges();

                        if (updateResponse > 0)
                            return RedirectToAction("ConsultarLibros", "Libro");
                    }
                }

                ViewBag.Message = "No se actualizó la información del libro, consulte con el administrador.";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Se presentó un error, consulte con el administrador.";
                userIdService.RegistrarError(ex.Message, RouteData.Values["controller"] + " - " + RouteData.Values["action"]);
            }

            return View();
        }

        #endregion
    }
}