using CapaDatos;
using System;
using System.Collections.Generic;

namespace CapaNegocios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly Respuesta _respuesta;
        private DateTime _fecha;

        public UsuarioService()
        {
            _usuarioRepository = new UsuarioRepository();
            _respuesta = new Respuesta();
            _respuesta.esExitoso = true;
        }

        public Respuesta AgregarUsuario(string nombre, string fecha, string sexo)
        {
            try
            {
                ValidarDatos(nombre, fecha, sexo);
                if (_respuesta.esExitoso)
                    _usuarioRepository.AgregarUsuario(nombre, _fecha, sexo);
                return _respuesta;
            }
            catch (Exception)
            {
                return ErrorInterno();
            }

        }

        public Respuesta ModificarUsuario(string nombre, string fecha, string sexo, int id)
        {
            try
            {
                ValidarDatos(nombre, fecha, sexo);
                if (_respuesta.esExitoso)
                    _usuarioRepository.ModificarUsuario(nombre, _fecha, sexo, id);
                return _respuesta;
            }
            catch (Exception)
            {
                return ErrorInterno();
            }
        }

        public Respuesta ConsultarUsuarios()
        {
            try
            {
                _respuesta.Usuarios = _usuarioRepository.ConsultarUsuarios();
                return _respuesta;
            }
            catch (Exception)
            {
                return ErrorInterno();
            }
        }

        public Respuesta EliminarUsuario(int idUsuario)
        {
            try
            {
                _usuarioRepository.EliminarUsuario(idUsuario);
                return _respuesta;
            }
            catch (Exception)
            {
                return ErrorInterno();
            }
        }

        private void ValidarDatos(string nombre, string fecha, string sexo)
        {
            if (nombre.Length == 0 || nombre.Length > 100)
            {
                _respuesta.Error += "El nombre de usuario es muy corto o muy largo.";
                _respuesta.esExitoso = false;
            }
            if (sexo.Length != 1)
            {
                _respuesta.Error += "El campo sexo es muy corto o muy largo.";
                _respuesta.esExitoso = false;
            }

            try
            {
                if(fecha == "0001-01-01T00:00:00")
                {
                    _respuesta.Error += "El formato de la fecha de nacimiento es incorrecto.";
                    _respuesta.esExitoso = false;
                }
                _fecha = Convert.ToDateTime(fecha);
            }
            catch (Exception)
            {
                _respuesta.Error += "El formato de la fecha de nacimiento es incorrecto.";
                _respuesta.esExitoso = false;
            }


        }

        private Respuesta ErrorInterno()
        {
            _respuesta.esExitoso = false;
            _respuesta.Error = "Error interno, por favor, consulte con el administrador.";
            return _respuesta;
        }

    }
}
