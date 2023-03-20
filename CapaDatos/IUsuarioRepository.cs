using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public interface IUsuarioRepository
    {   
        void AgregarUsuario(string nombre, DateTime fecha, string sexo);

        void ModificarUsuario(string nombre, DateTime fecha, string sexo, int id);

        List<Usuario> ConsultarUsuarios();

        void EliminarUsuario(int id);
    }
    
}
