using KN_WEB.EF;
using KN_WEB.Models;
using KN_WEB.Services;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;

namespace KN_WEB.Controllers
{
    public class LibroController : Controller
    {
        HttpClient http = new HttpClient();
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
                ViewBag.Resultados = BuscarLibros(model.Titulo);
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

        private List<LibroApi> BuscarLibros(string titulo)
        {
            string apiKey = ConfigurationManager.AppSettings["GoogleBooksApiKey"];

            string url = "https://www.googleapis.com/books/v1/volumes?maxResults=40&q=intitle:"
                         + Uri.EscapeDataString(titulo)
                         + "&key=" + apiKey;

            var json = JObject.Parse(http.GetStringAsync(url).Result);

            if (json["items"] == null)
                return new List<LibroApi>();

            return json["items"]
                .Where(i => !string.IsNullOrWhiteSpace((string)i["volumeInfo"]["imageLinks"]?["thumbnail"]))
                .Select(i => new LibroApi
                {
                    Titulo = (string)i["volumeInfo"]["title"],
                    Autor = (string)i["volumeInfo"]["authors"]?.FirstOrDefault(),
                    Sinopsis = (string)i["volumeInfo"]["description"],
                    Genero = (string)i["volumeInfo"]["categories"]?.FirstOrDefault(),
                    Portada = ((string)i["volumeInfo"]["imageLinks"]?["thumbnail"])?.Replace("http://", "https://")
                })
                .DistinctBy(x => new { x.Titulo, x.Autor })
                .OrderBy(x => x.Titulo)
                .Take(20)
                .ToList();
        }


        //public ActionResult ActualizarLibros()
        //{

        //}

        //public ActionResult CambiarEstadoLibros()
        //{

        //}
    }
}