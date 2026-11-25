namespace KN_WEB.Models
{
    //Entidad, Objeto, Clase
    public class UsuarioModel
    {
        //Atributos, Propiedades, Campos
        public int IdUsuario { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contrasenna { get; set; }
        public string NombreCompleto { get; set; }
        public string Identificacion { get; set; }
        public string ConfirmarContrasenna { get; set; }
    }
}