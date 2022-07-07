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
            MostrarEmbalajes();
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
        private void MostrarEmbalajes()
        {
            SqlConnection cn = new SqlConnection(ConfigConnectionString.Cadena);
            SqlCommand cm = new SqlCommand("select *from Embalaje", cn);
            cn.Open();
            SqlDataReader reader = cm.ExecuteReader()
;
            while (reader.Read())
            {
                CmbReferenciaEmbalaje.Items.Add(reader.GetString(0));
                CmbReferenciaConsultaEmbalaje.Items.Add(reader.GetString(0));
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

            

            total1 = (int)vlr4/ (int)vlr1;
            total2 = (int)vlr5 / (int)vlr2;
            total3 = (int)vlr6 / (int)vlr3;

            
            totaltotal = total1 * total2 * total3;

            LabelProductoXLargo.Text = ((int)total1).ToString();
            LabelProductoXAncho.Text = ((int)total2).ToString();
            LabelProductoXAlto.Text =  ((int)total3).ToString();

            LabelTotalEmpPrimXEmbalaje.Text = ((int)totaltotal).ToString();
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
            producto.PesoProducto = double.Parse(TxtPesoProd.Text);
            producto.PrecioProducto = double.Parse(TxtPrecioProd.Text);

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
            SqlCommand cmm = new SqlCommand("select * from Empaque where RefEmpaque= '" + CmbRefEmpaqueEnEmbalaje.Text + "'", cn);
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



            //ValidarCampos();
        }

        private void TxtAltoEmbalaje_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtAltoEmbalaje_Leave(object sender, EventArgs e)
        {
            Calculos();
        }

        private void BtnConsultarEmbalaje_Click(object sender, EventArgs e)
        {
            ConsultaReponseEmbalaje respuesta;
            dataGridViewConsultaEmbalaje.DataSource = null;

            respuesta = embalajeService.ConsultarListEmbalaje(CmbReferenciaConsultaEmbalaje.Text);

            if (respuesta.Error)
            {
                MessageBox.Show(respuesta.Mensaje);
            }
            else
            {
                dataGridViewConsultaEmbalaje.DataSource = respuesta.Embalajes;
            }

        }

        private void BtnEditarEmbalaje_Click(object sender, EventArgs e)
        {
            BusquedaReponseEmbalaje respuesta;

            respuesta = embalajeService.BuscarEmbalaje(CmbReferenciaEmbalaje.Text);

            if (respuesta.Error)
            {
                MessageBox.Show(respuesta.Mensaje);
            }
            else
            {

                TxtRefEmbalaje.Text = respuesta.Embalaje.RefEmbalaje;
                CmbRefEmpaqueEnEmbalaje.Text = respuesta.Embalaje.Empaque.RefEmpaque;
                TxtLargoEmbalaje.Text = respuesta.Embalaje.Largo.ToString();
                TxtAnchoEmbalaje.Text = respuesta.Embalaje.Ancho.ToString();
                TxtAltoEmbalaje.Text = respuesta.Embalaje.Alto.ToString();
                LabelProductoXLargo.Text = respuesta.Embalaje.EmpProdXLargo.ToString();
                LabelProductoXAncho.Text = respuesta.Embalaje.EmpProdXAncho.ToString();
                LabelProductoXAlto.Text = respuesta.Embalaje.EmpProdXAlto.ToString();
                LabelTotalEmpPrimXEmbalaje.Text = respuesta.Embalaje.TotalEmpPrimarioXEmbalaje.ToString();
    
            }
        }

        private void BtnActEmbalaje_Click(object sender, EventArgs e)
        {
            
            
            producto = new Producto();
            producto.RefProducto = TxtRefProducto.Text;
            producto.NombreProducto = TxtNombProd.Text;
            producto.PesoProducto = double.Parse(TxtPesoProd.Text);
            producto.PrecioProducto = double.Parse(TxtPrecioProd.Text);

            empaque = new Empaque();
            empaque.RefEmpaque = CmbRefEmpaqueEnEmbalaje.Text;
            empaque.Producto = producto;
            empaque.Largo = decimal.Parse(TxtLargo.Text);
            empaque.Ancho = decimal.Parse(TxtAncho.Text);
            empaque.Alto = decimal.Parse(TxtAlto.Text);
            empaque.PesoEmpaque = decimal.Parse(TxtPesoEmpaque.Text);
            empaque.CantidadProductos = int.Parse(TxtCantProd.Text);
            empaque.PrecioProdxCantProd = decimal.Parse(TxtPrecioProdX.Text);
            ; empaque.PesoEmpaquexPesoProducto = decimal.Parse(TxtPesoEmpaqueX.Text);

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

            string mensaje = embalajeService.ModificarEmbalaje(embalaje, TxtRefEmbalaje.Text);
            MessageBox.Show(mensaje, "Modificar embalaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnEliminarEmbalaje_Click(object sender, EventArgs e)
        {
            string mensaje = embalajeService.EliminarEmbalaje(CmbReferenciaEmbalaje.Text);
            MessageBox.Show(mensaje, "Eliminar embalaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
