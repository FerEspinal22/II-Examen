using Examen2_FernandoEspinal.Modelos.Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Examen2_FernandoEspinal.Modelos.DAO
{
    public class EstadoDAO : Conexion
    {
        SqlCommand comando = new SqlCommand();

        #region PUBLIC BOOLS
        public bool InsertarNuevoEstado(Estados estado)
        {
            bool inserto = false;

            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO ESTADO ");
                sql.Append(" VALUES (@Estado); ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.Parameters.Clear(); //permite ingresar valores consecutivamente
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Estado", SqlDbType.NVarChar, 30).Value = estado.Estado;

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

        public DataTable GetEstado()
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM ESTADO ");

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

        public bool ActualizarEstado(Estados estado)
        {
            bool modifico = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE ESTADO ");
                sql.Append(" SET ESTADO = @Estado ");
                sql.Append(" WHERE ID = @Id; ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.Parameters.Clear();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Id", SqlDbType.Int).Value = estado.Id;
                comando.Parameters.Add("@Estado", SqlDbType.NVarChar, 30).Value = estado.Estado;
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
                sql.Append(" DELETE FROM ESTADO ");
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
