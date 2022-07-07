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
    public class EmbalajeRepository
    {
        DbConnection _connection;
        private List<Embalaje> embalajes;
        public EmbalajeRepository(DbConnection connection)
        {
            _connection = connection;
            embalajes = new List<Embalaje>();
        }

        public void GuardarEmbalajeRep(Embalaje embalaje)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "insert into Embalaje(RefEmbalaje, RefEmpaque, Largo, Ancho, Alto, EmpXLargo, EmpXAncho, EmpXAlto, TotalEmpaqueXEmbalaje)" +
                              " values (@RefEmbalaje,@RefEmpaque,@Largo, @Ancho, @Alto, @EmpXLargo, @EmpXAncho, @EmpXAlto, @TotalEmpaqueXEmbalaje)";
                command.Parameters.Add(new SqlParameter("@RefEmbalaje", embalaje.RefEmbalaje));
                command.Parameters.Add(new SqlParameter("@RefEmpaque", embalaje.Empaque.RefEmpaque));
                command.Parameters.Add(new SqlParameter("@Largo", embalaje.Largo));
                command.Parameters.Add(new SqlParameter("@Ancho", embalaje.Ancho));
                command.Parameters.Add(new SqlParameter("@Alto", embalaje.Alto));
                command.Parameters.Add(new SqlParameter("@EmpXLargo", embalaje.EmpProdXLargo));
                command.Parameters.Add(new SqlParameter("@EmpXAncho", embalaje.EmpProdXAncho));
                command.Parameters.Add(new SqlParameter("@EmpXAlto", embalaje.EmpProdXAlto));
                command.Parameters.Add(new SqlParameter("@TotalEmpaqueXEmbalaje", embalaje.TotalEmpPrimarioXEmbalaje));

                command.ExecuteNonQuery();
            }
        }

        public Embalaje BuscarEmbalajePorRef(string refembalaje)
        {
            using (var command = _connection.CreateCommand())
            {

                command.CommandText = "select *from Embalaje where RefEmbalaje=@RefEmbalaje";
                command.Parameters.Add(new SqlParameter("@RefEmbalaje", refembalaje));
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        /*
                        Embalaje embalaje = new Embalaje();
                        embalaje.RefEmbalaje = reader.GetString(0);
                        embalaje.Empaque = new Empaque();
                        embalaje.Empaque.RefProducto = reader.GetString(1);
                        embalaje.Producto.NombreProducto = reader.GetString(2);
                        embalaje.Producto.PesoProducto = decimal.Parse(reader.GetString(3));
                        embalaje.Producto.PrecioProducto = decimal.Parse(reader.GetString(4));
                        empaque.Largo = decimal.Parse(reader.GetString(5));
                        empaque.Ancho = decimal.Parse(reader.GetString(6));
                        empaque.Alto = decimal.Parse(reader.GetString(7));
                        empaque.PesoEmpaque = decimal.Parse(reader.GetString(8));
                        empaque.CantidadProductos = int.Parse(reader.GetString(9));
                        empaque.PrecioProdxCantProd = decimal.Parse(reader.GetString(10));
                        empaque.PesoEmpaquexPesoProducto = decimal.Parse(reader.GetString(11));

                        return empaque;
                        */
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
