
namespace Facturacion_Electronica
{
    partial class FormEditTribute
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnActualizarTributo = new System.Windows.Forms.Button();
            this.tbIdentificadorTrib = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(96, 78);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(179, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnActualizarTributo
            // 
            this.btnActualizarTributo.BackColor = System.Drawing.Color.DarkGray;
            this.btnActualizarTributo.FlatAppearance.BorderSize = 0;
            this.btnActualizarTributo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarTributo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnActualizarTributo.Location = new System.Drawing.Point(106, 197);
            this.btnActualizarTributo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnActualizarTributo.Name = "btnActualizarTributo";
            this.btnActualizarTributo.Size = new System.Drawing.Size(149, 34);
            this.btnActualizarTributo.TabIndex = 124;
            this.btnActualizarTributo.Text = "Actualizar";
            this.btnActualizarTributo.UseVisualStyleBackColor = false;
            this.btnActualizarTributo.Click += new System.EventHandler(this.btnActualizarTributo_Click);
            // 
            // tbIdentificadorTrib
            // 
            this.tbIdentificadorTrib.Location = new System.Drawing.Point(96, 144);
            this.tbIdentificadorTrib.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbIdentificadorTrib.Name = "tbIdentificadorTrib";
            this.tbIdentificadorTrib.Size = new System.Drawing.Size(179, 20);
            this.tbIdentificadorTrib.TabIndex = 125;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label28.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label28.Location = new System.Drawing.Point(33, 145);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(60, 18);
            this.label28.TabIndex = 127;
            this.label28.Text = "Codigo:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label27.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label27.Location = new System.Drawing.Point(27, 79);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(66, 18);
            this.label27.TabIndex = 126;
            this.label27.Text = "Nombre:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label23.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label23.Location = new System.Drawing.Point(68, 9);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(221, 24);
            this.label23.TabIndex = 128;
            this.label23.Text = "Actualización de Tributos";
            this.label23.Click += new System.EventHandler(this.label23_Click);
            // 
            // FormEditTribute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(358, 299);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.tbIdentificadorTrib);
            this.Controls.Add(this.btnActualizarTributo);
            this.Controls.Add(this.comboBox1);
            this.Name = "FormEditTribute";
            this.Text = "FormEditTribute";
            this.Load += new System.EventHandler(this.FormEditTribute_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnActualizarTributo;
        private System.Windows.Forms.TextBox tbIdentificadorTrib;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label23;
    }
}