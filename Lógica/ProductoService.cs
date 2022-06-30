using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lógica
{
    public class ProductoService
    {
        ProductoRepository productoRepository;
        ConnectionManager connectionManager;
        //List<Cliente> clientes;
        public ProductoService(string connectionstring)
        {
            connectionManager = new ConnectionManager(connectionstring);
            productoRepository = new ProductoRepository(connectionManager.Connetion);

        }

        public string GuardarProducto(Producto producto)
        {
            try
            {
                connectionManager.Open();

                if (productoRepository.BuscarProductoPorRef(producto.RefProducto) == null)
                {
                    productoRepository.GuardarProductoRep(producto);
                    return "El nuevo producto ha sido registrado correctamente!";
                }
                else
                {
                    return $"El producto con la referencia {producto.RefProducto}, ya se encuentra registrado";
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

        public string EliminarProducto(string refproducto)
        {
            try
            {
                connectionManager.Open();
                if (productoRepository.BuscarProductoPorRef(refproducto) != null)
                {
                    productoRepository.EliminarProductoRep(refproducto);
                    return $"Se eliminó el producto con la referencia {refproducto}";
                }
                return $"No se encontró el producto con referencia {refproducto}";
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

        public string ModificarProducto(Producto productoNuevo, string refproducto)
        {

            try
            {
                connectionManager.Open();

                if (productoRepository.BuscarProductoPorRef(refproducto) != null)
                {
                    productoRepository.ModificarProducto(productoNuevo, refproducto);
                    return $"Se modificó el producto con la referencia {refproducto}";
                }
                return $"No se encontró el producto con la referencia {refproducto}";
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

        public ConsultaReponseProducto ConsultarListProductos(string refproducto)
        {
            try
            {
                connectionManager.Open();
                
                 return new ConsultaReponseProducto(productoRepository.ConsultarTodosLosProductos(refproducto));
            }
            catch (Exception exception)
            {
                return new ConsultaReponseProducto("Se presentó el siguiente error: " + exception.Message);
            }
            finally
            {
                connectionManager.Close();
            }
        }

        public BusquedaReponse BuscarProducto(string refproducto)
        {
            try
            {
                connectionManager.Open();
                if (productoRepository.BuscarProductoPorRef(refproducto) == null)
                {
                    return new BusquedaReponse($"El producto con la referencia {refproducto} NO se encuentra registrado");

                }
                else
                {
                    return new BusquedaReponse(productoRepository.BuscarProductoPorRef(refproducto));
                }
            }
            catch (Exception exception)
            {

                return new BusquedaReponse("Se presentó el siguiente error: " + exception.Message);
            }
            finally
            {
                connectionManager.Close();
            }

        }



    }

    public class ConsultaReponseProducto
    {
        public List<Producto> Productos { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public ConsultaReponseProducto(List<Producto> productos)
        {
            Productos = productos;
            Error = false;
        }

        public ConsultaReponseProducto(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }
    public class BusquedaReponse
    {
        public Producto Producto { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public BusquedaReponse(Producto producto)
        {
            Producto = producto;
            Error = false;
        }

        public BusquedaReponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }
}
