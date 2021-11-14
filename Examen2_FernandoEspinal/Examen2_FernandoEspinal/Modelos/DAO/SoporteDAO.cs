using Examen2_FernandoEspinal.Modelos.Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Examen2_FernandoEspinal.Modelos.DAO
{
    public class SoporteDAO : Conexion
    {
        SqlCommand comando = new SqlCommand();

        #region PUBLIC BOOLS
        public bool InsertarNuevoSoporte(Soporte soporte)
        {
            bool inserto = false;

            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO SOPORTE ");
                sql.Append(" VALUES (@Marca, @Modelo, @TipoSoporte); ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.Parameters.Clear(); //permite ingresar valores consecutivamente
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Marca", SqlDbType.NVarChar, 30).Value = soporte.Marca;
                comando.Parameters.Add("@Modelo", SqlDbType.NVarChar, 30).Value = soporte.Modelo;
                comando.Parameters.Add("@TipoSoporte", SqlDbType.NVarChar, 50).Value = soporte.TipoSoporte;

                comando.ExecuteNonQuery();
                inserto = true;
                MiConexion.Close();
            }
            catch (Exception)
            {
                inserto = false;
            }
            return inserto;
        }

        public DataTable GetSoporte()
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM SOPORTE ");

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

        public bool ActualizarSoporte(Soporte soporte)
        {
            bool modifico = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE SOPORTE ");
                sql.Append(" SET MARCA = @Marca, MODELO = @Modelo, TIPOSOPORTE = @TipoSoporte ");
                sql.Append(" WHERE ID = @Id; ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.Parameters.Clear();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Id", SqlDbType.Int).Value = soporte.Id;
                comando.Parameters.Add("@Marca", SqlDbType.NVarChar, 30).Value = soporte.Marca;
                comando.Parameters.Add("@Modelo", SqlDbType.NVarChar, 30).Value = soporte.Modelo;
                comando.Parameters.Add("@TipoSoporte", SqlDbType.NVarChar, 50).Value = soporte.TipoSoporte;
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

        public bool EliminarSoporte(int id)
        {
            bool elimino = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM SOPORTE ");
                sql.Append(" WHERE ID = @Id; ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.Parameters.Clear();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Id", SqlDbType.Int).Value = id;
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

        #endregion
    }
}
