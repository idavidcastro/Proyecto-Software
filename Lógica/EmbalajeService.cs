using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lógica
{
    public class EmbalajeService
    {
        EmbalajeRepository embalajeRepository;
        ConnectionManager connectionManager;
        //List<Empaque> empaques;
        public EmbalajeService(string connectionstring)
        {
            connectionManager = new ConnectionManager(connectionstring);
            embalajeRepository = new EmbalajeRepository(connectionManager.Connetion);

        }

        public string GuardarEmbalaje(Embalaje embalaje)
        {
            try
            {
                connectionManager.Open();

                if (embalajeRepository.BuscarEmbalajePorRef(embalaje.RefEmbalaje) == null)
                {
                    embalajeRepository.GuardarEmbalajeRep(embalaje);
                    return "El nuevo embalaje ha sido registrado correctamente!";
                }
                else
                {
                    return $"El embalaje con la referencia {embalaje.RefEmbalaje}, ya se encuentra registrado";
                }
            }
            catch (Exception exception)
            {
                return "Se presentó el siguiente error:" + exception.Message;
            }
            finally
            {
                connectionManager.Close();
            }

        }

        public string EliminarEmbalaje(string refembalaje)
        {
            try
            {
                connectionManager.Open();
                if (embalajeRepository.BuscarEmbalajePorRef(refembalaje) != null)
                {
                    embalajeRepository.EliminarEmbalajeRep(refembalaje);
                    return $"Se eliminó el embalaje con la referencia {refembalaje}";
                }
                return $"No se encontró el embalaje con referencia {refembalaje}";
            }
            catch (Exception exception)
            {

                return "Se presentó el siguiente error: " + exception.Message;
            }
            finally
            {
                connectionManager.Close();
            }
        }
        /*
        public string ModificarEmbalaje(Embalaje embalajeNuevo, string refembalaje)
        {

            try
            {
                connectionManager.Open();

                if (embalajeRepository.BuscarEmbalajePorRef(refembalaje) != null)
                {
                    embalajeRepository.ModificarEmbalaje(embalajeNuevo, refembalaje);
                    return $"Se modificó el embalaje con la referencia {refembalaje}";
                }
                return $"No se encontró el embalaje con la referencia {refembalaje}";
            }
            catch (Exception exception)
            {

                return "Se presentó el siguiente error: " + exception.Message;
            }
            finally
            {
                connectionManager.Close();
            }
        }
        
        public ConsultaReponseEmbalaje ConsultarListEmbalaje(string refempaque)
        {
            try
            {
                connectionManager.Open();

                return new ConsultaReponseEmbalaje(embalajeRepository.ConsultarTodosLosEmbalajes(refempaque));
            }
            catch (Exception exception)
            {
                return new ConsultaReponseEmbalaje("Se presentó el siguiente error: " + exception.Message);
            }
            finally
            {
                connectionManager.Close();
            }
        }
        */
        public BusquedaReponseEmbalaje BuscarEmbalaje(string refembalaje)
        {
            try
            {
                connectionManager.Open();
                if (embalajeRepository.BuscarEmbalajePorRef(refembalaje) == null)
                {
                    return new BusquedaReponseEmbalaje($"El embalaje con la referencia {refembalaje} NO se encuentra registrado");

                }
                else
                {
                    return new BusquedaReponseEmbalaje(embalajeRepository.BuscarEmbalajePorRef(refembalaje));
                }
            }
            catch (Exception exception)
            {

                return new BusquedaReponseEmbalaje("Se presentó el siguiente error: " + exception.Message);
            }
            finally
            {
                connectionManager.Close();
            }

        }

    }
    public class ConsultaReponseEmbalaje
    {
        public List<Embalaje> Embalajes { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public ConsultaReponseEmbalaje(List<Embalaje> embalajes)
        {
            Embalajes = embalajes;
            Error = false;
        }

        public ConsultaReponseEmbalaje(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }
    public class BusquedaReponseEmbalaje
    {
        public Embalaje Embalaje { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public BusquedaReponseEmbalaje(Embalaje embalaje)
        {
            Embalaje = embalaje;
            Error = false;
        }

        public BusquedaReponseEmbalaje(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }
}
