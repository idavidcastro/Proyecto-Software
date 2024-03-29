﻿
namespace Presentación_GUI
{
    partial class FrmGestiones
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGestiones));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnVolverGestiones = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnGestionarContenedor = new System.Windows.Forms.Button();
            this.BtnGestionarEstibado = new System.Windows.Forms.Button();
            this.BtnProductoStock = new System.Windows.Forms.Button();
            this.BtnGestionarEmbalaje = new System.Windows.Forms.Button();
            this.BtnGestionarEmpaque = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PanelBlancoGestiones = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PanelBlancoGestiones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(115)))), ((int)(((byte)(171)))));
            this.panel1.Controls.Add(this.BtnVolverGestiones);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(345, 833);
            this.panel1.TabIndex = 0;
            // 
            // BtnVolverGestiones
            // 
            this.BtnVolverGestiones.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnVolverGestiones.Location = new System.Drawing.Point(15, 746);
            this.BtnVolverGestiones.Name = "BtnVolverGestiones";
            this.BtnVolverGestiones.Size = new System.Drawing.Size(314, 42);
            this.BtnVolverGestiones.TabIndex = 6;
            this.BtnVolverGestiones.Text = "Volver";
            this.BtnVolverGestiones.UseVisualStyleBackColor = true;
            this.BtnVolverGestiones.Click += new System.EventHandler(this.BtnVolverGestiones_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnGestionarContenedor);
            this.panel2.Controls.Add(this.BtnGestionarEstibado);
            this.panel2.Controls.Add(this.BtnProductoStock);
            this.panel2.Controls.Add(this.BtnGestionarEmbalaje);
            this.panel2.Controls.Add(this.BtnGestionarEmpaque);
            this.panel2.Location = new System.Drawing.Point(12, 159);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(317, 341);
            this.panel2.TabIndex = 0;
            // 
            // BtnGestionarContenedor
            // 
            this.BtnGestionarContenedor.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGestionarContenedor.Location = new System.Drawing.Point(3, 227);
            this.BtnGestionarContenedor.Name = "BtnGestionarContenedor";
            this.BtnGestionarContenedor.Size = new System.Drawing.Size(311, 42);
            this.BtnGestionarContenedor.TabIndex = 5;
            this.BtnGestionarContenedor.Text = "Gestionar Contenedor";
            this.BtnGestionarContenedor.UseVisualStyleBackColor = true;
            this.BtnGestionarContenedor.Click += new System.EventHandler(this.BtnGestionarContenedor_Click);
            // 
            // BtnGestionarEstibado
            // 
            this.BtnGestionarEstibado.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGestionarEstibado.Location = new System.Drawing.Point(3, 179);
            this.BtnGestionarEstibado.Name = "BtnGestionarEstibado";
            this.BtnGestionarEstibado.Size = new System.Drawing.Size(311, 42);
            this.BtnGestionarEstibado.TabIndex = 4;
            this.BtnGestionarEstibado.Text = "Gestionar Estibado";
            this.BtnGestionarEstibado.UseVisualStyleBackColor = true;
            this.BtnGestionarEstibado.Click += new System.EventHandler(this.BtnGestionarEstibado_Click);
            // 
            // BtnProductoStock
            // 
            this.BtnProductoStock.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnProductoStock.Location = new System.Drawing.Point(3, 35);
            this.BtnProductoStock.Name = "BtnProductoStock";
            this.BtnProductoStock.Size = new System.Drawing.Size(311, 42);
            this.BtnProductoStock.TabIndex = 3;
            this.BtnProductoStock.Text = "Nuevo Producto - STOCK";
            this.BtnProductoStock.UseVisualStyleBackColor = true;
            this.BtnProductoStock.Click += new System.EventHandler(this.BtnProductoStock_Click);
            // 
            // BtnGestionarEmbalaje
            // 
            this.BtnGestionarEmbalaje.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGestionarEmbalaje.Location = new System.Drawing.Point(3, 131);
            this.BtnGestionarEmbalaje.Name = "BtnGestionarEmbalaje";
            this.BtnGestionarEmbalaje.Size = new System.Drawing.Size(311, 42);
            this.BtnGestionarEmbalaje.TabIndex = 2;
            this.BtnGestionarEmbalaje.Text = "Gestionar Embalaje";
            this.BtnGestionarEmbalaje.UseVisualStyleBackColor = true;
            this.BtnGestionarEmbalaje.Click += new System.EventHandler(this.BtnGestionarEmbalaje_Click);
            // 
            // BtnGestionarEmpaque
            // 
            this.BtnGestionarEmpaque.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGestionarEmpaque.Location = new System.Drawing.Point(3, 83);
            this.BtnGestionarEmpaque.Name = "BtnGestionarEmpaque";
            this.BtnGestionarEmpaque.Size = new System.Drawing.Size(311, 42);
            this.BtnGestionarEmpaque.TabIndex = 1;
            this.BtnGestionarEmpaque.Text = "Gestionar Empaque";
            this.BtnGestionarEmpaque.UseVisualStyleBackColor = true;
            this.BtnGestionarEmpaque.Click += new System.EventHandler(this.BtnGestionarEmpaque_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Presentación_GUI.Properties.Resources._101057512_diseño_del_icono_del_logotipo_de_entrega__1_;
            this.pictureBox1.Location = new System.Drawing.Point(98, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(121, 98);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // PanelBlancoGestiones
            // 
            this.PanelBlancoGestiones.Controls.Add(this.pictureBox2);
            this.PanelBlancoGestiones.Location = new System.Drawing.Point(351, 0);
            this.PanelBlancoGestiones.Name = "PanelBlancoGestiones";
            this.PanelBlancoGestiones.Size = new System.Drawing.Size(1171, 833);
            this.PanelBlancoGestiones.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Presentación_GUI.Properties.Resources._101057512_diseño_del_icono_del_logotipo_de_entrega__1_;
            this.pictureBox2.Location = new System.Drawing.Point(480, 242);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(281, 270);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // FrmGestiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1522, 833);
            this.Controls.Add(this.PanelBlancoGestiones);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmGestiones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestiones";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PanelBlancoGestiones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnGestionarEmpaque;
        private System.Windows.Forms.Button BtnGestionarContenedor;
        private System.Windows.Forms.Button BtnGestionarEstibado;
        private System.Windows.Forms.Button BtnProductoStock;
        private System.Windows.Forms.Button BtnGestionarEmbalaje;
        private System.Windows.Forms.Panel PanelBlancoGestiones;
        private System.Windows.Forms.Button BtnVolverGestiones;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}