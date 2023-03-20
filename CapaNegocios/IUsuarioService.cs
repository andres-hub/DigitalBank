using System.Collections.Generic;

namespace CapaNegocios
{
    using CapaDatos;
    using System;
    using System.ServiceModel;

    [ServiceContract]
    public interface IUsuarioService
    {
        [OperationContract]
        Respuesta AgregarUsuario(string nombre, string fecha, string sexo);

        [OperationContract]
        Respuesta ModificarUsuario(string nombre, string fecha, string sexo, int id);

        [OperationContract]
        Respuesta ConsultarUsuarios();

        [OperationContract]
        Respuesta EliminarUsuario(int idUsuario);
    }

}
