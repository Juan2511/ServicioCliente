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
    public class CDEvaluacionServicio
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
                cmd.CommandText = "Sp_Agregar_EvaluacionServicio";
                cmd.Parameters.Add("ParamClienteCorreo", MySqlDbType.VarChar, 50).Value = objCEEvaluacionServicio.Correo;
                cmd.Parameters.Add("ParamClienteNombres", MySqlDbType.VarChar, 100).Value = objCEEvaluacionServicio.Nombres;

                cmd.ExecuteNonQuery();

                objCERepuesta.Resultado = true;
                objCERepuesta.Descripcion = "Correcto";
            }
            catch (Exception ex)
            {
                objCERepuesta.Descripcion = ex.Message;
            }
            finally
            {
                conn.DesConectar();
            }
            return objCERepuesta;
        }
    }
}
