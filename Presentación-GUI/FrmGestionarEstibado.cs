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
    public partial class FrmGestionarEstibado : Form
    {
        Producto producto;
        Empaque empaque;
        Embalaje embalaje;
        Estibado estibado;
        EstibadoService estibadoService;
        public FrmGestionarEstibado()
        {
            InitializeComponent();
            estibadoService = new EstibadoService(ConfigConnectionString.Cadena);
            MostrarEmbalaje();
        }
        private void MostrarEmbalaje()
        {
            SqlConnection cn = new SqlConnection(ConfigConnectionString.Cadena);
            SqlCommand cm = new SqlCommand("select *from Embalaje", cn);
            cn.Open();
            SqlDataReader reader = cm.ExecuteReader()
;
            while (reader.Read())
            {
                CmbRefEmbalajeEnEstibado.Items.Add(reader.GetString(0));
            }
            cn.Close();
        }
        private void Calculos()
        {

            decimal vlr1, vlr2, vlr3, vlr4, vlr5, vlr6, total1, total2, total3, totaltotal;

            vlr1 = decimal.Parse(TxtLargoEmbalaje.Text);
            vlr2 = decimal.Parse(TxtAnchoEmbalaje.Text);
            vlr3 = decimal.Parse(TxtAltoEmbalaje.Text);

            vlr4 = decimal.Parse(TxtLargoEstibado.Text);
            vlr5 = decimal.Parse(TxtAnchoEstibado.Text);
            vlr6 = decimal.Parse(TxtAltoEstibado.Text);

            total1 = (int)vlr4 / (int)vlr1;
            total2 = (int)vlr5 / (int)vlr2;
            total3 = (int)vlr6 / (int)vlr3;

            totaltotal = total1 * total2 * total3;


            LabelEmbalajeXLargo.Text = ((int)total1).ToString();
            LabelEmbalajeXAncho.Text = ((int)total2).ToString();
            LabelEmbalajeXAlto.Text = ((int)total3).ToString();

            LabelTotalEmbalajesXEstibas.Text = ((int)totaltotal).ToString();
        }

        private void BtnRegistrarEstibado_Click(object sender, EventArgs e)
        {
            producto = new Producto();
            producto.RefProducto = TxtRefProducto.Text;
            producto.NombreProducto = TxtNombProd.Text;
            producto.PesoProducto = double.Parse(TxtPesoProd.Text);
            producto.PrecioProducto = double.Parse(TxtPrecioProd.Text);

            empaque = new Empaque();
            empaque.RefEmpaque = TxtEmpaqueEnEmbalaje.Text;
            empaque.Producto = producto;
            empaque.Largo = decimal.Parse(TxtLargo.Text);
            empaque.Ancho = decimal.Parse(TxtAncho.Text);
            empaque.Alto = decimal.Parse(TxtAlto.Text);
            empaque.PesoEmpaque = decimal.Parse(TxtPesoEmpaque.Text);
            empaque.CantidadProductos = int.Parse(TxtCantProd.Text);
            empaque.PrecioProdxCantProd = decimal.Parse(TxtPrecioProdX.Text);
            ; empaque.PesoEmpaquexPesoProducto = decimal.Parse(TxtPesoEmpaqueX.Text);

            embalaje = new Embalaje();
            embalaje.RefEmbalaje = CmbRefEmbalajeEnEstibado.Text;
            embalaje.Empaque = empaque;
            embalaje.Largo = decimal.Parse(TxtLargoEmbalaje.Text);
            embalaje.Ancho = decimal.Parse(TxtAnchoEmbalaje.Text);
            embalaje.Alto = decimal.Parse(TxtAltoEmbalaje.Text);
            embalaje.EmpProdXLargo = decimal.Parse(TxtProductoXLargo.Text);
            embalaje.EmpProdXAncho = decimal.Parse(TxtProductoXAncho.Text);
            embalaje.EmpProdXAlto = decimal.Parse(TxtProductoXAlto.Text);
            embalaje.TotalEmpPrimarioXEmbalaje = decimal.Parse(TxtTotalEmpPrimXEmbalaje.Text);

            estibado = new Estibado();
            estibado.RefEstibado = TxtRefEstibado.Text;
            estibado.Embalaje = embalaje;
            estibado.LargoEstibado = decimal.Parse(TxtLargoEstibado.Text);
            estibado.AnchoEstibado = decimal.Parse(TxtAnchoEstibado.Text);
            estibado.AltoEstibado = decimal.Parse(TxtAltoEstibado.Text);
            estibado.EmbalajeXLargo = decimal.Parse(LabelEmbalajeXLargo.Text);
            estibado.EmbalajeXAncho = decimal.Parse(LabelEmbalajeXAncho.Text);
            estibado.EmbalajeXAlto = decimal.Parse(LabelEmbalajeXAlto.Text);
            estibado.TotalEmbalajesXEstibas = decimal.Parse(LabelTotalEmbalajesXEstibas.Text);

            string mensaje = estibadoService.GuardarEstibado(estibado);
            MessageBox.Show(mensaje, "Guardar estibado", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void TxtAltoEmbalaje_TextChanged(object sender, EventArgs e)
        {

        }

        private void CmbRefEmbalajeEnEstibado_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(ConfigConnectionString.Cadena);
            cn.Open();

            SqlCommand cm = new SqlCommand("select * from Embalaje where RefEmbalaje= '" + CmbRefEmbalajeEnEstibado.Text + "'", cn);
            SqlDataReader reader = cm.ExecuteReader();
            if (reader.Read() == true)
            {
                TxtEmpaqueEnEmbalaje.Text = reader["RefEmpaque"].ToString();
                TxtLargoEmbalaje.Text = reader["Largo"].ToString();
                TxtAnchoEmbalaje.Text = reader["Ancho"].ToString();
                TxtAltoEmbalaje.Text = reader["Alto"].ToString();
                TxtProductoXLargo.Text = reader["EmpXLargo"].ToString();
                TxtProductoXAncho.Text = reader["EmpXAncho"].ToString();
                TxtProductoXAlto.Text = reader["EmpXAlto"].ToString();
                TxtTotalEmpPrimXEmbalaje.Text = reader["TotalEmpaqueXEmbalaje"].ToString();

            }

            SqlCommand cmm = new SqlCommand("select * from Empaque where RefEmpaque= '" + TxtEmpaqueEnEmbalaje.Text + "'", cn);
            SqlDataReader readerr = cmm.ExecuteReader();
            if (readerr.Read() == true)
            {
                TxtRefProducto.Text = readerr["RefProducto"].ToString();
                TxtNombProd.Text = readerr["Producto"].ToString();
                TxtPesoProd.Text = readerr["PesoProducto"].ToString();
                TxtPrecioProd.Text = readerr["PrecioProducto"].ToString();
                TxtLargo.Text = readerr["Largo"].ToString();
                TxtAncho.Text = readerr["Ancho"].ToString();
                TxtAlto.Text = readerr["Alto"].ToString();
                TxtPesoEmpaque.Text = readerr["PesoEmpaque"].ToString();
                TxtCantProd.Text = readerr["CantProductos"].ToString();
                TxtPrecioProdX.Text = readerr["PrecioProdXCantProdEmpaque"].ToString();
                TxtPesoEmpaqueX.Text = readerr["PesoEmpaqXPesoProducto"].ToString();

            }
            cn.Close();
        }

        private void TxtAltoEstibado_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void TxtAltoEstibado_Leave(object sender, EventArgs e)
        {
            Calculos();
        }
    }
}
