using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Contenedor
    {
        public string RefContenedor { get; set; }
        public Estibado Estibado { get; set; }
        public string TipoContenedor { get; set; }
        public decimal LargoContenedor { get; set; }
        public decimal AnchoContenedor { get; set; }
        public decimal EstibadoXLargo { get; set; }
        public decimal EstibadoXAncho { get; set; }
        public decimal TotalEstibasXContenedor { get; set; }
        public  int NumEstibasXProducto { get; set; }
        public int TotalEmbalajesEnContenedor { get; set; }
    }
}
