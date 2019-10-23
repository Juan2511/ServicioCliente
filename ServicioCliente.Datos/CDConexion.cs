using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioCliente.Datos
{
    public class CDConexion
    {
        public MySqlConnection Conectar()
        {
            string strConn = "Server=prosegurservicio.mysql.database.azure.com; Port=3306; Database=prosegur; Uid=usu1234@prosegurservicio; Pwd=Usuario1234@; SslMode=Preferred;";
            try
            {
                MySqlConnection cnn = new MySqlConnection(strConn);
                cnn.Open();
                return cnn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DesConectar()
        {
            string strConn = "Server=prosegurservicio.mysql.database.azure.com; Port=3306; Database=prosegur; Uid=usu1234@prosegurservicio; Pwd=Usuario1234@; SslMode=Preferred;";
            try
            {
                MySqlConnection cnn = new MySqlConnection(strConn);
                cnn.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
