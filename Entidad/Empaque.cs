using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Empaque
    {
        public string RefEmpaque { get; set; }
        public Producto Producto { get; set; }
        //public Producto PesoProducto { get; set; }
        //public Producto PrecioProducto { get; set; }
        public decimal Largo { get; set; }
        public decimal Alto { get; set; }
        public decimal Ancho { get; set; }
        public decimal PesoEmpaque { get; set; }
        public int CantidadProductos { get; set; }
        public decimal PrecioProdxCantProd { get; set; }
        public decimal PesoEmpaquexPesoProducto { get; set; }
    }
}
