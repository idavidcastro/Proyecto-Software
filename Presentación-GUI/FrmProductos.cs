using Entidad;
using Lógica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentación_GUI
{
    public partial class FrmProductos : Form
    {
        Producto producto;
        ProductoService productoService;
        public FrmProductos()
        {
            InitializeComponent();
            productoService = new ProductoService(ConfigConnectionString.Cadena);
            MostrarProductos();
        }
        private void MostrarProductos()
        {
            SqlConnection cn = new SqlConnection(ConfigConnectionString.Cadena);
            SqlCommand cm = new SqlCommand("select *from Producto", cn);
            cn.Open();
            SqlDataReader reader = cm.ExecuteReader()
;
            while (reader.Read())
            {
                CmbReferenciaProducto.Items.Add(reader.GetString(0));
                CmbReferenciaConsultaProducto.Items.Add(reader.GetString(0));
            }
            cn.Close();
        }
        private void FrmProductos_Load(object sender, EventArgs e)
        {
            BtnRegistrarProducto.Enabled = false;
        }
        private void ValidarCampos()
        {
            var vc = !string.IsNullOrEmpty(TxtRefProducto.Text) &&
                !string.IsNullOrEmpty(TxtNombreProducto.Text) &&
                !string.IsNullOrEmpty(TxtPesoProducto.Text) &&
                !string.IsNullOrEmpty(TxtPrecioProducto.Text);

            BtnRegistrarProducto.Enabled = vc;
        }

        private void TxtRefProducto_TextChanged(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void TxtNombreProducto_TextChanged(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void TxtPesoProducto_TextChanged(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void TxtPrecioProducto_TextChanged(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void BtnRegistrarProducto_Click(object sender, EventArgs e)
        {
            producto = new Producto();

            producto.RefProducto = TxtRefProducto.Text;
            producto.NombreProducto = TxtNombreProducto.Text;
            producto.PesoProducto = double.Parse(TxtPesoProducto.Text);
            producto.PrecioProducto = double.Parse(TxtPrecioProducto.Text);         

            string mensaje = productoService.GuardarProducto(producto);
            MessageBox.Show(mensaje, "Guardar producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TxtPesoProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void TxtPrecioProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void TxtNombreProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void BtnConsultarProducto_Click(object sender, EventArgs e)
        {
            ConsultaReponseProducto respuesta;
            dataGridViewConsultaProducto.DataSource = null;

            respuesta = productoService.ConsultarListProductos(CmbReferenciaConsultaProducto.Text);

            if (respuesta.Error)
            {
                MessageBox.Show(respuesta.Mensaje);
            }
            else
            {
                dataGridViewConsultaProducto.DataSource = respuesta.Productos;
            }
        }

        private void BtnEditarProducto_Click(object sender, EventArgs e)
        {
            
            BusquedaReponse respuesta;

            respuesta = productoService.BuscarProducto(CmbReferenciaProducto.Text);

            if (respuesta.Error)
            {
                MessageBox.Show(respuesta.Mensaje);
            }
            else
            {
                TxtRefProducto.Text = respuesta.Producto.RefProducto;
                TxtNombreProducto.Text = respuesta.Producto.NombreProducto;
                TxtPesoProducto.Text = respuesta.Producto.PesoProducto.ToString();
                TxtPrecioProducto.Text = respuesta.Producto.PrecioProducto.ToString();

            }
            /*
            SqlConnection cn = new SqlConnection(ConfigConnectionString.Cadena);
            cn.Open();
            SqlCommand cm = new SqlCommand("select * from Producto where RefProducto= '" + CmbReferenciaProducto.Text + "'", cn);
            SqlDataReader reader = cm.ExecuteReader();
            if (reader.Read() == true)
            {

                TxtRefProducto.Text = reader["RefProducto"].ToString();
                TxtNombreProducto.Text = reader["Nombre"].ToString();
                TxtPesoProducto.Text = reader["Peso"].ToString();
                TxtPrecioProducto.Text = reader["Precio"].ToString();

            }
            cn.Close();
            ValidarCampos();
            */
        }

        private void BtnActProducto_Click(object sender, EventArgs e)
        {
            producto = new Producto();

            producto.RefProducto = TxtRefProducto.Text;
            producto.NombreProducto = TxtNombreProducto.Text;
            producto.PesoProducto = double.Parse(TxtPesoProducto.Text);
            producto.PrecioProducto = double.Parse(TxtPrecioProducto.Text);

            string mensaje = productoService.ModificarProducto(producto, CmbReferenciaProducto.Text);
            MessageBox.Show(mensaje, "Modificar producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnEliminarProducto_Click(object sender, EventArgs e)
        {
            string mensaje = productoService.EliminarProducto(CmbReferenciaProducto.Text);
            MessageBox.Show(mensaje, "Modificar producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
