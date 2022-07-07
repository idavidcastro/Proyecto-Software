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

        public void EliminarContenedorRep(string refcontenedor)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "delete From Contenedor where RefContenedor=@RefContenedor";
                command.Parameters.Add(new SqlParameter("@RefContenedor", refcontenedor));
                command.ExecuteNonQuery();
            }
        }
        
        public void ModificarContenedor(Contenedor contenedorNuevo, string refcontenedor)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "update Contenedor set RefContenedor=@RefContenedor, RefEstibado=@RefEstibado, TipoContenedor=@TipoContenedor, Largo=@Largo, Ancho=@Ancho, EstibadoXLargo=@EstibadoXLargo, EstibadoXAncho=@EstibadoXAncho, TotalEstibasXContenedor=@TotalEstibasXContenedor, NumEstibasXProducto=@NumEstibasXProducto, TotalEmbalajesEnContenedor=@TotalEmbalajesEnContenedor" +
                    " where RefContenedor=@RefContenedor";

                command.Parameters.Add(new SqlParameter("@RefContenedor", refcontenedor));
                command.Parameters.Add(new SqlParameter("@RefEstibado", contenedorNuevo.Estibado.RefEstibado));
                command.Parameters.Add(new SqlParameter("@TipoContenedor", contenedorNuevo.TipoContenedor));
                command.Parameters.Add(new SqlParameter("@Largo", contenedorNuevo.LargoContenedor));
                command.Parameters.Add(new SqlParameter("@Ancho", contenedorNuevo.AnchoContenedor));
                command.Parameters.Add(new SqlParameter("@EstibadoXLargo", contenedorNuevo.EstibadoXLargo));
                command.Parameters.Add(new SqlParameter("@EstibadoXAncho", contenedorNuevo.EstibadoXAncho));
                command.Parameters.Add(new SqlParameter("@TotalEstibasXContenedor", contenedorNuevo.TotalEstibasXContenedor));
                command.Parameters.Add(new SqlParameter("@NumEstibasXProducto", contenedorNuevo.NumEstibasXProducto));
                command.Parameters.Add(new SqlParameter("@TotalEmbalajesEnContenedor", contenedorNuevo.TotalEmbalajesEnContenedor));

                command.ExecuteNonQuery();
            }
        }
        
        public List<Contenedor> ConsultarTodosLosContenedores(string refcontenedor)
        {
            List<Contenedor> contenedores = new List<Contenedor>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from Contenedor where RefContenedor=@RefContenedor";
                command.Parameters.Add(new SqlParameter("@RefContenedor", refcontenedor));
                var reader = command.ExecuteReader();
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

                    contenedores.Add(contenedor);
                }
                reader.Close();
            }

            return contenedores;
        }
    }
}
