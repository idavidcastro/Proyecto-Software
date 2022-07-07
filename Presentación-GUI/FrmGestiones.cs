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
    public partial class FrmGestiones : Form
    {
        public FrmGestiones()
        {
            InitializeComponent();
        }
        public void MostrarFormulario(Form formulario)
        {
            if (PanelBlancoGestiones.Controls.Count > 0)
            {
                PanelBlancoGestiones.Controls.RemoveAt(0);
            }

            formulario.TopLevel = false;
            this.PanelBlancoGestiones.Controls.Add(formulario);
            formulario.Show();
        }
        private void BtnProductoStock_Click(object sender, EventArgs e)
        {
            FrmProductos frmProductos = new FrmProductos();
            MostrarFormulario(frmProductos);
        }

        private void BtnGestionarEmpaque_Click(object sender, EventArgs e)
        {
            FrmGestionarEmpaque frmGestionarEmpaque = new FrmGestionarEmpaque();
            MostrarFormulario(frmGestionarEmpaque);
        }

        private void BtnGestionarEmbalaje_Click(object sender, EventArgs e)
        {
            FrmGestionarEmbalaje frmGestionarEmbalaje = new FrmGestionarEmbalaje();
            MostrarFormulario(frmGestionarEmbalaje);
        }

        private void BtnGestionarEstibado_Click(object sender, EventArgs e)
        {
            FrmGestionarEstibado frmGestionarEstibado = new FrmGestionarEstibado();
            MostrarFormulario(frmGestionarEstibado);
        }

        private void BtnGestionarContenedor_Click(object sender, EventArgs e)
        {
            FrmGestionarContenedor frmGestionarContenedor = new FrmGestionarContenedor();
            MostrarFormulario(frmGestionarContenedor);
        }

        private void BtnCostoFinal_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnVolverGestiones_Click(object sender, EventArgs e)
        {
            DialogResult resul = MessageBox.Show("¿Está seguro que quiere volver al panel de gestiones?", "Cerrar", MessageBoxButtons.YesNo);
            if (resul == DialogResult.Yes)
            {
                FrmOrden frmOrden = new FrmOrden();
                frmOrden.Show();
                Hide();
            }
        }
    }
}
