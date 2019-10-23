using ServicioCliente.Datos;
using ServicioCliente.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioCliente.Negocios
{
    public class CNDetalleEvaluacionServicio
    {
        CDDetalleEvaluacionServicio objCDDetalleEvaluacionServicio = new CDDetalleEvaluacionServicio();
        public CERepuesta Agregar(CEEvaluacionServicio objCEEvaluacionServicio)
        {
            CERepuesta ObjCERepuesta = new CERepuesta();

            ObjCERepuesta.Descripcion = ValidaEntidadRegistro(objCEEvaluacionServicio.Detalle);

            if (!string.IsNullOrWhiteSpace(ObjCERepuesta.Descripcion))
            {
                return ObjCERepuesta;
            }

            ObjCERepuesta = objCDDetalleEvaluacionServicio.Agregar(objCEEvaluacionServicio);

            return ObjCERepuesta;
        }
        public DataTable Consultar(CEEvaluacionServicio objCEEvaluacionServicio)
        {
            return objCDDetalleEvaluacionServicio.Consultar(objCEEvaluacionServicio);
        }

        private string ValidaEntidadRegistro(CEDetalleEvaluacionServicio objCEDetalleEvaluacionServicio)
        {
            string rpta = "";
            if (objCEDetalleEvaluacionServicio.Fecha == new DateTime())
            {
                if (!string.IsNullOrWhiteSpace(rpta)) rpta += ",";
                rpta += "la fecha de calificación";
            }
            if (objCEDetalleEvaluacionServicio.Calificacion <= 0)
            {
                if (!string.IsNullOrWhiteSpace(rpta)) rpta += ",";
                rpta += "su calificación del servicio recibido";
            }

            if (!string.IsNullOrWhiteSpace(rpta))
            {
                rpta = "Debe ingresar/seleccionar " + rpta + ".";
            }

            return rpta;
        }
    }
}
