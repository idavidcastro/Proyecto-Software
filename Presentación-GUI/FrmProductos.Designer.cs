
namespace Presentación_GUI
{
    partial class FrmProductos
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
            this.dataGridViewConsultaProducto = new System.Windows.Forms.DataGridView();
            this.BtnConsultarProducto = new System.Windows.Forms.Button();
            this.CmbReferenciaConsultaProducto = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.CmbReferenciaProducto = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.BtnEditarProducto = new System.Windows.Forms.Button();
            this.BtnActProducto = new System.Windows.Forms.Button();
            this.BtnEliminarProducto = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnRegistrarProducto = new System.Windows.Forms.Button();
            this.TxtPrecioProducto = new System.Windows.Forms.TextBox();
            this.TxtPesoProducto = new System.Windows.Forms.TextBox();
            this.TxtNombreProducto = new System.Windows.Forms.TextBox();
            this.TxtRefProducto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConsultaProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewConsultaProducto
            // 
            this.dataGridViewConsultaProducto.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(115)))), ((int)(((byte)(171)))));
            this.dataGridViewConsultaProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewConsultaProducto.Location = new System.Drawing.Point(49, 603);
            this.dataGridViewConsultaProducto.Name = "dataGridViewConsultaProducto";
            this.dataGridViewConsultaProducto.RowHeadersWidth = 51;
            this.dataGridViewConsultaProducto.RowTemplate.Height = 24;
            this.dataGridViewConsultaProducto.Size = new System.Drawing.Size(1073, 181);
            this.dataGridViewConsultaProducto.TabIndex = 97;
            // 
            // BtnConsultarProducto
            // 
            this.BtnConsultarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(115)))), ((int)(((byte)(171)))));
            this.BtnConsultarProducto.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConsultarProducto.ForeColor = System.Drawing.SystemColors.Control;
            this.BtnConsultarProducto.Location = new System.Drawing.Point(630, 528);
            this.BtnConsultarProducto.Name = "BtnConsultarProducto";
            this.BtnConsultarProducto.Size = new System.Drawing.Size(214, 48);
            this.BtnConsultarProducto.TabIndex = 96;
            this.BtnConsultarProducto.Text = "Consultar";
            this.BtnConsultarProducto.UseVisualStyleBackColor = false;
            this.BtnConsultarProducto.Click += new System.EventHandler(this.BtnConsultarProducto_Click);
            // 
            // CmbReferenciaConsultaProducto
            // 
            this.CmbReferenciaConsultaProducto.FormattingEnabled = true;
            this.CmbReferenciaConsultaProducto.Location = new System.Drawing.Point(463, 543);
            this.CmbReferenciaConsultaProducto.Name = "CmbReferenciaConsultaProducto";
            this.CmbReferenciaConsultaProducto.Size = new System.Drawing.Size(106, 24);
            this.CmbReferenciaConsultaProducto.TabIndex = 95;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(327, 543);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(113, 20);
            this.label15.TabIndex = 94;
            this.label15.Text = "Ref. Producto:";
            // 
            // CmbReferenciaProducto
            // 
            this.CmbReferenciaProducto.FormattingEnabled = true;
            this.CmbReferenciaProducto.Location = new System.Drawing.Point(1036, 92);
            this.CmbReferenciaProducto.Name = "CmbReferenciaProducto";
            this.CmbReferenciaProducto.Size = new System.Drawing.Size(106, 24);
            this.CmbReferenciaProducto.TabIndex = 93;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(900, 92);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 20);
            this.label12.TabIndex = 92;
            this.label12.Text = "Ref. Producto:";
            // 
            // BtnEditarProducto
            // 
            this.BtnEditarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(115)))), ((int)(((byte)(171)))));
            this.BtnEditarProducto.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEditarProducto.ForeColor = System.Drawing.SystemColors.Control;
            this.BtnEditarProducto.Location = new System.Drawing.Point(918, 164);
            this.BtnEditarProducto.Name = "BtnEditarProducto";
            this.BtnEditarProducto.Size = new System.Drawing.Size(214, 48);
            this.BtnEditarProducto.TabIndex = 91;
            this.BtnEditarProducto.Text = "Editar";
            this.BtnEditarProducto.UseVisualStyleBackColor = false;
            this.BtnEditarProducto.Click += new System.EventHandler(this.BtnEditarProducto_Click);
            // 
            // BtnActProducto
            // 
            this.BtnActProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(115)))), ((int)(((byte)(171)))));
            this.BtnActProducto.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnActProducto.ForeColor = System.Drawing.SystemColors.Control;
            this.BtnActProducto.Location = new System.Drawing.Point(918, 250);
            this.BtnActProducto.Name = "BtnActProducto";
            this.BtnActProducto.Size = new System.Drawing.Size(214, 48);
            this.BtnActProducto.TabIndex = 90;
            this.BtnActProducto.Text = "Actualizar";
            this.BtnActProducto.UseVisualStyleBackColor = false;
            this.BtnActProducto.Click += new System.EventHandler(this.BtnActProducto_Click);
            // 
            // BtnEliminarProducto
            // 
            this.BtnEliminarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(115)))), ((int)(((byte)(171)))));
            this.BtnEliminarProducto.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminarProducto.ForeColor = System.Drawing.SystemColors.Control;
            this.BtnEliminarProducto.Location = new System.Drawing.Point(918, 334);
            this.BtnEliminarProducto.Name = "BtnEliminarProducto";
            this.BtnEliminarProducto.Size = new System.Drawing.Size(214, 48);
            this.BtnEliminarProducto.TabIndex = 89;
            this.BtnEliminarProducto.Text = "Eliminar";
            this.BtnEliminarProducto.UseVisualStyleBackColor = false;
            this.BtnEliminarProducto.Click += new System.EventHandler(this.BtnEliminarProducto_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(115)))), ((int)(((byte)(171)))));
            this.panel2.Location = new System.Drawing.Point(871, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 466);
            this.panel2.TabIndex = 88;
            // 
            // BtnRegistrarProducto
            // 
            this.BtnRegistrarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(115)))), ((int)(((byte)(171)))));
            this.BtnRegistrarProducto.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRegistrarProducto.ForeColor = System.Drawing.SystemColors.Control;
            this.BtnRegistrarProducto.Location = new System.Drawing.Point(375, 372);
            this.BtnRegistrarProducto.Name = "BtnRegistrarProducto";
            this.BtnRegistrarProducto.Size = new System.Drawing.Size(214, 48);
            this.BtnRegistrarProducto.TabIndex = 87;
            this.BtnRegistrarProducto.Text = "Registrar";
            this.BtnRegistrarProducto.UseVisualStyleBackColor = false;
            this.BtnRegistrarProducto.Click += new System.EventHandler(this.BtnRegistrarProducto_Click);
            // 
            // TxtPrecioProducto
            // 
            this.TxtPrecioProducto.Location = new System.Drawing.Point(436, 253);
            this.TxtPrecioProducto.Multiline = true;
            this.TxtPrecioProducto.Name = "TxtPrecioProducto";
            this.TxtPrecioProducto.Size = new System.Drawing.Size(127, 28);
            this.TxtPrecioProducto.TabIndex = 85;
            this.TxtPrecioProducto.TextChanged += new System.EventHandler(this.TxtPrecioProducto_TextChanged);
            this.TxtPrecioProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPrecioProducto_KeyPress);
            // 
            // TxtPesoProducto
            // 
            this.TxtPesoProducto.Location = new System.Drawing.Point(436, 205);
            this.TxtPesoProducto.Multiline = true;
            this.TxtPesoProducto.Name = "TxtPesoProducto";
            this.TxtPesoProducto.Size = new System.Drawing.Size(127, 28);
            this.TxtPesoProducto.TabIndex = 84;
            this.TxtPesoProducto.TextChanged += new System.EventHandler(this.TxtPesoProducto_TextChanged);
            this.TxtPesoProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPesoProducto_KeyPress);
            // 
            // TxtNombreProducto
            // 
            this.TxtNombreProducto.Location = new System.Drawing.Point(436, 162);
            this.TxtNombreProducto.Multiline = true;
            this.TxtNombreProducto.Name = "TxtNombreProducto";
            this.TxtNombreProducto.Size = new System.Drawing.Size(127, 28);
            this.TxtNombreProducto.TabIndex = 83;
            this.TxtNombreProducto.TextChanged += new System.EventHandler(this.TxtNombreProducto_TextChanged);
            this.TxtNombreProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNombreProducto_KeyPress);
            // 
            // TxtRefProducto
            // 
            this.TxtRefProducto.Location = new System.Drawing.Point(436, 77);
            this.TxtRefProducto.Multiline = true;
            this.TxtRefProducto.Name = "TxtRefProducto";
            this.TxtRefProducto.Size = new System.Drawing.Size(127, 28);
            this.TxtRefProducto.TabIndex = 82;
            this.TxtRefProducto.TextChanged += new System.EventHandler(this.TxtRefProducto_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(311, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 20);
            this.label5.TabIndex = 79;
            this.label5.Text = "Precio (COP):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(338, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 78;
            this.label4.Text = "Peso (Kg):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(347, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 77;
            this.label3.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(225, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 20);
            this.label1.TabIndex = 76;
            this.label1.Text = "Referencia del producto:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(115)))), ((int)(((byte)(171)))));
            this.panel1.Location = new System.Drawing.Point(12, 486);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1147, 10);
            this.panel1.TabIndex = 75;
            // 
            // FrmProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 833);
            this.Controls.Add(this.dataGridViewConsultaProducto);
            this.Controls.Add(this.BtnConsultarProducto);
            this.Controls.Add(this.CmbReferenciaConsultaProducto);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.CmbReferenciaProducto);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.BtnEditarProducto);
            this.Controls.Add(this.BtnActProducto);
            this.Controls.Add(this.BtnEliminarProducto);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.BtnRegistrarProducto);
            this.Controls.Add(this.TxtPrecioProducto);
            this.Controls.Add(this.TxtPesoProducto);
            this.Controls.Add(this.TxtNombreProducto);
            this.Controls.Add(this.TxtRefProducto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmProductos";
            this.Text = "FrmProductos";
            this.Load += new System.EventHandler(this.FrmProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConsultaProducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewConsultaProducto;
        private System.Windows.Forms.Button BtnConsultarProducto;
        private System.Windows.Forms.ComboBox CmbReferenciaConsultaProducto;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox CmbReferenciaProducto;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button BtnEditarProducto;
        private System.Windows.Forms.Button BtnActProducto;
        private System.Windows.Forms.Button BtnEliminarProducto;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnRegistrarProducto;
        private System.Windows.Forms.TextBox TxtPrecioProducto;
        private System.Windows.Forms.TextBox TxtPesoProducto;
        private System.Windows.Forms.TextBox TxtNombreProducto;
        private System.Windows.Forms.TextBox TxtRefProducto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}