using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lógica
{
    public class ContenedorService
    {
        ContenedorRepository contenedorRepository;
        ConnectionManager connectionManager;
        //List<Empaque> empaques;
        public ContenedorService(string connectionstring)
        {
            connectionManager = new ConnectionManager(connectionstring);
            contenedorRepository = new ContenedorRepository(connectionManager.Connetion);

        }

        public string GuardarContenedor(Contenedor contenedor)
        {
            try
            {
                connectionManager.Open();

                if (contenedorRepository.BuscarContenedorPorRef(contenedor.RefContenedor) == null)
                {
                    contenedorRepository.GuardarContenedorRep(contenedor);
                    return "El nuevo contenedor ha sido registrado correctamente!";
                }
                else
                {
                    return $"El contenedor con la referencia {contenedor.RefContenedor}, ya se encuentra registrado";
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
        
        public string EliminarContenedor(string refcontenedor)
        {
            try
            {
                connectionManager.Open();
                if (contenedorRepository.BuscarContenedorPorRef(refcontenedor) != null)
                {
                    contenedorRepository.EliminarContenedorRep(refcontenedor);
                    return $"Se eliminó el contenedor con la referencia {refcontenedor}";
                }
                return $"No se encontró el contenedor con referencia {refcontenedor}";
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
        
        public string ModificarContenedor(Contenedor contenedorNuevo, string refcontenedor)
        {

            try
            {
                connectionManager.Open();

                if (contenedorRepository.BuscarContenedorPorRef(refcontenedor) != null)
                {
                    contenedorRepository.ModificarContenedor(contenedorNuevo, refcontenedor);
                    return $"Se modificó el contenedor con la referencia {refcontenedor}";
                }
                return $"No se encontró el contenedor con la referencia {refcontenedor}";
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
        
        public ConsultaReponseContenedor ConsultarListContenedor(string refcontenedor)
        {
            try
            {
                connectionManager.Open();

                return new ConsultaReponseContenedor(contenedorRepository.ConsultarTodosLosContenedores(refcontenedor));
            }
            catch (Exception exception)
            {
                return new ConsultaReponseContenedor("Se presentó el siguiente error: " + exception.Message);
            }
            finally
            {
                connectionManager.Close();
            }
        }
        
        public BusquedaReponseContenedor BuscarContenedor(string refcontenedor)
        {
            try
            {
                connectionManager.Open();
                if (contenedorRepository.BuscarContenedorPorRef(refcontenedor) == null)
                {
                    return new BusquedaReponseContenedor($"El contenedor con la referencia {refcontenedor} NO se encuentra registrado");

                }
                else
                {
                    return new BusquedaReponseContenedor(contenedorRepository.BuscarContenedorPorRef(refcontenedor));
                }
            }
            catch (Exception exception)
            {

                return new BusquedaReponseContenedor("Se presentó el siguiente error: " + exception.Message);
            }
            finally
            {
                connectionManager.Close();
            }

        }
        
    }
    
    public class ConsultaReponseContenedor
    {
        public List<Contenedor> Contenedores { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public ConsultaReponseContenedor(List<Contenedor> contenedores)
        {
            Contenedores = contenedores;
            Error = false;
        }

        public ConsultaReponseContenedor(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }
    public class BusquedaReponseContenedor
    {
        public Contenedor Contenedor { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public BusquedaReponseContenedor(Contenedor contenedor)
        {
            Contenedor = contenedor;
            Error = false;
        }

        public BusquedaReponseContenedor(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }
    
}
