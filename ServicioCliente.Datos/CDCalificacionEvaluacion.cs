using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioCliente.Datos
{
    public class CDCalificacionEvaluacion
    {
        CDConexion conn = new CDConexion();
        public DataTable Listar()
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable dt = new DataTable();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn.Conectar();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Sp_Listar_DetalleEvaluacionServicio";

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
