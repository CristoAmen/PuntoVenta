using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVentaV2.Gerencia
{
    internal class ClassEmpleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string aPaterno { get; set; }
        public string aMaterno { get; set; }
        public string Curp { get; set; }
        public string Telefono { get; set; }
        public int Puesto { get; set; }

    }
}
