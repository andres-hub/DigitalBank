using CapaDatos;
using System.Collections.Generic;

namespace CapaNegocios
{
    public class Respuesta
    {
        public bool esExitoso { get; set; }
        public string Error { get; set; }
        public List<Usuario> Usuarios { get; set; }
    }
}