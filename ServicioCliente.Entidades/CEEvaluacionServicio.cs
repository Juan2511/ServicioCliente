using System;
using System.Collections.Generic;
using System.Text;

namespace ServicioCliente.Entidades
{
    public class CEEvaluacionServicio
    {
        public string Correo { get; set; }
        public string Nombres { get; set; }
        public CEDetalleEvaluacionServicio Detalle { get; set; }

        public CEEvaluacionServicio()
        {
            Correo = "";
            Nombres = "";
            Detalle = new CEDetalleEvaluacionServicio();
        }
    }
}
