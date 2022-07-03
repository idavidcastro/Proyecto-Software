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
    public class EmpaqueRepository
    {
        DbConnection _connection;
        private List<Empaque> empaques;
        public EmpaqueRepository(DbConnection connection)
        {
            _connection = connection;
            empaques = new List<Empaque>();
        }

        public void GuardarEmpaqueRep(Empaque empaque)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "insert into Empaque(RefEmpaque,RefProducto,Producto,PesoProducto, PrecioProducto, Largo, Ancho, Alto, PesoEmpaque, CantProductos, PrecioProdXCantProdEmpaque, PesoEmpaqXPesoProducto)" +
                              " values (@RefEmpaque,@RefProducto,@Producto,@PesoProducto, @PrecioProducto, @Largo, @Ancho, @Alto, @PesoEmpaque, @CantProductos, @PrecioProdXCantProdEmpaque, @PesoEmpaqXPesoProducto)";
                command.Parameters.Add(new SqlParameter("@RefEmpaque", empaque.RefEmpaque));
                command.Parameters.Add(new SqlParameter("@RefProducto", empaque.Producto.RefProducto));
                command.Parameters.Add(new SqlParameter("@Producto", empaque.Producto.NombreProducto));
                command.Parameters.Add(new SqlParameter("@PesoProducto", empaque.Producto.PesoProducto));
                command.Parameters.Add(new SqlParameter("@PrecioProducto", empaque.Producto.PrecioProducto));
                command.Parameters.Add(new SqlParameter("@Largo", empaque.Largo));
                command.Parameters.Add(new SqlParameter("@Ancho", empaque.Ancho));
                command.Parameters.Add(new SqlParameter("@Alto", empaque.Alto));
                command.Parameters.Add(new SqlParameter("@PesoEmpaque", empaque.PesoEmpaque));
                command.Parameters.Add(new SqlParameter("@CantProductos", empaque.CantidadProductos));
                command.Parameters.Add(new SqlParameter("@PrecioProdXCantProdEmpaque", empaque.PrecioProdxCantProd));
                command.Parameters.Add(new SqlParameter("@PesoEmpaqXPesoProducto", empaque.PesoEmpaquexPesoProducto));

                command.ExecuteNonQuery();
            }
        }

        public Empaque BuscarEmpaquePorRef(string refempaque)
        {
            using (var command = _connection.CreateCommand())
            {

                command.CommandText = "select *from Empaque where RefEmpaque=@RefEmpaque";
                command.Parameters.Add(new SqlParameter("@RefEmpaque", refempaque));
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Empaque empaque = new Empaque();
                        empaque.RefEmpaque = reader.GetString(0);
                        empaque.Producto = new Producto();
                        empaque.Producto.RefProducto = reader.GetString(1);
                        empaque.Producto.NombreProducto = reader.GetString(2);
                        empaque.Producto.PesoProducto = decimal.Parse(reader.GetString(3));
                        empaque.Producto.PrecioProducto = decimal.Parse(reader.GetString(4));
                        empaque.Largo = decimal.Parse(reader.GetString(5));
                        empaque.Ancho = decimal.Parse(reader.GetString(6));
                        empaque.Alto = decimal.Parse(reader.GetString(7));
                        empaque.PesoEmpaque = decimal.Parse(reader.GetString(8));
                        empaque.CantidadProductos = int.Parse(reader.GetString(9));
                        empaque.PrecioProdxCantProd = decimal.Parse(reader.GetString(10));
                        empaque.PesoEmpaquexPesoProducto = decimal.Parse(reader.GetString(11));

                        return empaque;
                    }
                }
                reader.Close();
            }
            return null;
        }

        public void EliminarEmpaqueRep(string refempaque)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "delete From Empaque where RefEmpaque=@RefEmpaque";
                command.Parameters.Add(new SqlParameter("@RefEmpaque", refempaque));
                command.ExecuteNonQuery();
            }
        }

        public void ModificarEmpaque(Empaque empaqueNuevo, string refempaque)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "update Empaque set RefEmpaque=@RefEmpaque,RefProducto=@RefProducto,Producto=@Producto,PesoProducto=@PesoProducto, PrecioProducto=@PrecioProducto, Largo=@Largo, Ancho=@Ancho, Alto=@Alto, PesoEmpaque=@PesoEmpaque, CantProductos=@CantProductos, PrecioProdXCantProdEmpaque=@PrecioProdXCantProdEmpaque, PesoEmpaqXPesoProducto=@PesoEmpaqXPesoProducto" +
                    " where RefProducto=@RefProducto";

                command.Parameters.Add(new SqlParameter("@RefEmpaque", refempaque));
                command.Parameters.Add(new SqlParameter("@RefProducto", empaqueNuevo.Producto.RefProducto));
                command.Parameters.Add(new SqlParameter("@Producto", empaqueNuevo.Producto.NombreProducto));
                command.Parameters.Add(new SqlParameter("@PesoProducto", empaqueNuevo.Producto.PesoProducto));
                command.Parameters.Add(new SqlParameter("@PrecioProducto", empaqueNuevo.Producto.PrecioProducto));
                command.Parameters.Add(new SqlParameter("@Largo", empaqueNuevo.Largo));
                command.Parameters.Add(new SqlParameter("@Ancho", empaqueNuevo.Ancho));
                command.Parameters.Add(new SqlParameter("@Alto", empaqueNuevo.Alto));
                command.Parameters.Add(new SqlParameter("@PesoEmpaque", empaqueNuevo.PesoEmpaque));
                command.Parameters.Add(new SqlParameter("@CantProductos", empaqueNuevo.CantidadProductos));
                command.Parameters.Add(new SqlParameter("@PrecioProdXCantProdEmpaque", empaqueNuevo.PrecioProdxCantProd));
                command.Parameters.Add(new SqlParameter("@PesoEmpaqXPesoProducto", empaqueNuevo.PesoEmpaquexPesoProducto));

                command.ExecuteNonQuery();
            }
        }

        public List<Empaque> ConsultarTodosLosEmpaques(string refempaque)
        {
            List<Empaque> empaques = new List<Empaque>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from Empaque where RefEmpaque=@RefEmpaque";
                command.Parameters.Add(new SqlParameter("@RefEmpaque", refempaque));
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Empaque empaque = new Empaque();
                    empaque.RefEmpaque = reader.GetString(0);
                    empaque.Producto = new Producto();
                    empaque.Producto.RefProducto = reader.GetString(1);
                    empaque.Producto.NombreProducto = reader.GetString(2);
                    empaque.Producto.PesoProducto = decimal.Parse(reader.GetString(3));
                    empaque.Producto.PrecioProducto = decimal.Parse(reader.GetString(4));
                    empaque.Largo = decimal.Parse(reader.GetString(5));
                    empaque.Ancho = decimal.Parse(reader.GetString(6));
                    empaque.Alto = decimal.Parse(reader.GetString(7));
                    empaque.PesoEmpaque = decimal.Parse(reader.GetString(8));
                    empaque.CantidadProductos = int.Parse(reader.GetString(9));
                    empaque.PrecioProdxCantProd = decimal.Parse(reader.GetString(10));
                    empaque.PesoEmpaquexPesoProducto = decimal.Parse(reader.GetString(11));

                    empaques.Add(empaque);
                }
                reader.Close();
            }

            return empaques;
        }
    }
}
