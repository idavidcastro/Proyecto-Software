
namespace Presentación_GUI
{
    partial class FrmPrincipal
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnGestionarProducto = new System.Windows.Forms.Button();
            this.panelGestionarProducto = new System.Windows.Forms.Panel();
            this.BtnRegistrarProducto = new System.Windows.Forms.Button();
            this.BtnConsultar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelGestionarProducto.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(115)))), ((int)(((byte)(171)))));
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(329, 953);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(80, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 135);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.panelGestionarProducto);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(22, 232);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(291, 496);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnGestionarProducto);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(285, 53);
            this.panel2.TabIndex = 0;
            // 
            // BtnGestionarProducto
            // 
            this.BtnGestionarProducto.Location = new System.Drawing.Point(15, 5);
            this.BtnGestionarProducto.Name = "BtnGestionarProducto";
            this.BtnGestionarProducto.Size = new System.Drawing.Size(254, 42);
            this.BtnGestionarProducto.TabIndex = 1;
            this.BtnGestionarProducto.Text = "Gestionar Producto";
            this.BtnGestionarProducto.UseVisualStyleBackColor = true;
            // 
            // panelGestionarProducto
            // 
            this.panelGestionarProducto.Controls.Add(this.button2);
            this.panelGestionarProducto.Controls.Add(this.BtnConsultar);
            this.panelGestionarProducto.Controls.Add(this.BtnRegistrarProducto);
            this.panelGestionarProducto.Location = new System.Drawing.Point(3, 62);
            this.panelGestionarProducto.Name = "panelGestionarProducto";
            this.panelGestionarProducto.Size = new System.Drawing.Size(285, 196);
            this.panelGestionarProducto.TabIndex = 1;
            // 
            // BtnRegistrarProducto
            // 
            this.BtnRegistrarProducto.Location = new System.Drawing.Point(15, 3);
            this.BtnRegistrarProducto.Name = "BtnRegistrarProducto";
            this.BtnRegistrarProducto.Size = new System.Drawing.Size(254, 42);
            this.BtnRegistrarProducto.TabIndex = 2;
            this.BtnRegistrarProducto.Text = "Registrar";
            this.BtnRegistrarProducto.UseVisualStyleBackColor = true;
            // 
            // BtnConsultar
            // 
            this.BtnConsultar.Location = new System.Drawing.Point(15, 53);
            this.BtnConsultar.Name = "BtnConsultar";
            this.BtnConsultar.Size = new System.Drawing.Size(254, 42);
            this.BtnConsultar.TabIndex = 3;
            this.BtnConsultar.Text = "Registrar";
            this.BtnConsultar.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 102);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(254, 42);
            this.button2.TabIndex = 4;
            this.button2.Text = "Registrar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1482, 953);
            this.Controls.Add(this.panel1);
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmGestion";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelGestionarProducto.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnGestionarProducto;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelGestionarProducto;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button BtnConsultar;
        private System.Windows.Forms.Button BtnRegistrarProducto;
    }
}