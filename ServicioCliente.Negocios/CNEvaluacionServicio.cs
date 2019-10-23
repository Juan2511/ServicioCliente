using ServicioCliente.Datos;
using ServicioCliente.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioCliente.Negocios
{
    public class CNEvaluacionServicio
    {
        CDEvaluacionServicio objCDEvaluacionServicio = new CDEvaluacionServicio();
        public CERepuesta Agregar(CEEvaluacionServicio objCEEvaluacionServicio)
        {
            CERepuesta ObjCERepuesta = new CERepuesta();

            ObjCERepuesta.Descripcion = ValidaEntidadRegistro(objCEEvaluacionServicio);

            if (!string.IsNullOrWhiteSpace(ObjCERepuesta.Descripcion))
            {
                return ObjCERepuesta;
            }

            ObjCERepuesta = objCDEvaluacionServicio.Agregar(objCEEvaluacionServicio);

            return ObjCERepuesta;
        }

        private string ValidaEntidadRegistro(CEEvaluacionServicio objCEEvaluacionServicio)
        {
            string rpta = "";
            if (string.IsNullOrWhiteSpace(objCEEvaluacionServicio.Correo))
            {
                if (!string.IsNullOrWhiteSpace(rpta)) rpta += ",";
                rpta += "su E-mail";
            }
            if (string.IsNullOrWhiteSpace(objCEEvaluacionServicio.Nombres))
            {
                if (!string.IsNullOrWhiteSpace(rpta)) rpta += ",";
                rpta += "sus nombres";
            }

            if (!string.IsNullOrWhiteSpace(rpta))
            {
                rpta = "Debe ingresar/seleccionar " + rpta + ".";
            }

            return rpta;
        }
    }
}
