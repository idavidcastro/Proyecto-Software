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
    public partial class FrmGestionarEmpaque : Form

    {
        Empaque empaque;
        EmpaqueService empaqueService;
        Producto producto;
        List<Producto> productos = new List<Producto>();
        ProductoService productoService;

        public FrmGestionarEmpaque()
        {
            InitializeComponent();
            empaqueService = new EmpaqueService(ConfigConnectionString.Cadena);
            productoService = new ProductoService(ConfigConnectionString.Cadena);
            MostrarProductos();
            
        }

        private void Calculos()
        {
            decimal precio, cantprod, total1, pesoEmpaque, pesoProducto, total2;
            precio = decimal.Parse(TxtPrecioProducto.Text);
            cantprod = decimal.Parse(TxtCantProdEmpaqP.Text);
            total1 = precio * cantprod;

            LabelPrecioPrdXCantProEmpaqPri.Text = total1.ToString();

            pesoEmpaque = decimal.Parse(TxtPesoEmpaque.Text);
            pesoProducto = decimal.Parse(TxtPesoProducto.Text);
            total2 = pesoEmpaque * pesoProducto;

            LabelPesoEmpaqXPesoProdEmpaqPri.Text = total2.ToString();


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
                CmbProductos.Items.Add(reader.GetString(1));
            }
            cn.Close();
        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void FrmGestionarEmpaque_Load(object sender, EventArgs e)
        {
            BtnRegistrarEmpaque.Enabled = false;
        }
        private void ValidarCampos()
        {
            var vc = !string.IsNullOrEmpty(TxtRefEmpaque.Text) &&
                !string.IsNullOrEmpty(CmbProductos.Text) &&
                !string.IsNullOrEmpty(TxtPesoProducto.Text) &&
                !string.IsNullOrEmpty(TxtPrecioProducto.Text) &&
                !string.IsNullOrEmpty(TxtLargoEmpaque.Text) &&
                !string.IsNullOrEmpty(TxtAnchoEmpaque.Text) &&
                !string.IsNullOrEmpty(TxtAltoEmpaque.Text) &&
                !string.IsNullOrEmpty(TxtPesoEmpaque.Text) &&
                !string.IsNullOrEmpty(TxtCantProdEmpaqP.Text) &&
                !string.IsNullOrEmpty(LabelPesoEmpaqXPesoProdEmpaqPri.Text) &&
                !string.IsNullOrEmpty(LabelPrecioPrdXCantProEmpaqPri.Text);

            BtnRegistrarEmpaque.Enabled = vc;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void BtnRegistrarEmpaque_Click(object sender, EventArgs e)
        {
            empaque = new Empaque();
            producto = new Producto();

            producto.RefProducto = TxtRefProducto.Text;
            producto.NombreProducto = CmbProductos.Text;
            producto.PesoProducto = decimal.Parse(TxtPesoProducto.Text);
            producto.PrecioProducto = decimal.Parse(TxtPrecioProducto.Text);


            empaque.RefEmpaque = TxtRefEmpaque.Text;
            empaque.Producto = producto;
            empaque.Largo = decimal.Parse(TxtLargoEmpaque.Text);
            empaque.Ancho = decimal.Parse(TxtAnchoEmpaque.Text);
            empaque.Alto = decimal.Parse(TxtAltoEmpaque.Text);
            empaque.PesoEmpaque = decimal.Parse(TxtPesoEmpaque.Text);
            empaque.CantidadProductos = int.Parse(TxtCantProdEmpaqP.Text);

            empaque.PrecioProdxCantProd = decimal.Parse(LabelPrecioPrdXCantProEmpaqPri.Text);
            empaque.PesoEmpaquexPesoProducto = decimal.Parse(LabelPesoEmpaqXPesoProdEmpaqPri.Text);
            
            string mensaje = empaqueService.GuardarEmpaque(empaque);
            MessageBox.Show(mensaje, "Guardar empaque", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void TxtRefEmpaque_TextChanged(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void CmbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(ConfigConnectionString.Cadena);
            cn.Open();
            SqlCommand cm = new SqlCommand("select * from Producto where Nombre= '" + CmbProductos.Text +"'", cn);
            SqlDataReader reader = cm.ExecuteReader();
            if (reader.Read() == true)
            {
                TxtRefProducto.Text = reader["RefProducto"].ToString();
                TxtPesoProducto.Text = reader["Peso"].ToString();
                TxtPrecioProducto.Text = reader["Precio"].ToString();
                
            }
            cn.Close();
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

        private void TxtLargoEmpaque_TextChanged(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void TxtAltoEmpaque_TextChanged(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void TxtAnchoEmpaque_TextChanged(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void TxtPesoEmpaque_TextChanged(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void TxtCantProdEmpaqP_TextChanged(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void LabelPrecioPrdXCantProEmpaqPri_Click(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void LabelPesoEmpaqXPesoProdEmpaqPri_Click(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void TxtCantProdEmpaqP_Leave(object sender, EventArgs e)
        {
            Calculos();
        }
    }
}
