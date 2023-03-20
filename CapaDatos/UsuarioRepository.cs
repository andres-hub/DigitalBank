using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaDatos
{
    public class UsuarioRepository : IUsuarioRepository
    {
        string connString = "";

        public void AgregarUsuario(string nombre, DateTime fechaNacimiento, string sexo)
        {  
            using (var connection = new SqlConnection(connString))
            {
                using (var command = new SqlCommand("AgregarUsuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                    command.Parameters.AddWithValue("@Sexo", sexo);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ModificarUsuario(string nombre, DateTime fechaNacimiento, string sexo, int id )
        {
            using (var connection = new SqlConnection(connString))
            {
                using (var command = new SqlCommand("ModificarUsuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                    command.Parameters.AddWithValue("@Sexo", sexo);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Usuario> ConsultarUsuarios()
        {
            var usuarios = new List<Usuario>();

            using (var connection = new SqlConnection(connString))
            {
                using (var command = new SqlCommand("ConsultarUsuarios", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var usuario = new Usuario
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = Convert.ToString(reader["Nombre"]),
                                FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]),
                                Sexo = Convert.ToString(reader["Sexo"])
                            };

                            usuarios.Add(usuario);
                        }
                    }
                }
            }

            return usuarios;
        }

        public void EliminarUsuario(int idUsuario)
        {
            using (var connection = new SqlConnection(connString))
            {
                using (var command = new SqlCommand("EliminarUsuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@IdUsuario", idUsuario);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
