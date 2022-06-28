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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnIniciarSesionLogin_Click(object sender, EventArgs e)
        {
            FrmOrden frmOrden = new FrmOrden();
            frmOrden.Show();
            this.Hide();
        }

        private void BtnCerrarLogin_Click(object sender, EventArgs e)
        {
            DialogResult resul = MessageBox.Show("¿Está seguro que quiere cerrar la aplicación?", "Cerrar", MessageBoxButtons.YesNo);
            if (resul == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
