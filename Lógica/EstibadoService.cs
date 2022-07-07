using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lógica
{
    public class EstibadoService
    {
        EstibadoRepository estibadoRepository;
        ConnectionManager connectionManager;
        //List<Empaque> empaques;
        public EstibadoService(string connectionstring)
        {
            connectionManager = new ConnectionManager(connectionstring);
            estibadoRepository = new EstibadoRepository(connectionManager.Connetion);

        }

        public string GuardarEstibado(Estibado estibado)
        {
            try
            {
                connectionManager.Open();

                if (estibadoRepository.BuscarEstibadoPorRef(estibado.RefEstibado) == null)
                {
                    estibadoRepository.GuardarEstibadoRep(estibado);
                    return "El nuevo estibado ha sido registrado correctamente!";
                }
                else
                {
                    return $"El estibado con la referencia {estibado.RefEstibado}, ya se encuentra registrado";
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
        
        public string EliminarEstibado(string refestibado)
        {
            try
            {
                connectionManager.Open();
                if (estibadoRepository.BuscarEstibadoPorRef(refestibado) != null)
                {
                    estibadoRepository.EliminarEstibadoRep(refestibado);
                    return $"Se eliminó el estibado con la referencia {refestibado}";
                }
                return $"No se encontró el estibado con referencia {refestibado}";
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
        
        public string ModificarEstibado(Estibado estibadeNuevo, string refestibado)
        {

            try
            {
                connectionManager.Open();

                if (estibadoRepository.BuscarEstibadoPorRef(refestibado) != null)
                {
                    estibadoRepository.ModificarEstibado(estibadeNuevo, refestibado);
                    return $"Se modificó el estibado con la referencia {refestibado}";
                }
                return $"No se encontró el estibado con la referencia {refestibado}";
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
        
        public ConsultaReponseEstibado ConsultarListEstibado(string refestibado)
        {
            try
            {
                connectionManager.Open();

                return new ConsultaReponseEstibado(estibadoRepository.ConsultarTodosLosEstibado(refestibado));
            }
            catch (Exception exception)
            {
                return new ConsultaReponseEstibado("Se presentó el siguiente error: " + exception.Message);
            }
            finally
            {
                connectionManager.Close();
            }
        }
        
        public BusquedaReponseEstibado BuscarEstibado(string refestibado)
        {
            try
            {
                connectionManager.Open();
                if (estibadoRepository.BuscarEstibadoPorRef(refestibado) == null)
                {
                    return new BusquedaReponseEstibado($"El estibado con la referencia {refestibado} NO se encuentra registrado");

                }
                else
                {
                    return new BusquedaReponseEstibado(estibadoRepository.BuscarEstibadoPorRef(refestibado));
                }
            }
            catch (Exception exception)
            {

                return new BusquedaReponseEstibado("Se presentó el siguiente error: " + exception.Message);
            }
            finally
            {
                connectionManager.Close();
            }

        }
        
    }
    
    public class ConsultaReponseEstibado
    {
        public List<Estibado> Estibados { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public ConsultaReponseEstibado(List<Estibado> estibados)
        {
            Estibados = estibados;
            Error = false;
        }

        public ConsultaReponseEstibado(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }
    public class BusquedaReponseEstibado
    {
        public Estibado Estibado { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public BusquedaReponseEstibado(Estibado estibado)
        {
            Estibado=estibado;
            Error = false;
        }

        public BusquedaReponseEstibado(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }
    
}
