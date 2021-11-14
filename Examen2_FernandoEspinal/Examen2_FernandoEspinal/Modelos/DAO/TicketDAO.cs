using Examen2_FernandoEspinal.Modelos.Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Examen2_FernandoEspinal.Modelos.DAO
{
    public class TicketDAO : Conexion
    {
        SqlCommand comando = new SqlCommand();

        public bool InsertarNuevoTicket(Ticket ticket)
        {
            bool inserto = false;

            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO TICKET ");
                sql.Append(" VALUES (@Fecha, @Nombre, @TipoSoporte, @Estado); ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.Parameters.Clear(); //permite ingresar valores consecutivamente
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Fecha", SqlDbType.Date).Value = ticket.Fecha;
                comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 30).Value = ticket.Nombre;
                comando.Parameters.Add("@TipoSoporte", SqlDbType.NVarChar, 50).Value = ticket.TipoSoporte;
                comando.Parameters.Add("@Estado", SqlDbType.NVarChar, 30).Value = ticket.Estado;

                comando.ExecuteNonQuery();
                inserto = true;
                MiConexion.Close();
            }
            catch (Exception ex)
            {
                inserto = false;
            }
            return inserto;
        }

        public DataTable GetTicket()
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM TICKET ");

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

        public bool ActualizarTicket(Ticket ticket)
        {
            bool modifico = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE TICKET ");
                sql.Append(" SET FECHA = @Fecha, NOMBRE = @Nombre, TIPOSOPORTE = @TipoSoporte, ESTADO = @Estado ");
                sql.Append(" WHERE ID = @Id; ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.Parameters.Clear();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Id", SqlDbType.Int).Value = ticket.Id;
                comando.Parameters.Add("@Fecha", SqlDbType.Date).Value = ticket.Fecha;
                comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 30).Value = ticket.Nombre;
                comando.Parameters.Add("@TipoSoporte", SqlDbType.NVarChar, 50).Value = ticket.TipoSoporte;
                comando.Parameters.Add("@Estado", SqlDbType.NVarChar, 30).Value = ticket.Estado;
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

        public bool EliminarTicket(int id)
        {
            bool elimino = false;

            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM TICKET ");
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


    }
}
