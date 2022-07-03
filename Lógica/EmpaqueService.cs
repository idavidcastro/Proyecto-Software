using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lógica
{
    public class EmpaqueService
    {
        EmpaqueRepository empaqueRepository;
        ConnectionManager connectionManager;
        //List<Empaque> empaques;
        public EmpaqueService(string connectionstring)
        {
            connectionManager = new ConnectionManager(connectionstring);
            empaqueRepository = new EmpaqueRepository(connectionManager.Connetion);

        }

        public string GuardarEmpaque(Empaque empaque)
        {
            try
            {
                connectionManager.Open();

                if (empaqueRepository.BuscarEmpaquePorRef(empaque.RefEmpaque) == null)
                {
                    empaqueRepository.GuardarEmpaqueRep(empaque);
                    return "El nuevo empaque ha sido registrado correctamente!";
                }
                else
                {
                    return $"El empaque con la referencia {empaque.RefEmpaque}, ya se encuentra registrado";
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

        public string EliminarEmpaque(string refempaque)
        {
            try
            {
                connectionManager.Open();
                if (empaqueRepository.BuscarEmpaquePorRef(refempaque) != null)
                {
                    empaqueRepository.EliminarEmpaqueRep(refempaque);
                    return $"Se eliminó el empaque con la referencia {refempaque}";
                }
                return $"No se encontró el empaque con referencia {refempaque}";
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

        public string ModificarEmpaque(Empaque empaqueNuevo, string refempaque)
        {

            try
            {
                connectionManager.Open();

                if (empaqueRepository.BuscarEmpaquePorRef(refempaque) != null)
                {
                    empaqueRepository.ModificarEmpaque(empaqueNuevo, refempaque);
                    return $"Se modificó el empaque con la referencia {refempaque}";
                }
                return $"No se encontró el empaque con la referencia {refempaque}";
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

        public ConsultaReponseEmpaque ConsultarListEmpaques(string refempaque)
        {
            try
            {
                connectionManager.Open();

                return new ConsultaReponseEmpaque(empaqueRepository.ConsultarTodosLosEmpaques(refempaque));
            }
            catch (Exception exception)
            {
                return new ConsultaReponseEmpaque("Se presentó el siguiente error: " + exception.Message);
            }
            finally
            {
                connectionManager.Close();
            }
        }

        public BusquedaReponseEmpaque BuscarEmpaque(string refempaque)
        {
            try
            {
                connectionManager.Open();
                if (empaqueRepository.BuscarEmpaquePorRef(refempaque) == null)
                {
                    return new BusquedaReponseEmpaque($"El empaque con la referencia {refempaque} NO se encuentra registrado");

                }
                else
                {
                    return new BusquedaReponseEmpaque(empaqueRepository.BuscarEmpaquePorRef(refempaque));
                }
            }
            catch (Exception exception)
            {

                return new BusquedaReponseEmpaque("Se presentó el siguiente error: " + exception.Message);
            }
            finally
            {
                connectionManager.Close();
            }

        }
    }
    public class ConsultaReponseEmpaque
    {
        public List<Empaque> Empaques { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public ConsultaReponseEmpaque(List<Empaque> empaques)
        {
            Empaques = empaques;
            Error = false;
        }

        public ConsultaReponseEmpaque(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }
    public class BusquedaReponseEmpaque
    {
        public Empaque Empaque { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public BusquedaReponseEmpaque(Empaque empaque)
        {
            Empaque = empaque;
            Error = false;
        }

        public BusquedaReponseEmpaque(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }
}
