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
    public class ContenedorRepository
    {
        DbConnection _connection;
        private List<Contenedor> contenedores;
        public ContenedorRepository(DbConnection connection)
        {
            _connection = connection;
            contenedores = new List<Contenedor>();
        }

        public void GuardarContenedorRep(Contenedor contenedor)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "insert into Contenedor(RefContenedor, RefEstibado, TipoContenedor, Largo, Ancho, EstibadoXLargo, EstibadoXAncho, TotalEstibasXContenedor, NumEstibasXProducto, TotalEmbalajesEnContenedor)" +
                              " values (@RefContenedor,@RefEstibado,@TipoContenedor, @Largo, @Ancho, @EstibadoXLargo, @EstibadoXAncho,@TotalEstibasXContenedor, @NumEstibasXProducto, @TotalEmbalajesEnContenedor)";
                command.Parameters.Add(new SqlParameter("@RefContenedor", contenedor.RefContenedor));
                command.Parameters.Add(new SqlParameter("@RefEstibado", contenedor.Estibado.RefEstibado));
                command.Parameters.Add(new SqlParameter("@TipoContenedor", contenedor.TipoContenedor));
                command.Parameters.Add(new SqlParameter("@Largo", contenedor.LargoContenedor));
                command.Parameters.Add(new SqlParameter("@Ancho", contenedor.AnchoContenedor));
                command.Parameters.Add(new SqlParameter("@EstibadoXLargo", contenedor.EstibadoXLargo));
                command.Parameters.Add(new SqlParameter("@EstibadoXAncho", contenedor.EstibadoXAncho));
                command.Parameters.Add(new SqlParameter("@TotalEstibasXContenedor", contenedor.TotalEstibasXContenedor));
                command.Parameters.Add(new SqlParameter("@NumEstibasXProducto", contenedor.NumEstibasXProducto));
                command.Parameters.Add(new SqlParameter("@TotalEmbalajesEnContenedor", contenedor.TotalEmbalajesEnContenedor));

                command.ExecuteNonQuery();
            }
        }

        public Contenedor BuscarContenedorPorRef(string refcontenedor)
        {
            using (var command = _connection.CreateCommand())
            {

                command.CommandText = "select *from Contenedor where RefContenedor=@RefContenedor";
                command.Parameters.Add(new SqlParameter("@RefContenedor", refcontenedor));
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Contenedor contenedor = new Contenedor();
                        contenedor.RefContenedor = reader.GetString(0);
                        contenedor.Estibado = new Estibado();
                        contenedor.Estibado.RefEstibado = reader.GetString(1);
                        contenedor.TipoContenedor = reader.GetString(2);
                        contenedor.LargoContenedor = decimal.Parse(reader.GetString(3));
                        contenedor.AnchoContenedor = decimal.Parse(reader.GetString(4));
                        contenedor.EstibadoXLargo = decimal.Parse(reader.GetString(5));
                        contenedor.EstibadoXAncho = decimal.Parse(reader.GetString(6));
                        contenedor.TotalEstibasXContenedor = decimal.Parse(reader.GetString(7));
                        contenedor.NumEstibasXProducto = int.Parse(reader.GetString(8));
                        contenedor.TotalEmbalajesEnContenedor = int.Parse(reader.GetString(9));

                        return contenedor;
                    }
                }
                reader.Close();
            }
            return null;
        }

        public void EliminarEmbalajeRep(string refempaque)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "delete From Empaque where RefEmpaque=@RefEmpaque";
                command.Parameters.Add(new SqlParameter("@RefEmpaque", refempaque));
                command.ExecuteNonQuery();
            }
        }
        /*
        public void ModificarEmbalaje(Embalaje embalajeNuevo, string refembalaje)
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
        */
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
                    empaque.Producto.PesoProducto = double.Parse(reader.GetString(3));
                    empaque.Producto.PrecioProducto = double.Parse(reader.GetString(4));
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
