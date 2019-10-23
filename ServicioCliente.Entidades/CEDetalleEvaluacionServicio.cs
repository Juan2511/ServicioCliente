using System;
using System.Collections.Generic;
using System.Text;

namespace ServicioCliente.Entidades
{
    public class CEDetalleEvaluacionServicio
    {
        public DateTime Fecha { get; set; }
        public int Calificacion { get; set; }

        public CEDetalleEvaluacionServicio()
        {
            Fecha = new DateTime();
            Calificacion = 0;
        }
    }
}
