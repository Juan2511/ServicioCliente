using ServicioCliente.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioCliente.Negocios
{
    public class CNCalificacionEvaluacion
    {
        CDCalificacionEvaluacion objCDCalificacionEvaluacion = new CDCalificacionEvaluacion();
        public DataTable Listar()
        {
            return objCDCalificacionEvaluacion.Listar();
        }
    }
}