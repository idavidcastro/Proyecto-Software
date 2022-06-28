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
    public partial class FrmOrden : Form
    {
        public FrmOrden()
        {
            InitializeComponent();
        }

        private void FrmOrden_Load(object sender, EventArgs e)
        {

        }

        private void BtnConsultarOrden_Click(object sender, EventArgs e)
        {
            
            if (PanelConsultarOrden.Visible == true)
            {
                PanelConsultarOrden.Visible = false;
            }
            else
            {
                PanelConsultarOrden.Visible = true;
            }
        }

        private void BtnNuevaOrden_Click(object sender, EventArgs e)
        {
            FrmGestiones frmGestiones = new FrmGestiones();
            frmGestiones.Show();
            Hide();
        }

        private void BtnCerrarOrden_Click(object sender, EventArgs e)
        {
            DialogResult resul = MessageBox.Show("¿Está seguro que quiere cerrar la aplicación?", "Cerrar", MessageBoxButtons.YesNo);
            if (resul == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
