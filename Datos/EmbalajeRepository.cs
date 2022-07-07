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
                        
                        Embalaje embalaje = new Embalaje();
                        embalaje.RefEmbalaje = reader.GetString(0);
                        embalaje.Empaque = new Empaque();
                        embalaje.Empaque.RefEmpaque = reader.GetString(1);
                        embalaje.Largo= decimal.Parse(reader.GetString(2));
                        embalaje.Ancho= decimal.Parse(reader.GetString(3));
                        embalaje.Alto = decimal.Parse(reader.GetString(4));
                        embalaje.EmpProdXLargo = decimal.Parse(reader.GetString(5));
                        embalaje.EmpProdXAncho = decimal.Parse(reader.GetString(6));
                        embalaje.EmpProdXAlto = decimal.Parse(reader.GetString(7));
                        embalaje.TotalEmpPrimarioXEmbalaje = decimal.Parse(reader.GetString(8));


                        return embalaje;
                        
                    }
                }
                reader.Close();
            }
            return null;
        }

        public void EliminarEmbalajeRep(string refembalaje)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "delete From Embalaje where RefEmbalaje=@RefEmbalaje";
                command.Parameters.Add(new SqlParameter("@RefEmbalaje", refembalaje));
                command.ExecuteNonQuery();
            }
        }
        
        public void ModificarEmbalaje(Embalaje embalajeNuevo, string refembalaje)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "update Embalaje set RefEmbalaje=@RefEmbalaje, RefEmpaque=@RefEmpaque, Largo=@Largo, Ancho=@Ancho, Alto=@Alto, EmpXLargo=@EmpXLargo, EmpXAncho=@EmpXAncho, EmpXAlto=@EmpXAlto, TotalEmpaqueXEmbalaje=@TotalEmpaqueXEmbalaje" +
                    " where RefEmbalaje=@RefEmbalaje";

                command.Parameters.Add(new SqlParameter("@RefEmbalaje", refembalaje));
                command.Parameters.Add(new SqlParameter("@RefEmpaque", embalajeNuevo.Empaque.RefEmpaque));;
                command.Parameters.Add(new SqlParameter("@Largo", embalajeNuevo.Largo));
                command.Parameters.Add(new SqlParameter("@Ancho", embalajeNuevo.Ancho));
                command.Parameters.Add(new SqlParameter("@Alto", embalajeNuevo.Alto));
                command.Parameters.Add(new SqlParameter("@EmpXLargo", embalajeNuevo.EmpProdXLargo));
                command.Parameters.Add(new SqlParameter("@EmpXAncho", embalajeNuevo.EmpProdXAncho));
                command.Parameters.Add(new SqlParameter("@EmpXAlto", embalajeNuevo.EmpProdXAlto));
                command.Parameters.Add(new SqlParameter("@TotalEmpaqueXEmbalaje", embalajeNuevo.TotalEmpPrimarioXEmbalaje));

                command.ExecuteNonQuery();
            }
        }
        
        public List<Embalaje> ConsultarTodosLosEmbalajes(string refembalaje)
        {
            List<Embalaje> embalajes = new List<Embalaje>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from Embalaje where RefEmbalaje=@RefEmbalaje";
                command.Parameters.Add(new SqlParameter("@RefEmbalaje", refembalaje));
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Embalaje embalaje = new Embalaje();
                    embalaje.RefEmbalaje = reader.GetString(0);
                    embalaje.Empaque = new Empaque();
                    embalaje.Empaque.RefEmpaque = reader.GetString(1);
                    embalaje.Largo = decimal.Parse(reader.GetString(2));
                    embalaje.Ancho = decimal.Parse(reader.GetString(3));
                    embalaje.Alto = decimal.Parse(reader.GetString(4));
                    embalaje.EmpProdXLargo = decimal.Parse(reader.GetString(5));
                    embalaje.EmpProdXAncho = decimal.Parse(reader.GetString(6));
                    embalaje.EmpProdXAlto = decimal.Parse(reader.GetString(7));
                    embalaje.TotalEmpPrimarioXEmbalaje = decimal.Parse(reader.GetString(8));

                    embalajes.Add(embalaje);
                }
                reader.Close();
            }

            return embalajes;
        }
    }
}
