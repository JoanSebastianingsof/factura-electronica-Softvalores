
namespace grid
{
    partial class FormAdd
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTIdNoCliente = new System.Windows.Forms.Label();
            this.lblTIdCliente = new System.Windows.Forms.Label();
            this.lblTContabilidad = new System.Windows.Forms.Label();
            this.cb_TipoIdCliente = new System.Windows.Forms.ComboBox();
            this.cb_Contabilidad = new System.Windows.Forms.ComboBox();
            this.txt_NoIdCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Ingreso = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Iva = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_rFuente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_CxC = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_rIca = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_rIva = new System.Windows.Forms.TextBox();
            this.lbl_TCodCuen = new System.Windows.Forms.Label();
            this.PC_F2Buscar = new System.Windows.Forms.Button();
            this.btn_F2Guardar = new System.Windows.Forms.Button();
            this.PC_F2Agregar = new System.Windows.Forms.Button();
            this.btn_Salir = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTIdNoCliente
            // 
            this.lblTIdNoCliente.AutoSize = true;
            this.lblTIdNoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblTIdNoCliente.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTIdNoCliente.Location = new System.Drawing.Point(12, 98);
            this.lblTIdNoCliente.Name = "lblTIdNoCliente";
            this.lblTIdNoCliente.Size = new System.Drawing.Size(95, 16);
            this.lblTIdNoCliente.TabIndex = 113;
            this.lblTIdNoCliente.Text = "No. ID Cliente :";
            // 
            // lblTIdCliente
            // 
            this.lblTIdCliente.AutoSize = true;
            this.lblTIdCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblTIdCliente.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTIdCliente.Location = new System.Drawing.Point(10, 56);
            this.lblTIdCliente.Name = "lblTIdCliente";
            this.lblTIdCliente.Size = new System.Drawing.Size(102, 16);
            this.lblTIdCliente.TabIndex = 112;
            this.lblTIdCliente.Text = "Tipo ID Cliente :";
            // 
            // lblTContabilidad
            // 
            this.lblTContabilidad.AutoSize = true;
            this.lblTContabilidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblTContabilidad.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTContabilidad.Location = new System.Drawing.Point(10, 12);
            this.lblTContabilidad.Name = "lblTContabilidad";
            this.lblTContabilidad.Size = new System.Drawing.Size(90, 16);
            this.lblTContabilidad.TabIndex = 108;
            this.lblTContabilidad.Text = "Contabilidad :";
            // 
            // cb_TipoIdCliente
            // 
            this.cb_TipoIdCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_TipoIdCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_TipoIdCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cb_TipoIdCliente.FormattingEnabled = true;
            this.cb_TipoIdCliente.Items.AddRange(new object[] {
            "CC",
            "CE",
            "NI",
            "NP",
            "OT",
            "PA",
            "TI"});
            this.cb_TipoIdCliente.Location = new System.Drawing.Point(10, 73);
            this.cb_TipoIdCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_TipoIdCliente.Name = "cb_TipoIdCliente";
            this.cb_TipoIdCliente.Size = new System.Drawing.Size(175, 24);
            this.cb_TipoIdCliente.TabIndex = 111;
            this.cb_TipoIdCliente.Text = "Seleccione un Item...";
            // 
            // cb_Contabilidad
            // 
            this.cb_Contabilidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_Contabilidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_Contabilidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cb_Contabilidad.FormatString = "N0";
            this.cb_Contabilidad.FormattingEnabled = true;
            this.cb_Contabilidad.Location = new System.Drawing.Point(12, 29);
            this.cb_Contabilidad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_Contabilidad.Name = "cb_Contabilidad";
            this.cb_Contabilidad.Size = new System.Drawing.Size(173, 24);
            this.cb_Contabilidad.TabIndex = 110;
            this.cb_Contabilidad.Text = "Seleccione un Item...";
            // 
            // txt_NoIdCliente
            // 
            this.txt_NoIdCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txt_NoIdCliente.Location = new System.Drawing.Point(10, 114);
            this.txt_NoIdCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_NoIdCliente.Name = "txt_NoIdCliente";
            this.txt_NoIdCliente.Size = new System.Drawing.Size(145, 22);
            this.txt_NoIdCliente.TabIndex = 109;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(225, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 115;
            this.label1.Text = "Ingreso :";
            this.label1.Visible = false;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txt_Ingreso
            // 
            this.txt_Ingreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txt_Ingreso.Location = new System.Drawing.Point(294, 29);
            this.txt_Ingreso.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Ingreso.Name = "txt_Ingreso";
            this.txt_Ingreso.Size = new System.Drawing.Size(105, 22);
            this.txt_Ingreso.TabIndex = 114;
            this.txt_Ingreso.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.Location = new System.Drawing.Point(252, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 16);
            this.label2.TabIndex = 117;
            this.label2.Text = "IVA :";
            this.label2.Visible = false;
            // 
            // txt_Iva
            // 
            this.txt_Iva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txt_Iva.Location = new System.Drawing.Point(294, 74);
            this.txt_Iva.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Iva.Name = "txt_Iva";
            this.txt_Iva.Size = new System.Drawing.Size(105, 22);
            this.txt_Iva.TabIndex = 116;
            this.txt_Iva.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(207, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 119;
            this.label3.Text = "Rte Fuente :";
            this.label3.Visible = false;
            // 
            // txt_rFuente
            // 
            this.txt_rFuente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txt_rFuente.Location = new System.Drawing.Point(294, 115);
            this.txt_rFuente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_rFuente.Name = "txt_rFuente";
            this.txt_rFuente.Size = new System.Drawing.Size(105, 22);
            this.txt_rFuente.TabIndex = 118;
            this.txt_rFuente.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(195, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 16);
            this.label4.TabIndex = 125;
            this.label4.Text = "Cta x Cobrar :";
            this.label4.Visible = false;
            // 
            // txt_CxC
            // 
            this.txt_CxC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txt_CxC.Location = new System.Drawing.Point(294, 242);
            this.txt_CxC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_CxC.Name = "txt_CxC";
            this.txt_CxC.Size = new System.Drawing.Size(105, 22);
            this.txt_CxC.TabIndex = 124;
            this.txt_CxC.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(230, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 123;
            this.label5.Text = "Rte Ica :";
            this.label5.Visible = false;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txt_rIca
            // 
            this.txt_rIca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txt_rIca.Location = new System.Drawing.Point(294, 200);
            this.txt_rIca.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_rIca.Name = "txt_rIca";
            this.txt_rIca.Size = new System.Drawing.Size(105, 22);
            this.txt_rIca.TabIndex = 122;
            this.txt_rIca.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(230, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 121;
            this.label6.Text = "Rte Iva :";
            this.label6.Visible = false;
            // 
            // txt_rIva
            // 
            this.txt_rIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txt_rIva.Location = new System.Drawing.Point(294, 156);
            this.txt_rIva.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_rIva.Name = "txt_rIva";
            this.txt_rIva.Size = new System.Drawing.Size(105, 22);
            this.txt_rIva.TabIndex = 120;
            this.txt_rIva.Visible = false;
            // 
            // lbl_TCodCuen
            // 
            this.lbl_TCodCuen.AutoSize = true;
            this.lbl_TCodCuen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lbl_TCodCuen.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_TCodCuen.Location = new System.Drawing.Point(324, 11);
            this.lbl_TCodCuen.Name = "lbl_TCodCuen";
            this.lbl_TCodCuen.Size = new System.Drawing.Size(82, 16);
            this.lbl_TCodCuen.TabIndex = 126;
            this.lbl_TCodCuen.Text = "COD Cuenta";
            this.lbl_TCodCuen.Visible = false;
            // 
            // PC_F2Buscar
            // 
            this.PC_F2Buscar.BackColor = System.Drawing.SystemColors.ControlDark;
            this.PC_F2Buscar.FlatAppearance.BorderSize = 0;
            this.PC_F2Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PC_F2Buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.PC_F2Buscar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PC_F2Buscar.Location = new System.Drawing.Point(13, 203);
            this.PC_F2Buscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PC_F2Buscar.Name = "PC_F2Buscar";
            this.PC_F2Buscar.Size = new System.Drawing.Size(116, 31);
            this.PC_F2Buscar.TabIndex = 127;
            this.PC_F2Buscar.Text = "Buscar";
            this.PC_F2Buscar.UseVisualStyleBackColor = false;
            this.PC_F2Buscar.Visible = false;
            this.PC_F2Buscar.Click += new System.EventHandler(this.PC_F2Buscar_Click);
            // 
            // btn_F2Guardar
            // 
            this.btn_F2Guardar.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn_F2Guardar.FlatAppearance.BorderSize = 0;
            this.btn_F2Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F2Guardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btn_F2Guardar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_F2Guardar.Location = new System.Drawing.Point(323, 296);
            this.btn_F2Guardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_F2Guardar.Name = "btn_F2Guardar";
            this.btn_F2Guardar.Size = new System.Drawing.Size(116, 31);
            this.btn_F2Guardar.TabIndex = 128;
            this.btn_F2Guardar.Text = "Guardar";
            this.btn_F2Guardar.UseVisualStyleBackColor = false;
            this.btn_F2Guardar.Visible = false;
            this.btn_F2Guardar.Click += new System.EventHandler(this.btn_F2Guardar_Click);
            // 
            // PC_F2Agregar
            // 
            this.PC_F2Agregar.BackColor = System.Drawing.SystemColors.ControlDark;
            this.PC_F2Agregar.FlatAppearance.BorderSize = 0;
            this.PC_F2Agregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PC_F2Agregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.PC_F2Agregar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PC_F2Agregar.Location = new System.Drawing.Point(13, 159);
            this.PC_F2Agregar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PC_F2Agregar.Name = "PC_F2Agregar";
            this.PC_F2Agregar.Size = new System.Drawing.Size(116, 31);
            this.PC_F2Agregar.TabIndex = 129;
            this.PC_F2Agregar.Text = "Agregar";
            this.PC_F2Agregar.UseVisualStyleBackColor = false;
            this.PC_F2Agregar.Click += new System.EventHandler(this.PC_F2Agregar_Click);
            // 
            // btn_Salir
            // 
            this.btn_Salir.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn_Salir.FlatAppearance.BorderSize = 0;
            this.btn_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btn_Salir.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Salir.Location = new System.Drawing.Point(13, 296);
            this.btn_Salir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Salir.Name = "btn_Salir";
            this.btn_Salir.Size = new System.Drawing.Size(116, 31);
            this.btn_Salir.TabIndex = 130;
            this.btn_Salir.Text = "Salir";
            this.btn_Salir.UseVisualStyleBackColor = false;
            this.btn_Salir.Click += new System.EventHandler(this.btn_Salir_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.comboBox1.FormatString = "N0";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "D",
            "C"});
            this.comboBox1.Location = new System.Drawing.Point(406, 29);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(33, 24);
            this.comboBox1.TabIndex = 131;
            this.comboBox1.Text = "C";
            this.comboBox1.Visible = false;
            // 
            // comboBox2
            // 
            this.comboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.comboBox2.FormatString = "N0";
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "D",
            "C"});
            this.comboBox2.Location = new System.Drawing.Point(406, 74);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(33, 24);
            this.comboBox2.TabIndex = 132;
            this.comboBox2.Text = "C";
            this.comboBox2.Visible = false;
            // 
            // comboBox3
            // 
            this.comboBox3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.comboBox3.FormatString = "N0";
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "D",
            "C"});
            this.comboBox3.Location = new System.Drawing.Point(406, 114);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(33, 24);
            this.comboBox3.TabIndex = 133;
            this.comboBox3.Text = "D";
            this.comboBox3.Visible = false;
            // 
            // comboBox4
            // 
            this.comboBox4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.comboBox4.FormatString = "N0";
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "D",
            "C"});
            this.comboBox4.Location = new System.Drawing.Point(406, 156);
            this.comboBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(33, 24);
            this.comboBox4.TabIndex = 134;
            this.comboBox4.Text = "D";
            this.comboBox4.Visible = false;
            // 
            // comboBox5
            // 
            this.comboBox5.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox5.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.comboBox5.FormatString = "N0";
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Items.AddRange(new object[] {
            "D",
            "C"});
            this.comboBox5.Location = new System.Drawing.Point(406, 200);
            this.comboBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(33, 24);
            this.comboBox5.TabIndex = 135;
            this.comboBox5.Text = "D";
            this.comboBox5.Visible = false;
            // 
            // comboBox6
            // 
            this.comboBox6.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox6.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.comboBox6.FormatString = "N0";
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Items.AddRange(new object[] {
            "D",
            "C"});
            this.comboBox6.Location = new System.Drawing.Point(406, 239);
            this.comboBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(33, 24);
            this.comboBox6.TabIndex = 136;
            this.comboBox6.Text = "D";
            this.comboBox6.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(135, 296);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 31);
            this.button1.TabIndex = 137;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(457, 336);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox6);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btn_Salir);
            this.Controls.Add(this.PC_F2Agregar);
            this.Controls.Add(this.btn_F2Guardar);
            this.Controls.Add(this.PC_F2Buscar);
            this.Controls.Add(this.lbl_TCodCuen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_CxC);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_rIca);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_rIva);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_rFuente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Iva);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Ingreso);
            this.Controls.Add(this.lblTIdNoCliente);
            this.Controls.Add(this.lblTIdCliente);
            this.Controls.Add(this.lblTContabilidad);
            this.Controls.Add(this.cb_TipoIdCliente);
            this.Controls.Add(this.cb_Contabilidad);
            this.Controls.Add(this.txt_NoIdCliente);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(473, 375);
            this.MinimumSize = new System.Drawing.Size(473, 375);
            this.Name = "FormAdd";
            this.Text = "Agregar Parametros Contables";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTIdNoCliente;
        private System.Windows.Forms.Label lblTIdCliente;
        private System.Windows.Forms.Label lblTContabilidad;
        private System.Windows.Forms.ComboBox cb_TipoIdCliente;
        private System.Windows.Forms.ComboBox cb_Contabilidad;
        private System.Windows.Forms.TextBox txt_NoIdCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Ingreso;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Iva;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_rFuente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_CxC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_rIca;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_rIva;
        private System.Windows.Forms.Label lbl_TCodCuen;
        private System.Windows.Forms.Button PC_F2Buscar;
        private System.Windows.Forms.Button btn_F2Guardar;
        private System.Windows.Forms.Button PC_F2Agregar;
        private System.Windows.Forms.Button btn_Salir;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.Button button1;
    }
}

