
namespace Presentación_GUI
{
    partial class FrmOrden
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
            this.BtnNuevaOrden = new System.Windows.Forms.Button();
            this.BtnConsultarOrden = new System.Windows.Forms.Button();
            this.PanelConsultarOrden = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbCodOrden = new System.Windows.Forms.ComboBox();
            this.BtnCerrarOrden = new System.Windows.Forms.Button();
            this.PanelConsultarOrden.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnNuevaOrden
            // 
            this.BtnNuevaOrden.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(115)))), ((int)(((byte)(171)))));
            this.BtnNuevaOrden.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNuevaOrden.ForeColor = System.Drawing.SystemColors.Control;
            this.BtnNuevaOrden.Location = new System.Drawing.Point(348, 68);
            this.BtnNuevaOrden.Name = "BtnNuevaOrden";
            this.BtnNuevaOrden.Size = new System.Drawing.Size(255, 50);
            this.BtnNuevaOrden.TabIndex = 0;
            this.BtnNuevaOrden.Text = "Nueva Orden";
            this.BtnNuevaOrden.UseVisualStyleBackColor = false;
            this.BtnNuevaOrden.Click += new System.EventHandler(this.BtnNuevaOrden_Click);
            // 
            // BtnConsultarOrden
            // 
            this.BtnConsultarOrden.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(115)))), ((int)(((byte)(171)))));
            this.BtnConsultarOrden.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConsultarOrden.ForeColor = System.Drawing.SystemColors.Control;
            this.BtnConsultarOrden.Location = new System.Drawing.Point(348, 163);
            this.BtnConsultarOrden.Name = "BtnConsultarOrden";
            this.BtnConsultarOrden.Size = new System.Drawing.Size(255, 50);
            this.BtnConsultarOrden.TabIndex = 2;
            this.BtnConsultarOrden.Text = "Consultar Orden";
            this.BtnConsultarOrden.UseVisualStyleBackColor = false;
            this.BtnConsultarOrden.Click += new System.EventHandler(this.BtnConsultarOrden_Click);
            // 
            // PanelConsultarOrden
            // 
            this.PanelConsultarOrden.Controls.Add(this.dataGridView1);
            this.PanelConsultarOrden.Controls.Add(this.label1);
            this.PanelConsultarOrden.Controls.Add(this.CmbCodOrden);
            this.PanelConsultarOrden.Location = new System.Drawing.Point(41, 228);
            this.PanelConsultarOrden.Name = "PanelConsultarOrden";
            this.PanelConsultarOrden.Size = new System.Drawing.Size(868, 286);
            this.PanelConsultarOrden.TabIndex = 3;
            this.PanelConsultarOrden.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(115)))), ((int)(((byte)(171)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(115)))), ((int)(((byte)(171)))));
            this.dataGridView1.Location = new System.Drawing.Point(41, 75);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(787, 173);
            this.dataGridView1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cod. Orden:";
            // 
            // CmbCodOrden
            // 
            this.CmbCodOrden.FormattingEnabled = true;
            this.CmbCodOrden.Location = new System.Drawing.Point(182, 26);
            this.CmbCodOrden.Name = "CmbCodOrden";
            this.CmbCodOrden.Size = new System.Drawing.Size(152, 24);
            this.CmbCodOrden.TabIndex = 0;
            // 
            // BtnCerrarOrden
            // 
            this.BtnCerrarOrden.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(115)))), ((int)(((byte)(171)))));
            this.BtnCerrarOrden.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCerrarOrden.ForeColor = System.Drawing.SystemColors.Control;
            this.BtnCerrarOrden.Location = new System.Drawing.Point(654, 542);
            this.BtnCerrarOrden.Name = "BtnCerrarOrden";
            this.BtnCerrarOrden.Size = new System.Drawing.Size(255, 50);
            this.BtnCerrarOrden.TabIndex = 4;
            this.BtnCerrarOrden.Text = "Cerrar";
            this.BtnCerrarOrden.UseVisualStyleBackColor = false;
            this.BtnCerrarOrden.Click += new System.EventHandler(this.BtnCerrarOrden_Click);
            // 
            // FrmOrden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 619);
            this.Controls.Add(this.BtnCerrarOrden);
            this.Controls.Add(this.PanelConsultarOrden);
            this.Controls.Add(this.BtnConsultarOrden);
            this.Controls.Add(this.BtnNuevaOrden);
            this.Name = "FrmOrden";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmOrden";
            this.Load += new System.EventHandler(this.FrmOrden_Load);
            this.PanelConsultarOrden.ResumeLayout(false);
            this.PanelConsultarOrden.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnNuevaOrden;
        private System.Windows.Forms.Button BtnConsultarOrden;
        private System.Windows.Forms.Panel PanelConsultarOrden;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbCodOrden;
        private System.Windows.Forms.Button BtnCerrarOrden;
    }
}