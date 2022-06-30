using Entidad;
using Lógica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            producto.PesoProducto = decimal.Parse(TxtPesoProducto.Text);
            producto.PrecioProducto = decimal.Parse(TxtPrecioProducto.Text);         

            string mensaje = productoService.GuardarProducto(producto);
            MessageBox.Show(mensaje, "Guardar producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TxtPesoProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
                return;
            }
        }

        private void TxtPrecioProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
                return;
            }
        }

        private void TxtNombreProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
