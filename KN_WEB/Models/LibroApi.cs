namespace KN_WEB.Models
{
    public class LibroApi
    {
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Sinopsis { get; set; }
        public string Portada { get; set; }
        public string Genero { get; set; }
        public decimal Precio { get; set; }
        public bool Estado { get; set; }
    }
}