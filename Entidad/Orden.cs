using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Orden
    {
        public string RefOrden { get; set; }
        public Contenedor Contenedor { get; set; }
        public decimal ValorCarga { get; set; }

    }
}
