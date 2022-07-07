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
    public partial class FrmGestionarContenedor : Form
    {
        Producto producto;
        Empaque empaque;
        Embalaje embalaje;
        Estibado estibado;
        Contenedor contenedor;
        ContenedorService contenedorService;

        public FrmGestionarContenedor()
        {
            InitializeComponent();
            contenedorService = new ContenedorService(ConfigConnectionString.Cadena);
            MostrarEstibas();
        }
        private void MostrarEstibas()
        {
            SqlConnection cn = new SqlConnection(ConfigConnectionString.Cadena);
            SqlCommand cm = new SqlCommand("select *from Estibado", cn);
            cn.Open();
            SqlDataReader reader = cm.ExecuteReader()
;
            while (reader.Read())
            {
                CmbRefEstibadoEnContenedor.Items.Add(reader.GetString(0));
            }
            cn.Close();
        }
        private void Calculos()
        {

            decimal vlr1, vlr2, vlr3, vlr4, vlr5, vlr6, total1, total2, total3, totaltotal;

            vlr1 = decimal.Parse(TxtLargoEstibado.Text);
            vlr2 = decimal.Parse(TxtAnchoEstibado.Text);


            vlr3 = decimal.Parse(TxtLargoContenedor.Text);
            vlr4 = decimal.Parse(TxtAnchoContenedor.Text);

            vlr5 = decimal.Parse(TxtTotalEmbalajesXEstibas.Text);
            vlr6 = decimal.Parse(TxtNumEstibasXProducto.Text);


            total1 = vlr3 / vlr1;
            total2 = vlr4 / vlr2;

            totaltotal = (int)total1 * (int)total2;
            total3 = (int)vlr5 * (int)vlr6;


            LabelEstibadoXLargo.Text = ((int)total1).ToString();
            LabelEstibadoXAncho.Text = ((int)total2).ToString();
            LabelTotalEstibasXContenedor.Text = ((int)totaltotal).ToString();
            LabelTotalEmbalEnContenedor.Text = ((int)total3).ToString();
        }

        private void BtnRegistrarContenedor_Click(object sender, EventArgs e)
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
            empaque.PesoEmpaquexPesoProducto = decimal.Parse(TxtPesoEmpaqueX.Text);

            embalaje = new Embalaje();
            embalaje.RefEmbalaje = TxtRefEmbalajeEnEstibado.Text;
            embalaje.Empaque = empaque;
            embalaje.Largo = decimal.Parse(TxtLargoEmbalaje.Text);
            embalaje.Ancho = decimal.Parse(TxtAnchoEmbalaje.Text);
            embalaje.Alto = decimal.Parse(TxtAltoEmbalaje.Text);
            embalaje.EmpProdXLargo = decimal.Parse(TxtProductoXLargo.Text);
            embalaje.EmpProdXAncho = decimal.Parse(TxtProductoXAncho.Text);
            embalaje.EmpProdXAlto = decimal.Parse(TxtProductoXAlto.Text);
            embalaje.TotalEmpPrimarioXEmbalaje = decimal.Parse(TxtTotalEmpPrimXEmbalaje.Text);

            estibado = new Estibado();
            estibado.RefEstibado = CmbRefEstibadoEnContenedor.Text;
            estibado.Embalaje = embalaje;
            estibado.LargoEstibado = decimal.Parse(TxtLargoEstibado.Text);
            estibado.AnchoEstibado = decimal.Parse(TxtAnchoEstibado.Text);
            estibado.AltoEstibado = decimal.Parse(TxtAltoEstibado.Text);
            estibado.EmbalajeXLargo = decimal.Parse(TxtEmbalajeXLargo.Text);
            estibado.EmbalajeXAncho = decimal.Parse(TxtEmbalajeXAncho.Text);
            estibado.EmbalajeXAlto = decimal.Parse(TxtEmbalajeXAlto.Text);
            estibado.TotalEmbalajesXEstibas = decimal.Parse(TxtTotalEmbalajesXEstibas.Text);

            contenedor = new Contenedor();
            contenedor.RefContenedor = TxtRefContenedor.Text;
            contenedor.Estibado = estibado;
            contenedor.TipoContenedor = CmbTipoContenedor.Text;
            contenedor.LargoContenedor = decimal.Parse(TxtLargoContenedor.Text);
            contenedor.AnchoContenedor = decimal.Parse(TxtAnchoContenedor.Text);
            contenedor.EstibadoXLargo = decimal.Parse(LabelEstibadoXLargo.Text);
            contenedor.EstibadoXAncho = decimal.Parse(LabelEstibadoXAncho.Text);
            contenedor.TotalEstibasXContenedor = decimal.Parse(LabelTotalEstibasXContenedor.Text);
            contenedor.NumEstibasXProducto = int.Parse(TxtNumEstibasXProducto.Text);
            contenedor.TotalEmbalajesEnContenedor = int.Parse(LabelTotalEmbalEnContenedor.Text);

            string mensaje = contenedorService.GuardarContenedor(contenedor);
            MessageBox.Show(mensaje, "Guardar contenedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CmbRefEstibadoEnContenedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(ConfigConnectionString.Cadena);
            cn.Open();

            SqlCommand cmmm = new SqlCommand("select * from Estibado where RefEstibado= '" + CmbRefEstibadoEnContenedor.Text + "'", cn);
            SqlDataReader readerrr = cmmm.ExecuteReader();
            if (readerrr.Read() == true)
            {
                TxtRefEmbalajeEnEstibado.Text = readerrr["RefEmbalaje"].ToString();
                TxtLargoEstibado.Text = readerrr["Largo"].ToString();
                TxtAnchoEstibado.Text = readerrr["Ancho"].ToString();
                TxtAltoEstibado.Text = readerrr["Alto"].ToString();
                TxtEmbalajeXLargo.Text = readerrr["EmbalajeXLargo"].ToString();
                TxtEmbalajeXAncho.Text = readerrr["EmbalajeXAncho"].ToString();
                TxtEmbalajeXAlto.Text = readerrr["EmbalajeXAlto"].ToString();
                TxtTotalEmbalajesXEstibas.Text = readerrr["TotalEmbalajesXEstibas"].ToString();

            }


            SqlCommand cm = new SqlCommand("select * from Embalaje where RefEmbalaje= '" + TxtRefEmbalajeEnEstibado.Text + "'", cn);
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

        private void TxtNumEstibasXProducto_Leave(object sender, EventArgs e)
        {
            Calculos();
        }

        private void CmbTipoContenedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbTipoContenedor.Text == "Terrestre (40 pies)")
            {
                TxtLargoContenedor.Text = "1166,1";
                TxtAnchoContenedor.Text = "228";
            }
            else if (CmbTipoContenedor.Text == "Aereo")
            {
                TxtLargoContenedor.Text = "234";
                TxtAnchoContenedor.Text = "232";
            }
        }

        private void FrmGestionarContenedor_Load(object sender, EventArgs e)
        {

        }
    }
}
