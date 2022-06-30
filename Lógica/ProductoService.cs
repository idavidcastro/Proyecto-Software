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
    }
}
