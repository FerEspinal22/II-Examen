using Examen2_FernandoEspinal.Modelos.Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace Examen2_FernandoEspinal.Modelos.DAO
{
    public class UsuarioDAO : Conexion
    {
        SqlCommand comando = new SqlCommand();

        #region PUBLIC BOOLS
        public bool ValidarUsuario(Usuario user)
        {
            bool valido = false;

            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT 1 FROM USUARIO WHERE EMAIL = @Email AND CLAVE = @Clave;");
                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = user.Email;
                comando.Parameters.Add("@Clave", SqlDbType.NVarChar, 100).Value = user.Clave;
                valido = Convert.ToBoolean(comando.ExecuteScalar());
                MiConexion.Close();
            }
            catch (Exception)
            {
            }
            return valido;
        }
        
        public bool InsertarNuevoUsuario(Usuario user)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO USUARIO");
                sql.Append(" VALUES(@Nombre, @Email, @Clave, @EsAdministrador); ");
                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.Parameters.Clear(); //permite agregar valores de manera consecutiva a la tabla
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 80).Value = user.Nombre;
                comando.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = user.Email;
                comando.Parameters.Add("@Clave", SqlDbType.NVarChar, 100).Value = EncriptarClave(user.Clave);
                comando.Parameters.Add("@EsAdministrador", SqlDbType.Bit).Value = user.EsAdministrador;
                comando.ExecuteNonQuery();
                MiConexion.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DataTable GetUsuarios()
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM USUARIO ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                SqlDataReader dr = comando.ExecuteReader();
                dt.Load(dr);
                MiConexion.Close();
            }
            catch (Exception)
            {
            }
            return dt;
        }

        public bool ActualizarUsuario(Usuario user)
        {
            bool modifico = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE USUARIO ");
                sql.Append(" SET NOMBRE = @Nombre, EMAIL = @Email, CLAVE = @Clave, ESADMINISTRADOR = @EsAdministrador  ");
                sql.Append(" WHERE ID = @Id; ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.Parameters.Clear();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Id", SqlDbType.Int).Value = user.Id;
                comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 80).Value = user.Nombre;
                comando.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = user.Email;
                comando.Parameters.Add("@Clave", SqlDbType.NVarChar, 100).Value = EncriptarClave(user.Clave);
                comando.Parameters.Add("@EsAdministrador", SqlDbType.Bit).Value = user.EsAdministrador;
                comando.ExecuteNonQuery();
                modifico = true;
                MiConexion.Close();
            }
            catch (Exception)
            {
                return modifico;
            }
            return modifico;
        }

        public bool EliminarUsuario(int Id)
        {
            bool elimino = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE USUARIO WHERE ID = @Id; ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                comando.ExecuteNonQuery();
                elimino = true;
                MiConexion.Close();
            }
            catch (Exception)
            {
                return elimino;
            }
            return elimino;

        }

        public static string EncriptarClave(string str)
        {
            string cadena = str + "MiClavePersonal";
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(cadena));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        #endregion
    }
}