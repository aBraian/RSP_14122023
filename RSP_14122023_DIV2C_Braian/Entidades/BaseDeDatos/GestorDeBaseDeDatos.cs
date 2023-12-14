using System.Data.SqlClient;

namespace Entidades.BaseDeDatos
{
    public static class GestorDeBaseDeDatos
    {
        private static SqlConnection? connection;
        private static string stringConnection;

        static GestorDeBaseDeDatos()
        {
            stringConnection = "Server=.;Database=14122023-rsp;Trusted_Connection=True;";
        }

        public static bool RegistrarTrabajo(string nombreAlumno, int cantidadPacientes)
        {
            try
            {
                using (connection = new SqlConnection(stringConnection))
                {
                    string query = "INSERT INTO pacientes_atendidos (cantidad_pacientes, alumno) " +
                        "VALUES (@cantidadPacientes, @nombreAlumno)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("cantidadPacientes", cantidadPacientes);
                    command.Parameters.AddWithValue("nombreAlumno", nombreAlumno);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                return true; 
            }
            catch (Exception) 
            {
                return false;
            }
        }
    }
}
