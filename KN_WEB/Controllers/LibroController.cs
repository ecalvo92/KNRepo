using KN_WEB.EF;
using KN_WEB.Models;
using KN_WEB.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace KN_WEB.Controllers
{
    public class LibroController : Controller
    {
        HttpClient http = new HttpClient();
        UserIdService userIdService = new UserIdService();

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

        [HttpGet]
        public ActionResult RegistrarLibros()
        {
            //Permitir al Admin registrar los libros que consulte del api            
            return View();
        }

        [HttpPost]
        public ActionResult ConsultarLibrosAPI(Libro model)
        {
            var resultado = BuscarLibros(model.Titulo);
            return View();
        }

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
                .Take(10)
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