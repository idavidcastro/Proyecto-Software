using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lógica
{
    public class OrdenService
    {
        OrdenRepository ordenRepository;
        ConnectionManager connectionManager;
        //List<Empaque> empaques;
        public OrdenService(string connectionstring)
        {
            connectionManager = new ConnectionManager(connectionstring);
            ordenRepository = new OrdenRepository(connectionManager.Connetion);

        }

        public string GuardarOrden(Orden orden)
        {
            try
            {
                connectionManager.Open();

                if (ordenRepository.BuscarOrdenPorRef(orden.RefOrden) == null)
                {
                    ordenRepository.GuardarOrdenRep(orden);
                    return "La nueva orden ha sido registrada correctamente!";
                }
                else
                {
                    return $"La orden con la referencia {orden.RefOrden}, ya se encuentra registrada";
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
        
        public string EliminarOrden(string reforden)
        {
            try
            {
                connectionManager.Open();
                if (ordenRepository.BuscarOrdenPorRef(reforden) != null)
                {
                    ordenRepository.EliminarOrdeRep(reforden);
                    return $"Se eliminó la orden con la referencia {reforden}";
                }
                return $"No se encontró la orden con la referencia {reforden}";
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
        
        public ConsultaReponseOrden ConsultarListOrden(string reforden)
        {
            try
            {
                connectionManager.Open();

                return new ConsultaReponseOrden(ordenRepository.ConsultarTodasLasOrdenes(reforden));
            }
            catch (Exception exception)
            {
                return new ConsultaReponseOrden("Se presentó el siguiente error: " + exception.Message);
            }
            finally
            {
                connectionManager.Close();
            }
        }
        /*
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
        */
    }
    
    public class ConsultaReponseOrden
    {
        public List<Orden> Ordenes { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public ConsultaReponseOrden(List<Orden> ordenes)
        {
            Ordenes = ordenes;
            Error = false;
        }

        public ConsultaReponseOrden(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }
    /*
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
    */
}
