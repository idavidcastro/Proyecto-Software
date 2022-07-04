using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Estibado
    {
        public string RefEstibado { get; set; }
        public Embalaje Embalaje { get; set; }
        public decimal LargoEstibado { get; set; }
        public decimal AnchoEstibado { get; set; }
        public decimal AltoEstibado { get; set; }
        public decimal EmbalajeXLargo { get; set; }
        public decimal EmbalajeXAncho { get; set; }
        public decimal EmbalajeXAlto { get; set; }
        public decimal TotalEmbalajesXEstibas { get; set; }
    }
}
