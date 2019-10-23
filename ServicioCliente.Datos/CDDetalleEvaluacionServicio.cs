using MySql.Data.MySqlClient;
using ServicioCliente.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioCliente.Datos
{
    public class CDDetalleEvaluacionServicio
    {
        CDConexion conn = new CDConexion();
        public CERepuesta Agregar(CEEvaluacionServicio objCEEvaluacionServicio)
        {
            CERepuesta objCERepuesta = new CERepuesta();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn.Conectar();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Sp_Agregar_DetalleEvaluacionServicio";
                cmd.Parameters.Add("ParamClienteCorreo", MySqlDbType.VarChar, 50).Value = objCEEvaluacionServicio.Correo;
                cmd.Parameters.Add("ParamFechaCalificacion", MySqlDbType.Date).Value = objCEEvaluacionServicio.Detalle.Fecha;
                cmd.Parameters.Add("ParamCalificacion", MySqlDbType.Int32).Value = objCEEvaluacionServicio.Detalle.Calificacion;

                cmd.ExecuteNonQuery();

                objCERepuesta.Resultado = true;
                objCERepuesta.Descripcion = "Correcto";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.DesConectar();
            }
            return objCERepuesta;
        }
        public DataTable Consultar(CEEvaluacionServicio objCEEvaluacionServicio)
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable dt = new DataTable();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn.Conectar();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Sp_Obtener_DetalleEvaluacionServicio";
                cmd.Parameters.Add("ParamClienteCorreo", MySqlDbType.VarChar, 50).Value = objCEEvaluacionServicio.Correo;
                cmd.Parameters.Add("ParamFechaCalificacion", MySqlDbType.Date).Value = objCEEvaluacionServicio.Detalle.Fecha;

                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.DesConectar();
            }
            return dt;
        }
    }
}
