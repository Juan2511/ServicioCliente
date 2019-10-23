using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicioCliente.UI.Models
{
    public class Servicio
    {
        public string Correo { get; set; }
        public string Nombres { get; set; }
        public DetalleServicio Detalle { get; set; }
    }
}