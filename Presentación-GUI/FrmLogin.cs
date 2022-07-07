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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(ConfigConnectionString.Cadena);
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Logear(string usuario, string contraseña)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT NombreUsuario, Contraseña from Usuario where NombreUsuario = @NombreUsuario AND Contraseña = @Contraseña", con);
                cmd.Parameters.AddWithValue("@NombreUsuario", usuario);
                cmd.Parameters.AddWithValue("@Contraseña", contraseña);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    FrmOrden frmOrden = new FrmOrden();
                    frmOrden.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Credenciales incorrectas");
                }

            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        private void BtnIniciarSesionLogin_Click(object sender, EventArgs e)
        {
            Logear(TxtUsuario.Text, TxtContraseña.Text);
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
