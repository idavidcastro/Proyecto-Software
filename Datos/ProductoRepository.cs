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
    public class ProductoRepository
    {
        DbConnection _connection;
        private List<Producto> productos;
        public ProductoRepository(DbConnection connection)
        {
            _connection = connection;
            productos = new List<Producto>();
        }

        public void GuardarProductoRep(Producto producto)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "insert into Producto(RefProducto,Nombre,Peso,Precio)" +
                              " values (@RefProducto,@Nombre,@Peso,@Precio)";
                command.Parameters.Add(new SqlParameter("@RefProducto", producto.RefProducto));
                command.Parameters.Add(new SqlParameter("@Nombre", producto.NombreProducto));
                command.Parameters.Add(new SqlParameter("@Peso", producto.PesoProducto));
                command.Parameters.Add(new SqlParameter("@Precio", producto.PrecioProducto));      

                command.ExecuteNonQuery();
            }
        }

        public Producto BuscarProductoPorRef(string refproducto)
        {
            using (var command = _connection.CreateCommand())
            {

                command.CommandText = "select *from Producto where RefProducto=@RefProducto";
                command.Parameters.Add(new SqlParameter("@RefProducto", refproducto));
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Producto producto = new Producto();
                        producto.RefProducto = reader.GetString(0);
                        producto.NombreProducto = reader.GetString(1);
                        producto.PesoProducto = decimal.Parse(reader.GetString(2));
                        producto.PrecioProducto = decimal.Parse(reader.GetString(2));
                        
                        return producto;
                    }
                }
                reader.Close();
            }
            return null;
        }

        public void EliminarProductoRep(string refproducto)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "delete From Producto where RefProducto=@RefProducto";
                command.Parameters.Add(new SqlParameter("@RefProducto", refproducto));
                command.ExecuteNonQuery();
            }
        }

        public void ModificarProducto(Producto productoNuevo, string refproducto)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "update Producto set RefProducto=@RefProducto,Nombre=@Nombre,Peso=@Peso,Precio=@Precio" +
                    " where RefProducto=@RefProducto";
                command.Parameters.Add(new SqlParameter("@RefProducto", refproducto));
                command.Parameters.Add(new SqlParameter("@Nombre", productoNuevo.NombreProducto));
                command.Parameters.Add(new SqlParameter("@Peso", productoNuevo.PesoProducto));
                command.Parameters.Add(new SqlParameter("@Precio", productoNuevo.PrecioProducto));               

                command.ExecuteNonQuery();
            }
        }

        public List<Producto> ConsultarTodosLosProductos(string refproducto)
        {
            List<Producto> productos = new List<Producto>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from Producto where RefProducto=@RefProducto";
                command.Parameters.Add(new SqlParameter("@RefProducto", refproducto));
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Producto producto = new Producto();
                    producto.RefProducto = reader.GetString(0);
                    producto.NombreProducto = reader.GetString(1);                 
                    producto.PesoProducto = decimal.Parse(reader.GetString(2));
                    producto.PrecioProducto = decimal.Parse(reader.GetString(3));

                    productos.Add(producto);
                }
                reader.Close();
            }

            return productos;
        }
    }
}
