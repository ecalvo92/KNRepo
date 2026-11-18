using KN_WEB.EF;
using System.Collections.Generic;
using System.Linq;

namespace KN_WEB.Models
{
    public class CatalogoLibrosModel
    {
        public List<tLibro> Libros { get; set; } = new List<tLibro>();
        public List<tLibro> Carrito { get; set; } = new List<tLibro>();
        public decimal TotalCarrito => Carrito.Sum(libro => libro.Precio);
    }
}
