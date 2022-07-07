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

        public void EliminarEstibadoRep(string refestibado)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "delete From Estibado where RefEstibado=@RefEstibado";
                command.Parameters.Add(new SqlParameter("@RefEstibado", refestibado));
                command.ExecuteNonQuery();
            }
        }
        
        public void ModificarEstibado(Estibado estibadoNuevo, string refestibado)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "update Estibado set RefEstibado=@RefEstibado, RefEmbalaje=@RefEmbalaje, Largo=@Largo, Ancho=@Ancho, Alto=@Alto, EmbalajeXLargo=@EmbalajeXLargo, EmbalajeXAncho=@EmbalajeXAncho, EmbalajeXAlto=@EmbalajeXAlto, TotalEmbalajesXEstibas=@TotalEmbalajesXEstibas" +
                    " where RefEstibado=@RefEstibado";

                command.Parameters.Add(new SqlParameter("@RefEstibado", refestibado));
                command.Parameters.Add(new SqlParameter("@RefEmbalaje", estibadoNuevo.Embalaje.RefEmbalaje));
                command.Parameters.Add(new SqlParameter("@Largo", estibadoNuevo.LargoEstibado));
                command.Parameters.Add(new SqlParameter("@Ancho", estibadoNuevo.AnchoEstibado));
                command.Parameters.Add(new SqlParameter("@Alto", estibadoNuevo.AltoEstibado));
                command.Parameters.Add(new SqlParameter("@EmbalajeXLargo", estibadoNuevo.EmbalajeXLargo));
                command.Parameters.Add(new SqlParameter("@EmbalajeXAncho", estibadoNuevo.EmbalajeXAncho));
                command.Parameters.Add(new SqlParameter("@EmbalajeXAlto", estibadoNuevo.EmbalajeXAlto));
                command.Parameters.Add(new SqlParameter("@TotalEmbalajesXEstibas", estibadoNuevo.TotalEmbalajesXEstibas));

                command.ExecuteNonQuery();
            }
        }
        
        public List<Estibado> ConsultarTodosLosEstibado(string refestibado)
        {
            List<Estibado> estibados = new List<Estibado>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from Estibado where RefEstibado=@RefEstibado";
                command.Parameters.Add(new SqlParameter("@RefEstibado", refestibado));
                var reader = command.ExecuteReader();
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

                    estibados.Add(estibado);
                }
                reader.Close();
            }

            return estibados;
        }
    }
}
