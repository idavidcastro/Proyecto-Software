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
    public partial class FrmOrden : Form
    {
        Producto producto;
        Empaque empaque;
        Embalaje embalaje;
        Estibado estibado;
        Contenedor contenedor;
        Orden orden;
        OrdenService ordenService;
        decimal acum = 0;
        public FrmOrden()
        {
            InitializeComponent();
            ordenService = new OrdenService(ConfigConnectionString.Cadena);
            MostrarContenedores();
            MostrarOrdenes();
            DataOrdenes.Columns.Add("RefOrden", "RefOrden");
            DataOrdenes.Columns.Add("RefContenedor", "RefContenedor");
            DataOrdenes.Columns.Add("ValorCarga", "ValorCarga");
        }
        private void MostrarContenedores()
        {
            SqlConnection cn = new SqlConnection(ConfigConnectionString.Cadena);
            SqlCommand cm = new SqlCommand("select *from Contenedor", cn);
            cn.Open();
            SqlDataReader reader = cm.ExecuteReader()
;
            while (reader.Read())
            {
                CmbRefContenedorEnFrmOrden.Items.Add(reader.GetString(0));

            }
            cn.Close();
        }
        private void MostrarOrdenes()
        {
            SqlConnection cn = new SqlConnection(ConfigConnectionString.Cadena);
            SqlCommand cm = new SqlCommand("select *from Orden", cn);
            cn.Open();
            SqlDataReader reader = cm.ExecuteReader()
;           
            while (reader.Read())
            {
                CmbRefOrdenConsultar.Items.Add(reader.GetString(0));
                acum += decimal.Parse(reader.GetString(2));
            }
            LabelValorTotalTodasOrdenes.Text = acum.ToString();

            cn.Close();
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

        private void BtnRegOrdenPanel_Click(object sender, EventArgs e)
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
            estibado.RefEstibado = TxtRefEstibadoEnContenedor.Text;
            estibado.Embalaje = embalaje;
            estibado.LargoEstibado = decimal.Parse(TxtLargoEstibado.Text);
            estibado.AnchoEstibado = decimal.Parse(TxtAnchoEstibado.Text);
            estibado.AltoEstibado = decimal.Parse(TxtAltoEstibado.Text);
            estibado.EmbalajeXLargo = decimal.Parse(TxtEmbalajeXLargo.Text);
            estibado.EmbalajeXAncho = decimal.Parse(TxtEmbalajeXAncho.Text);
            estibado.EmbalajeXAlto = decimal.Parse(TxtEmbalajeXAlto.Text);
            estibado.TotalEmbalajesXEstibas = decimal.Parse(TxtTotalEmbalajesXEstibas.Text);

            contenedor = new Contenedor();
            contenedor.RefContenedor = CmbRefContenedorEnFrmOrden.Text;
            contenedor.Estibado = estibado;
            contenedor.TipoContenedor = TxtTipoContenedor.Text;
            contenedor.LargoContenedor = decimal.Parse(TxtLargoContenedor.Text);
            contenedor.AnchoContenedor = decimal.Parse(TxtAnchoContenedor.Text);
            contenedor.EstibadoXLargo = decimal.Parse(TxtEstibadoXLargo.Text);
            contenedor.EstibadoXAncho = decimal.Parse(TxtEstibadoXAncho.Text);
            contenedor.TotalEstibasXContenedor = decimal.Parse(TxtTotalEstibasXContenedor.Text);
            contenedor.NumEstibasXProducto = int.Parse(TxtNumEstibasXProducto.Text);
            contenedor.TotalEmbalajesEnContenedor = int.Parse(TxtTotalEmbalEnContenedor.Text);

            orden = new Orden();
            orden.RefOrden = TxtRefOrden.Text;
            orden.Contenedor = contenedor;

            orden.ValorCarga = decimal.Parse(TxtTotalEmbalEnContenedor.Text) * decimal.Parse(TxtTotalEmpPrimXEmbalaje.Text) * decimal.Parse(TxtPrecioProdX.Text);

            string mensaje = ordenService.GuardarOrden(orden);
            MessageBox.Show(mensaje, "Guardar orden", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (TxtTipoContenedor.Text == "Terrestre (40 pies)")
            {
                int valorestiba = 85000;
                int estibasxcontenedor = int.Parse(TxtTotalEstibasXContenedor.Text);
                TxtAlquilerContenedor.Text = "2850000";
                TxtAlquilerEstiba.Text = (estibasxcontenedor * valorestiba).ToString();
            }
            else if (TxtTipoContenedor.Text == "Aereo")
            {
                int valorestiba = 85000;
                int estibasxcontenedor = int.Parse(TxtTotalEstibasXContenedor.Text);
                TxtAlquilerContenedor.Text = (6 * 850000).ToString();
                TxtAlquilerEstiba.Text = (estibasxcontenedor * valorestiba).ToString();
            }

            int alquilerestivas, alquilercontenedor, valordetodaslasordenes, valorcargaCOP;
            double valordolar;

            alquilerestivas = int.Parse(TxtAlquilerEstiba.Text);
            alquilercontenedor = int.Parse(TxtAlquilerContenedor.Text);
            valordetodaslasordenes = int.Parse(LabelValorTotalTodasOrdenes.Text);

            LabelAlquilerEstibas.Text = TxtAlquilerEstiba.Text;
            LabelAlquilerContenedores.Text = TxtAlquilerContenedor.Text;
            LabelValorTotalCargaCOP.Text = (valordetodaslasordenes + alquilerestivas + alquilercontenedor).ToString();

            valorcargaCOP = int.Parse(LabelValorTotalCargaCOP.Text);
            valordolar = 0.00023;

            LabelValorTotalCargaUSD.Text= (valorcargaCOP * valordolar).ToString();

        }

        private void CmbRefContenedorEnFrmOrden_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(ConfigConnectionString.Cadena);
            cn.Open();

            SqlCommand cmmmm = new SqlCommand("select * from Contenedor where RefContenedor= '" + CmbRefContenedorEnFrmOrden.Text + "'", cn);
            SqlDataReader readerrrr = cmmmm.ExecuteReader();
            if (readerrrr.Read() == true)
            {
                TxtRefEstibadoEnContenedor.Text = readerrrr["RefEstibado"].ToString();
                TxtTipoContenedor.Text = readerrrr["TipoContenedor"].ToString();
                TxtLargoContenedor.Text = readerrrr["Largo"].ToString();
                TxtAnchoContenedor.Text = readerrrr["Ancho"].ToString();
                TxtEstibadoXLargo.Text = readerrrr["EstibadoXLargo"].ToString();
                TxtEstibadoXAncho.Text = readerrrr["EstibadoXAncho"].ToString();
                TxtTotalEstibasXContenedor.Text = readerrrr["TotalEstibasXContenedor"].ToString();
                TxtNumEstibasXProducto.Text = readerrrr["NumEstibasXProducto"].ToString();
                TxtTotalEmbalEnContenedor.Text = readerrrr["TotalEmbalajesEnContenedor"].ToString();
            }


            SqlCommand cmmm = new SqlCommand("select * from Estibado where RefEstibado= '" + TxtRefEstibadoEnContenedor.Text + "'", cn);
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

        private void BtnRegistrarOrden_Click(object sender, EventArgs e)
        {
            if (PanelRegistrarOrden.Visible == true)
            {
                PanelRegistrarOrden.Visible = false;
            }
            else
            {
                PanelRegistrarOrden.Visible = true;
            }
        }

        private void BtnConsultarOrdenPanel_Click(object sender, EventArgs e)
        {
            /*
            ConsultaReponseOrden respuesta;
            DataOrdenes.DataSource = null;

            respuesta = ordenService.ConsultarListOrden(CmbRefOrdenConsultar.Text);

            if (respuesta.Error)
            {
                MessageBox.Show(respuesta.Mensaje);
            }
            else
            {
                DataOrdenes.DataSource = respuesta.Ordenes;
            }
            */

            SqlConnection cn = new SqlConnection(ConfigConnectionString.Cadena);
            cn.Open();
            
            SqlCommand cmmmm = new SqlCommand("select * from Orden where RefOrden= '" + CmbRefOrdenConsultar.Text + "'", cn);
            SqlDataReader readerrrr = cmmmm.ExecuteReader();
            if (readerrrr.Read() == true)
            {
                
                DataOrdenes.Rows.Add(readerrrr["RefOrden"].ToString(), readerrrr["RefContenedor"].ToString(), readerrrr["ValorCarga"].ToString());
                cn.Close();
            }
        }

        private void PanelConsultarOrden_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
