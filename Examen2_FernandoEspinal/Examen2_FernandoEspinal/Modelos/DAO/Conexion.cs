using System.Configuration;
using System.Data.SqlClient;

namespace Examen2_FernandoEspinal.Modelos.DAO
{
    public class Conexion
    {
        protected SqlConnection MiConexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ExamenConexion"].ConnectionString);
    }
}