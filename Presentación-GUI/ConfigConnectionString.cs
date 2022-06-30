using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentación_GUI
{
    public static class ConfigConnectionString
    {
        public static string Cadena = ConfigurationManager.ConnectionStrings["cadenaproyecto"].ConnectionString;
    }
}
