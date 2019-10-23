using System;
using System.Collections.Generic;
using System.Text;

namespace ServicioCliente.Entidades
{
    public class CERepuesta
    {
        public bool Resultado { get; set; }
        public string Descripcion { get; set; }

        public CERepuesta()
        {
            Resultado = false;
            Descripcion = "";
        }
    }
}
