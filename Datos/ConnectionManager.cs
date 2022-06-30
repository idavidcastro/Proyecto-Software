using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ConnectionManager
    {
        public DbConnection Connetion;
        public ConnectionManager(string connetionString)
        {
            Connetion = new SqlConnection(connetionString);
        }

        public void Open()
        {
            Connetion.Open();
        }
        public void Close()
        {
            Connetion.Close();
        }
    }
}
