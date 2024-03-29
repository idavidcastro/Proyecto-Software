﻿using Entidad;
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
            MostrarEmpaques();

            
        }

        private void Calculos()
        {
            decimal precio, cantprod, total1, pesoEmpaque, pesoProducto, cantProd, total2;
            precio = decimal.Parse(TxtPrecioProducto.Text);
            cantprod = decimal.Parse(TxtCantProdEmpaqP.Text);
            total1 = precio * cantprod;

            LabelPrecioPrdXCantProEmpaqPri.Text = ((int)total1).ToString();

            pesoEmpaque = decimal.Parse(TxtPesoEmpaque.Text);
            pesoProducto = decimal.Parse(TxtPesoProducto.Text);
            cantProd = int.Parse(TxtCantProdEmpaqP.Text);

            total2 =  pesoProducto*cantProd+pesoEmpaque;

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
        private void MostrarEmpaques()
        {
            SqlConnection cn = new SqlConnection(ConfigConnectionString.Cadena);
            SqlCommand cm = new SqlCommand("select *from Empaque", cn);
            cn.Open();
            SqlDataReader reader = cm.ExecuteReader()
;
            while (reader.Read())
            {
                CmbReferenciaEmpaque.Items.Add(reader.GetString(0));
                CmbReferenciaConsultaEmpaque.Items.Add(reader.GetString(0));
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
            producto.PesoProducto = double.Parse(TxtPesoProducto.Text);
            producto.PrecioProducto = double.Parse(TxtPrecioProducto.Text);


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

        private void BtnEditarEmpaque_Click(object sender, EventArgs e)
        {
            BusquedaReponseEmpaque respuesta;

            respuesta = empaqueService.BuscarEmpaque(CmbReferenciaEmpaque.Text);

            if (respuesta.Error)
            {
                MessageBox.Show(respuesta.Mensaje);
            }
            else
            {
                TxtRefEmpaque.Text = respuesta.Empaque.RefEmpaque;
                CmbProductos.Text = respuesta.Empaque.Producto.NombreProducto;
                TxtPesoProducto.Text = respuesta.Empaque.Producto.PesoProducto.ToString();
                TxtPrecioProducto.Text = respuesta.Empaque.Producto.PrecioProducto.ToString();
                TxtLargoEmpaque.Text = respuesta.Empaque.Largo.ToString();
                TxtAnchoEmpaque.Text = respuesta.Empaque.Ancho.ToString();
                TxtAltoEmpaque.Text = respuesta.Empaque.Alto.ToString();
                TxtPesoEmpaque.Text = respuesta.Empaque.PesoEmpaque.ToString();
                TxtCantProdEmpaqP.Text = respuesta.Empaque.CantidadProductos.ToString();
                LabelPrecioPrdXCantProEmpaqPri.Text = respuesta.Empaque.PrecioProdxCantProd.ToString();
                LabelPesoEmpaqXPesoProdEmpaqPri.Text = respuesta.Empaque.PesoEmpaquexPesoProducto.ToString();

            }
        }

        private void BtnConsultarEmpaque_Click(object sender, EventArgs e)
        {
            ConsultaReponseEmpaque respuesta;
            dataGridViewConsultaEmpaque.DataSource = null;

            respuesta = empaqueService.ConsultarListEmpaques(CmbReferenciaConsultaEmpaque.Text);

            if (respuesta.Error)
            {
                MessageBox.Show(respuesta.Mensaje);
            }
            else
            {
                dataGridViewConsultaEmpaque.DataSource = respuesta.Empaques;
            }
        }

        private void BtnEliminarEmpaque_Click(object sender, EventArgs e)
        {
            string mensaje = empaqueService.EliminarEmpaque(CmbReferenciaEmpaque.Text);
            MessageBox.Show(mensaje, "Eliminar empaque", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnActEmpaque_Click(object sender, EventArgs e)
        {
            
            //
            empaque = new Empaque();
            producto = new Producto();

            producto.RefProducto = TxtRefProducto.Text;
            producto.NombreProducto = CmbProductos.Text;
            producto.PesoProducto = double.Parse(TxtPesoProducto.Text);
            producto.PrecioProducto = double.Parse(TxtPrecioProducto.Text);


            empaque.RefEmpaque = TxtRefEmpaque.Text;
            empaque.Producto = producto;
            empaque.Largo = decimal.Parse(TxtLargoEmpaque.Text);
            empaque.Ancho = decimal.Parse(TxtAnchoEmpaque.Text);
            empaque.Alto = decimal.Parse(TxtAltoEmpaque.Text);
            empaque.PesoEmpaque = decimal.Parse(TxtPesoEmpaque.Text);
            empaque.CantidadProductos = int.Parse(TxtCantProdEmpaqP.Text);

            empaque.PrecioProdxCantProd = decimal.Parse(LabelPrecioPrdXCantProEmpaqPri.Text);
            empaque.PesoEmpaquexPesoProducto = decimal.Parse(LabelPesoEmpaqXPesoProdEmpaqPri.Text);

            string mensaje = empaqueService.ModificarEmpaque(empaque, TxtRefEmpaque.Text);
            MessageBox.Show(mensaje, "Modificar empaque", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
