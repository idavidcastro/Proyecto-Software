using Entidad;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class OrdenRepository
    {
        DbConnection _connection;
        private List<Orden> ordenes;
        public OrdenRepository(DbConnection connection)
        {
            _connection = connection;
            ordenes = new List<Orden>();
        }

        public void GuardarOrdenRep(Orden Orden)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "insert into Orden(RefOrden, RefContenedor, ValorCarga)" +
                              " values (@RefOrden, @RefContenedor, @ValorCarga)";
                command.Parameters.Add(new SqlParameter("@RefOrden", Orden.RefOrden));
                command.Parameters.Add(new SqlParameter("@RefContenedor", Orden.Contenedor.RefContenedor));
                command.Parameters.Add(new SqlParameter("@ValorCarga", Orden.ValorCarga));

                command.ExecuteNonQuery();
            }
        }

        public Orden BuscarOrdenPorRef(string reforden)
        {
            using (var command = _connection.CreateCommand())
            {

                command.CommandText = "select *from Orden where RefOrden=@RefOrden";
                command.Parameters.Add(new SqlParameter("@RefOrden", reforden));
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Orden orden = new Orden();
                        orden.RefOrden = reader.GetString(0);
                        orden.Contenedor = new Contenedor();
                        orden.Contenedor.RefContenedor = reader.GetString(1);
                        orden.ValorCarga = decimal.Parse(reader.GetString(2));

                        return orden;
                    }
                }
                reader.Close();
            }
            return null;
        }

        public void EliminarOrdeRep(string reforden)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "delete From Orden where RefOrden=@RefOrden";
                command.Parameters.Add(new SqlParameter("@RefOrden", reforden));
                command.ExecuteNonQuery();
            }
        }
        
        public List<Orden> ConsultarTodasLasOrdenes(string reforden)
        {
            List<Orden> ordenes = new List<Orden>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from Orden where RefOrden=@RefOrden";
                command.Parameters.Add(new SqlParameter("@RefOrden", reforden));
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Orden orden = new Orden();
                    orden.RefOrden = reader.GetString(0);
                    orden.Contenedor = new Contenedor();
                    orden.Contenedor.RefContenedor = reader.GetString(1);
                    orden.ValorCarga = decimal.Parse(reader.GetString(2));

                    ordenes.Add(orden);
                }
                reader.Close();
            }

            return ordenes;
        }
    }
}
