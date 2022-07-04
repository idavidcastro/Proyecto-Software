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
    public partial class FrmGestionarEmbalaje : Form
    {
        Empaque empaque;
        Producto producto;
        Embalaje embalaje;
        EmbalajeService embalajeService;
        public FrmGestionarEmbalaje()
        {
            InitializeComponent();
            MostrarEmpaque();
            embalajeService = new EmbalajeService(ConfigConnectionString.Cadena);
        }
        private void MostrarEmpaque()
        {
            SqlConnection cn = new SqlConnection(ConfigConnectionString.Cadena);
            SqlCommand cm = new SqlCommand("select *from Empaque", cn);
            cn.Open();
            SqlDataReader reader = cm.ExecuteReader()
;
            while (reader.Read())
            {
                CmbRefEmpaqueEnEmbalaje.Items.Add(reader.GetString(0));
            }
            cn.Close();
        }
        private void Calculos()
        {
            decimal vlr1, vlr2, vlr3, vlr4, vlr5, vlr6, total1, total2, total3, totaltotal;

            vlr1 = decimal.Parse(TxtLargo.Text);
            vlr2 = decimal.Parse(TxtAncho.Text);
            vlr3 = decimal.Parse(TxtAlto.Text);

            vlr4 = decimal.Parse(TxtLargoEmbalaje.Text);
            vlr5 = decimal.Parse(TxtAnchoEmbalaje.Text);
            vlr6 = decimal.Parse(TxtAltoEmbalaje.Text);

            total1 = vlr1 * vlr4;
            total2 = vlr2 * vlr5;
            total3 = vlr3 * vlr6;

            totaltotal = total1 * total2 * total3;

            LabelProductoXLargo.Text = total1.ToString();
            LabelProductoXAncho.Text = total2.ToString();
            LabelProductoXAlto.Text = total3.ToString();

            LabelTotalEmpPrimXEmbalaje.Text = totaltotal.ToString();
        }

        private void FrmGestionarEmbalaje_Load(object sender, EventArgs e)
        {
            //BtnRegistrarEmbalaje.Enabled = false;
        }

        private void BtnRegistrarEmbalaje_Click(object sender, EventArgs e)
        {
            producto = new Producto();
            producto.RefProducto = TxtRefProducto.Text;
            producto.NombreProducto = TxtNombProd.Text;
            producto.PesoProducto = decimal.Parse(TxtPesoProd.Text);
            producto.PrecioProducto = decimal.Parse(TxtPrecioProd.Text);

            empaque = new Empaque();
            empaque.RefEmpaque = CmbRefEmpaqueEnEmbalaje.Text;
            empaque.Producto = producto;
            empaque.Largo = decimal.Parse(TxtLargo.Text);
            empaque.Ancho = decimal.Parse(TxtAncho.Text);
            empaque.Alto = decimal.Parse(TxtAlto.Text);
            empaque.PesoEmpaque = decimal.Parse(TxtPesoEmpaque.Text);
            empaque.CantidadProductos = int.Parse(TxtCantProd.Text);
            empaque.PrecioProdxCantProd = decimal.Parse(TxtPrecioProdX.Text);
;           empaque.PesoEmpaquexPesoProducto = decimal.Parse(TxtPesoEmpaqueX.Text);

            embalaje = new Embalaje();
            embalaje.RefEmbalaje = TxtRefEmbalaje.Text;
            embalaje.Empaque = empaque;
            embalaje.Largo = decimal.Parse(TxtLargoEmbalaje.Text);
            embalaje.Ancho = decimal.Parse(TxtAnchoEmbalaje.Text);
            embalaje.Alto = decimal.Parse(TxtAltoEmbalaje.Text);
            embalaje.EmpProdXLargo = decimal.Parse(LabelProductoXLargo.Text);
            embalaje.EmpProdXAncho = decimal.Parse(LabelProductoXAncho.Text);
            embalaje.EmpProdXAlto = decimal.Parse(LabelProductoXAlto.Text);
            embalaje.TotalEmpPrimarioXEmbalaje = decimal.Parse(LabelTotalEmpPrimXEmbalaje.Text);

            
            string mensaje = embalajeService.GuardarEmbalaje(embalaje);
            MessageBox.Show(mensaje, "Guardar embalaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CmbRefEmpaqueEnEmbalaje_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(ConfigConnectionString.Cadena);
            cn.Open();
            SqlCommand cm = new SqlCommand("select * from Empaque where RefEmpaque= '" + CmbRefEmpaqueEnEmbalaje.Text + "'", cn);
            SqlDataReader reader = cm.ExecuteReader();
            if (reader.Read() == true)
            {
                TxtRefProducto.Text = reader["RefProducto"].ToString();
                TxtNombProd.Text = reader["Producto"].ToString();
                TxtPesoProd.Text = reader["PesoProducto"].ToString();
                TxtPrecioProd.Text = reader["PrecioProducto"].ToString();
                TxtLargo.Text = reader["Largo"].ToString();
                TxtAncho.Text = reader["Ancho"].ToString();
                TxtAlto.Text = reader["Alto"].ToString();
                TxtPesoEmpaque.Text = reader["PesoEmpaque"].ToString();
                TxtCantProd.Text = reader["CantProductos"].ToString();
                TxtPrecioProdX.Text = reader["PrecioProdXCantProdEmpaque"].ToString();
                TxtPesoEmpaqueX.Text = reader["PesoEmpaqXPesoProducto"].ToString();

            }
            cn.Close();



            //ValidarCampos();
        }

        private void TxtAltoEmbalaje_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtAltoEmbalaje_Leave(object sender, EventArgs e)
        {
            Calculos();
        }
    }
}
