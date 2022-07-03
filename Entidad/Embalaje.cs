using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Embalaje
    {
        public string RefEmbalaje { get; set; }
        public Empaque Empaque { get; set; }
        public decimal Largo { get; set; }
        public decimal Ancho { get; set; }
        public decimal Alto { get; set; }
        public decimal EmpProdXLargo { get; set; }
        public decimal EmpProdXAncho { get; set; }
        public decimal EmpProdXAlto { get; set; }
        public decimal TotalEmpPrimarioXEmbalaje { get; set; }
    }
}
