namespace Facturacion_Electronica
{
    partial class FormEditTipIden
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
            this.label23 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.tbTipoIdentificacion = new System.Windows.Forms.TextBox();
            this.btnActualizarTributo = new System.Windows.Forms.Button();
            this.cbTipoIdentificacion = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label23.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label23.Location = new System.Drawing.Point(85, 34);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(262, 24);
            this.label23.TabIndex = 134;
            this.label23.Text = "Actualización de identificación";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label28.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label28.Location = new System.Drawing.Point(96, 179);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(60, 18);
            this.label28.TabIndex = 133;
            this.label28.Text = "Codigo:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label27.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label27.Location = new System.Drawing.Point(20, 111);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(142, 18);
            this.label27.TabIndex = 132;
            this.label27.Text = "Tipo de Identifiación:";
            // 
            // tbTipoIdentificacion
            // 
            this.tbTipoIdentificacion.Location = new System.Drawing.Point(168, 175);
            this.tbTipoIdentificacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbTipoIdentificacion.Name = "tbTipoIdentificacion";
            this.tbTipoIdentificacion.Size = new System.Drawing.Size(179, 20);
            this.tbTipoIdentificacion.TabIndex = 131;
            // 
            // btnActualizarTributo
            // 
            this.btnActualizarTributo.BackColor = System.Drawing.Color.DarkGray;
            this.btnActualizarTributo.FlatAppearance.BorderSize = 0;
            this.btnActualizarTributo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarTributo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnActualizarTributo.Location = new System.Drawing.Point(138, 232);
            this.btnActualizarTributo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnActualizarTributo.Name = "btnActualizarTributo";
            this.btnActualizarTributo.Size = new System.Drawing.Size(149, 34);
            this.btnActualizarTributo.TabIndex = 130;
            this.btnActualizarTributo.Text = "Actualizar";
            this.btnActualizarTributo.UseVisualStyleBackColor = false;
            this.btnActualizarTributo.Click += new System.EventHandler(this.btnActualizarTributo_Click);
            // 
            // cbTipoIdentificacion
            // 
            this.cbTipoIdentificacion.FormattingEnabled = true;
            this.cbTipoIdentificacion.Location = new System.Drawing.Point(168, 111);
            this.cbTipoIdentificacion.Name = "cbTipoIdentificacion";
            this.cbTipoIdentificacion.Size = new System.Drawing.Size(179, 21);
            this.cbTipoIdentificacion.TabIndex = 129;
            // 
            // FormEditTipIden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(423, 305);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.tbTipoIdentificacion);
            this.Controls.Add(this.btnActualizarTributo);
            this.Controls.Add(this.cbTipoIdentificacion);
            this.Name = "FormEditTipIden";
            this.Text = "FormEditTipIden";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox tbTipoIdentificacion;
        private System.Windows.Forms.Button btnActualizarTributo;
        private System.Windows.Forms.ComboBox cbTipoIdentificacion;
    }
}