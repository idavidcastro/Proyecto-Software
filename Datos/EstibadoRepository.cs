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
    public class EstibadoRepository
    {
        DbConnection _connection;
        private List<Estibado> estibados;
        public EstibadoRepository(DbConnection connection)
        {
            _connection = connection;
            estibados = new List<Estibado>();
        }

        public void GuardarEstibadoRep(Estibado estibado)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "insert into Estibado(RefEstibado, RefEmbalaje, Largo, Ancho, Alto, EmbalajeXLargo, EmbalajeXAncho, EmbalajeXAlto, TotalEmbalajesXEstibas)" +
                              " values (@RefEstibado,@RefEmbalaje,@Largo, @Ancho, @Alto, @EmbalajeXLargo, @EmbalajeXAncho, @EmbalajeXAlto, @TotalEmbalajesXEstibas)";
                command.Parameters.Add(new SqlParameter("@RefEstibado", estibado.RefEstibado));
                command.Parameters.Add(new SqlParameter("@RefEmbalaje", estibado.Embalaje.RefEmbalaje));
                command.Parameters.Add(new SqlParameter("@Largo", estibado.LargoEstibado));
                command.Parameters.Add(new SqlParameter("@Ancho", estibado.AnchoEstibado));
                command.Parameters.Add(new SqlParameter("@Alto", estibado.AltoEstibado));
                command.Parameters.Add(new SqlParameter("@EmbalajeXLargo", estibado.EmbalajeXLargo));
                command.Parameters.Add(new SqlParameter("@EmbalajeXAncho", estibado.EmbalajeXAncho));
                command.Parameters.Add(new SqlParameter("@EmbalajeXAlto", estibado.EmbalajeXAlto));
                command.Parameters.Add(new SqlParameter("@TotalEmbalajesXEstibas", estibado.TotalEmbalajesXEstibas));

                command.ExecuteNonQuery();
            }
        }

        public Estibado BuscarEstibadoPorRef(string refestibado)
        {
            using (var command = _connection.CreateCommand())
            {

                command.CommandText = "select *from Estibado where RefEstibado=@RefEstibado";
                command.Parameters.Add(new SqlParameter("@RefEstibado", refestibado));
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        
                        Estibado estibado = new Estibado();
                        estibado.RefEstibado = reader.GetString(0);
                        estibado.Embalaje = new Embalaje();
                        estibado.Embalaje.RefEmbalaje = reader.GetString(1);
                        estibado.LargoEstibado = decimal.Parse(reader.GetString(2));
                        estibado.AnchoEstibado = decimal.Parse(reader.GetString(3));
                        estibado.AltoEstibado = decimal.Parse(reader.GetString(4));
                        estibado.EmbalajeXLargo = decimal.Parse(reader.GetString(5));
                        estibado.EmbalajeXAncho = decimal.Parse(reader.GetString(6));
                        estibado.EmbalajeXAlto = decimal.Parse(reader.GetString(7));
                        estibado.TotalEmbalajesXEstibas = decimal.Parse(reader.GetString(8));

                        return estibado;
                        
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
