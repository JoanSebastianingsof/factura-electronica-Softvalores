using DocumentFormat.OpenXml;
using Facturacion_Electronica;
using grid;
using SpreadsheetLight;
using System;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Windows.Forms;
using System.Xml;

namespace Facturacion_Electronica
{
    public partial class Pagina_Principal : Form
    {
        // Cargar BD
        SqlConnection conexion = Conexion.Conectar();
        cargaDataGrid cargaDg = new cargaDataGrid();
        llenarcombobox combo = new llenarcombobox();
        string[] par_cont = new string[50];
        public Pagina_Principal()
        {
            InitializeComponent();
            combo.seleccionar(comboBox8);
            combo.captarTipIden(comboBox9);
            combo.seleccionar(cb_PCContabilidad);
            combo.seleccionar(cb_CFContabiliad);
            combo.seleccionar(cb_FCEmpresaFactura);
            combo.seleccionar(cb_EmpresaNC);
            combo.seleccionar(cb_EmpresaND);            
            combo.seleccionar(cb_ContabilidadNC);
            combo.seleccionar(cb_ContabilidadND);
            combo.captarTipIden(cb_PCTipoID);
            cargaDg.cargaPG(dgv_ParametrosGenerales);
            cargaDg.cargaFC(dataGridView1, "Facturas");
            cargaDg.cargaFC(dgv_FondoND, "Nota_Debito");
            cargaDg.cargaFC(dgv_FondoNC, "Nota_Credito");
            cargaDg.cargaTri(dataGridTributo);
            cargaDg.cargaIdentificacion(dataGridTipoIdentificación);
        }


        /* Menu */
        private void btn_MenuParametrosGenerales_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tp_ParametrosGenerales;
        }

        private void btn_MenuParametrosContables_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tp_ParametrosContables;
        }

        private void mn_Facturas_Cargadas_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tp_FacturasCargadas;
        }
        private void btn_MenuTributos_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tp_Tributos;

        }
        private void btn_TipoIdentificación_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tp_TipoIdentificacion;

        }

        private void btn_NotaCredito_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tp_NotaCredito;
        }

        private void btn_NotaDebito_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tp_NotaDebito;
        }
        private void btn_NDCargadas_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tp_NotasDebitoCargadas;
        }
        private void btn_MenuCargarFactura_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tp_CargarFactura;

        }
        private void btn_NCCargadas_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tp_NotasCreditoCargadas;
        }
        private void btn_MenuFacturasCargadas_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tp_FacturasCargadas;
        }
        private void btn_DocsCargados_Click(object sender, EventArgs e)
        {
            if (!p_DocsCargados.Visible)
            {
                p_DocsCargados.Visible = true;
                p_DocsCargados.BringToFront();

            }
            else
            {
                p_DocsCargados.Visible = false;
            }

        }

        private void btn_CargueDocs_Click(object sender, EventArgs e)
        {
            if (!p_CargueDocs.Visible)
            {
                p_CargueDocs.Visible = true;
                p_CargueDocs.BringToFront();

            }
            else
            {
                p_CargueDocs.Visible = false;
            }

        }
        private void button14_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            tb_FCIdFactura.Enabled = false;
            cargaDg.cargaTri(dataGridTributo);

        }

        /* Parametros Generales */
        private void btn_PGActualizar_Click(object sender, EventArgs e)
        {
            if (comboBox8.Text != "Seleccione un Item...")
            {
                if (cb_TipoComp.Text != "Seleccione un Item...")
                {
                    if (comboBox9.Text != "Seleccione un Item..." && txt_id.Text != "")
                    {
                        conexion.Close();
                        conexion.Open();
                        string cod = txt_id.Text; string Tcod = comboBox9.Text; string cont = " ";
                        string cadenaConsultaArbol = "select cod_arbo from dbo.gn_arbol where des_arbo='" + comboBox8.Text + "'";
                        SqlCommand comandoCARBOL = new SqlCommand(cadenaConsultaArbol, conexion);
                        SqlDataReader registroCArbol = comandoCARBOL.ExecuteReader();
                        if (registroCArbol.Read())
                        {
                            cont = registroCArbol["cod_arbo"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("ERROR : La contabilidad seleccionada no existe!");
                        }
                        conexion.Close();
                        conexion.Open();
                        string cadenaConsultaContaRegis = "select * from fe_ParametrosGenerales where Contabilidad='" + cont + "'";
                        SqlCommand comandoContaRegis = new SqlCommand(cadenaConsultaContaRegis, conexion);
                        SqlDataReader registroContaRegis = comandoContaRegis.ExecuteReader();
                        if (registroContaRegis.Read())
                        {
                            conexion.Close();
                            conexion.Open();
                            string cadena22 = "select nit_clie,tip_iden,Nombres from dbo.cm_terce where nit_clie='" + cod + "'";
                            //string NombreEmpresa = "";
                            SqlCommand comando = new SqlCommand(cadena22, conexion);
                            SqlDataReader registro = comando.ExecuteReader();
                            if (registro.Read())
                            {
                                if ((registro["tip_iden"].ToString()) == Tcod)
                                {
                                    // NombreEmpresa = registro["Nombres"].ToString();
                                    conexion.Close();
                                    conexion.Open();
                                    //string insert = "update fe_ParametrosGenerales set Contabilidad='" + cont + "' , Facturas='" + cb_TipoComp.Text + "' , TipoId='" + comboBox9.Text + "' , NoId='" + txt_id.Text + "' , Empresa='" + NombreEmpresa + "' where Contabilidad ='" + cont + "'";
                                    string insert = "update fe_ParametrosGenerales set Contabilidad='" + cont + "' , Facturas='" + cb_TipoComp.Text + "' , TipoId='" + comboBox9.Text + "' , NoId='" + txt_id.Text + "' where Contabilidad ='" + cont + "'";

                                    SqlCommand agregar = new SqlCommand(insert, conexion);
                                    agregar.ExecuteNonQuery();
                                    conexion.Close();
                                    cargaDg.cargaPG(dgv_ParametrosGenerales);
                                    comboBox9.Text = "Seleccione un Item..."; comboBox8.Text = "Seleccione un Item..."; cb_TipoComp.Text = "Seleccione un Item...";
                                    txt_id.Text = "";
                                    btn_PGGuardar.Visible = false; btn_PGConsulta.Visible = true; btn_PGAgregar.Visible = true; btn_PGActualizar.Visible = false; button8.Visible = false;
                                }
                                else
                                {
                                    conexion.Close();
                                    MessageBox.Show("El No ID no coincide con el Tipo ID registrado");
                                }

                            }
                            else
                            {
                                conexion.Close();
                                MessageBox.Show("La contabilidad no existe");
                            }

                        }
                        else
                        {
                            conexion.Close();
                            MessageBox.Show("ERROR : El ID Ingresado no se encuentra registrado!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Los campos del Cliente no pueden estar Vacios");
                    }
                }
                else
                {
                    MessageBox.Show("El campo Tipo de Comprobante es requerido");
                }
            }
            else
            {
                MessageBox.Show("El campo Contabilidad es requerido");
            }
        }

        private void btn_PGGuardar_Click(object sender, EventArgs e)
        {
            if (comboBox8.Text != "Seleccione un Item...")
            {
                if (cb_TipoComp.Text != "Seleccione un Item...")
                {
                    if (comboBox9.Text != "Seleccione un Item..." && txt_id.Text != "")
                    {
                        conexion.Open();
                        string cadenaConsultaIDC = "select NoId from fe_ParametrosGenerales where NoId='" + txt_id.Text + "'";
                        SqlCommand comandoCIDC = new SqlCommand(cadenaConsultaIDC, conexion);
                        SqlDataReader registroCIDC = comandoCIDC.ExecuteReader();
                        if (registroCIDC.Read())
                        {
                            conexion.Close();
                            MessageBox.Show("ERROR : El ID Ingresado ya se encuentra registrado!");
                        }
                        else
                        {
                            conexion.Close();
                            conexion.Open();
                            string cod = txt_id.Text; string Tcod = comboBox9.Text; string cont = " ";
                            string cadenaConsultaArbol = "select cod_arbo from dbo.gn_arbol where des_arbo='" + comboBox8.Text + "'";
                            SqlCommand comandoCARBOL = new SqlCommand(cadenaConsultaArbol, conexion);
                            SqlDataReader registroCArbol = comandoCARBOL.ExecuteReader();
                            if (registroCArbol.Read())
                            {
                                cont = registroCArbol["cod_arbo"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("ERROR : La contabilidad seleccionada no existe!");
                            }
                            conexion.Close();
                            conexion.Open();
                            string cadenaConsultaContaRegis = "select * from fe_ParametrosGenerales where Contabilidad='" + cont + "'";
                            SqlCommand comandoContaRegis = new SqlCommand(cadenaConsultaContaRegis, conexion);
                            SqlDataReader registroContaRegis = comandoContaRegis.ExecuteReader();
                            if (registroContaRegis.Read())
                            {
                                conexion.Close();
                                MessageBox.Show("La contabilidad ya se encuentra asignada");
                            }
                            else
                            {
                                conexion.Close();
                                conexion.Open();
                                string cadena22 = "select nit_clie,tip_iden,Nombres from dbo.cm_terce where nit_clie='" + cod + "'";
                                //string NombreEmpresa = "";
                                SqlCommand comando = new SqlCommand(cadena22, conexion);
                                SqlDataReader registro = comando.ExecuteReader();
                                if (registro.Read())
                                {
                                    if ((registro["tip_iden"].ToString()) == Tcod)
                                    {
                                        //NombreEmpresa = registro["Nombres"].ToString();
                                        conexion.Close();
                                        conexion.Open();
                                        // string insert = "insert into fe_ParametrosGenerales values(@Contabilidad, @Facturas, @TipoId, @NoId, @Empresa)";
                                        string insert = "insert into fe_ParametrosGenerales values(@Contabilidad, @Facturas, @TipoId, @NoId)";
                                        SqlCommand agregar = new SqlCommand(insert, conexion);

                                        agregar.Parameters.AddWithValue("@Contabilidad", cont);
                                        agregar.Parameters.AddWithValue("@Facturas", cb_TipoComp.Text);
                                        agregar.Parameters.AddWithValue("@TipoId", Tcod);
                                        agregar.Parameters.AddWithValue("@NoId", cod);
                                        //agregar.Parameters.AddWithValue("@Empresa", NombreEmpresa);

                                        agregar.ExecuteNonQuery();
                                        conexion.Close();
                                        //dgv_ParametrosGenerales.Rows.Add(cont, cb_TipoComp.Text, comboBox9.Text, txt_id.Text, NombreEmpresa);
                                        dgv_ParametrosGenerales.Rows.Add(cont, cb_TipoComp.Text, comboBox9.Text, txt_id.Text);
                                        comboBox9.Text = "Seleccione un Item..."; comboBox8.Text = "Seleccione un Item..."; cb_TipoComp.Text = "Seleccione un Item...";
                                        txt_id.Text = "";
                                        btn_PGGuardar.Visible = false; btn_PGConsulta.Visible = true; btn_PGAgregar.Visible = true; btn_PGVolver.Visible = false;
                                    }
                                    else
                                    {
                                        conexion.Close();
                                        MessageBox.Show("El No ID no coincide con el Tipo ID registrado");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Error: El No de Id no existe");
                                    conexion.Close();
                                }

                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Los campos del Cliente no pueden estar vacios");
                    }
                }
                else
                {
                    MessageBox.Show("El campo Tipo de Comprobante es requerido");
                }
            }
            else
            {
                MessageBox.Show("El campo Contabilidad es requerido");
            }
        }

        private void btn_PGVolver_Click(object sender, EventArgs e)
        {
            btn_PGGuardar.Visible = false; btn_PGConsulta.Visible = true; btn_PGAgregar.Visible = true; btn_PGVolver.Visible = false;
        }

        private void btn_PGAgregar_Click(object sender, EventArgs e)
        {
            btn_PGGuardar.Visible = true; btn_PGConsulta.Visible = false; btn_PGAgregar.Visible = false; btn_PGVolver.Visible = true;
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox8.SelectedIndex > 0)
            {
                string[] valores = combo.captarInfo(comboBox8.Text);
                int id = Int32.Parse(valores[0]);

                combo.cargar(cb_TipoComp, id);
            }
        }

        private void btn_PGConsulta_Click(object sender, EventArgs e)
        {
            btn_PGActualizar.Visible = true; btn_PGConsulta.Visible = false; btn_PGAgregar.Visible = false; button8.Visible = true;

            string arbol = this.dgv_ParametrosGenerales.CurrentCell.Value.ToString(); string NombreArbol = "";
            conexion.Open();
            string cadenaConsultaArbol = "select des_arbo from dbo.gn_arbol where cod_arbo='" + arbol + "'";
            SqlCommand comandoCArbol = new SqlCommand(cadenaConsultaArbol, conexion);
            SqlDataReader registroCArbol = comandoCArbol.ExecuteReader();
            if (registroCArbol.Read())
            {
                NombreArbol = registroCArbol["des_arbo"].ToString();
                conexion.Close();

                conexion.Open();
                string cadenaConsultaIDC = "select Contabilidad,Facturas,TipoId,NoId from fe_ParametrosGenerales where Contabilidad='" + arbol + "'";
                SqlCommand comandoCIDC = new SqlCommand(cadenaConsultaIDC, conexion);
                SqlDataReader registroCIDC = comandoCIDC.ExecuteReader();
                if (registroCIDC.Read())
                {
                    comboBox8.Text = NombreArbol;
                    cb_TipoComp.Text = registroCIDC["Facturas"].ToString();
                    txt_id.Text = registroCIDC["NoId"].ToString();
                    comboBox9.Text = registroCIDC["TipoId"].ToString();

                    conexion.Close();

                }

            }
        }

        /* Parametros Contables */
        private void btn_PCEditarCliente_Click(object sender, EventArgs e)
        {
            FormEdit formulario2 = new FormEdit(cb_PCContabilidad.Text, cb_PCTipoID.Text, lbl_IdCliente.Text);
            formulario2.Show();
            btn_PCEditarCliente.Visible = false;
            cb_PCContabilidad.Text = "Seleccione un Item...";
            cb_PCTipoID.Text = "Seleccione un Item...";
            btn_PCNombreCliente.Text = "Seleccione Contabilidad...";
            lbl_PCNombreCliente.Visible = false;
            btn_PCEditarCliente.Visible = false;
            lbl_IdCliente.Visible = false;
            dgv_ParametrosContables.Rows.Clear();
        }

        private void btn_PCBuscarCliente_Click(object sender, EventArgs e)
        {
            if (cb_PCContabilidad.Text != "Seleccione un Item..." && cb_PCTipoID.Text == "Seleccione un Item...")
            {
                MessageBox.Show("Seleccione un Tipo de Id");
                lbl_PCNombreCliente.Visible = false;
            }
            else if (cb_PCContabilidad.Text != "Seleccione un Item..." && cb_PCTipoID.Text != "Seleccione un Item...")
            {
                if (btn_PCNombreCliente.Text != "Seleccione un Item...")
                {
                    lbl_PCNombreCliente.Text = btn_PCNombreCliente.Text;
                    string obtenerIdC = "";
                    conexion.Open();
                    string cadenaCNomC = "select nit_clie from dbo.cm_terce where nom_terc='" + btn_PCNombreCliente.Text + "'";
                    SqlCommand comandoNomC = new SqlCommand(cadenaCNomC, conexion);
                    SqlDataReader registroNomC = comandoNomC.ExecuteReader();
                    if (registroNomC.Read())
                    {
                        obtenerIdC = registroNomC["nit_clie"].ToString();
                    }
                    conexion.Close();

                    string ContabilidadNum = ""; lbl_PCNombreCliente.Visible = true;

                    conexion.Open();
                    string cadenaCons = "select cod_arbo from dbo.gn_arbol where des_arbo='" + cb_PCContabilidad.Text + "'";
                    SqlCommand comandoCons = new SqlCommand(cadenaCons, conexion);
                    SqlDataReader registroCons = comandoCons.ExecuteReader();
                    if (registroCons.Read())
                    {
                        ContabilidadNum = registroCons["cod_arbo"].ToString();
                    }
                    conexion.Close();
                    conexion.Open();
                    dgv_ParametrosContables.Rows.Clear();
                    string cadenaConsT = "select * from fe_parametrosContables where Contabilidad=" + ContabilidadNum + " and TipoId_Cliente='" + cb_PCTipoID.Text + "' and No_idCLiente='" + obtenerIdC + "'";
                    SqlCommand comandoConsT = new SqlCommand(cadenaConsT, conexion);
                    SqlDataReader registroConsT = comandoConsT.ExecuteReader();

                    while (registroConsT.Read())
                    {
                        if ((registroConsT[6].ToString()) == "T    ")
                        {
                            dgv_ParametrosContables.Rows.Add(registroConsT[1].ToString(), registroConsT[2].ToString(), registroConsT[3].ToString(), registroConsT[4].ToString(), registroConsT[5].ToString());
                        }
                        else
                        {
                            dgv_ParametrosContables.Rows.Add(" ", " ", registroConsT[3].ToString(), registroConsT[4].ToString(), registroConsT[5].ToString());
                        }
                        lbl_IdCliente.Text = registroConsT[2].ToString();
                    }

                    conexion.Close();
                    btn_PCEditarCliente.Visible = true;
                    lbl_IdCliente.Visible = true;
                }
                else
                {
                    MessageBox.Show("Seleccione un Numero de ID o Nombre del Cliente para realizar la busqueda por Cliente.");
                    lbl_PCNombreCliente.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Seleccione Contabilidad para realizar busqueda");
                dgv_ParametrosContables.Rows.Clear();
                lbl_PCNombreCliente.Visible = false;
            }

        }

        private void btn_PCAgregarCliente_Click(object sender, EventArgs e)
        {
            cb_PCContabilidad.Text = "Seleccione un Item...";
            cb_PCTipoID.Text = "Seleccione un Item...";
            btn_PCNombreCliente.Text = "Seleccione Contabilidad...";
            lbl_PCNombreCliente.Visible = false;
            btn_PCEditarCliente.Visible = false;
            lbl_IdCliente.Visible = false;
            dgv_ParametrosContables.Rows.Clear();
            Form formulario2 = new FormAdd();
            formulario2.Show();
        }

        private void cb_PCContabilidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_PCContabilidad.SelectedIndex > 0)
            {
                btn_PCNombreCliente.Text = "Seleccione un Tipo Id...";
            }
        }

        private void cb_PCTipoID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_PCContabilidad.SelectedIndex > 0)
            {
                string[] valores = combo.captarInfo(cb_PCContabilidad.Text);
                int id = Int32.Parse(valores[0]);

                string[] valores1 = combo.captarInfo(cb_PCContabilidad.Text);

                combo.cargarNomClientes(btn_PCNombreCliente, id, cb_PCTipoID.Text);
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            comboBox9.Text = "Seleccione un Item..."; comboBox8.Text = "Seleccione un Item..."; cb_TipoComp.Text = "Seleccione un Item...";
            txt_id.Text = "";
            btn_PGGuardar.Visible = false; btn_PGConsulta.Visible = true; btn_PGAgregar.Visible = true; btn_PGActualizar.Visible = false; button8.Visible = false;
        }

        /* Cargar Factura */
        private void btn_CFBuscarDocumento_Click(object sender, EventArgs e)
        {
            if (cb_CFContabiliad.Text != "Seleccione un Item...")
            {
                conexion.Open();
                string cont = " ";

                string cadenaConsultaArbol = "select cod_arbo from dbo.gn_arbol where des_arbo='" + cb_CFContabiliad.Text + "'";
                SqlCommand comandoCARBOL = new SqlCommand(cadenaConsultaArbol, conexion);
                SqlDataReader registroCArbol = comandoCARBOL.ExecuteReader();
                if (registroCArbol.Read())
                {
                    cont = registroCArbol["cod_arbo"].ToString();
                }
                else
                {
                    MessageBox.Show("ERROR : La contabilidad seleccionada no existe!");
                }
                conexion.Close();
                conexion.Open();
                string NoEmpresaFactura = ""; string TipoIdEmpresaFactura = "";
                string cadenaConsultaEF = "select NoId,TipoId from fe_ParametrosGenerales where Contabilidad='" + cont + "'";
                SqlCommand comandoCEF = new SqlCommand(cadenaConsultaEF, conexion);
                SqlDataReader registroCEF = comandoCEF.ExecuteReader();
                if (registroCEF.Read())
                {
                    NoEmpresaFactura = registroCEF["NoId"].ToString();
                    TipoIdEmpresaFactura = registroCEF["TipoId"].ToString();
                }
                else
                {
                    MessageBox.Show("ERROR 2: La contabilidad seleccionada no existe!");
                }
                conexion.Close();
                // openFileDialog1.Filter = "archivos xml (*.xml)|*.xml|Todos los archivos (*.*)|*.*";
                openFileDialog1.Filter = "archivos xml (*.xml)|*.xml";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Lbl_Abrir.Text = openFileDialog1.FileName;
                }
                String path = Lbl_Abrir.Text;

                if (path != "0")
                {
                    int cantId = 0; int cantNote = 0; int cantIva = 0; int cantVtotal = 0; int cantNit = 0; int idschemes = 0;
                    int clientePosition = 0; int cantSubT = 0; int idschemesName = 0;

                    String date = " "; string[] subTotal = new string[50];

                    string[] id = new string[50]; string[] note = new string[10]; string[] iva = new string[50];
                    string[] Vtotal = new string[50]; string[] nit = new string[50]; string[] idschemeName = new string[50]; string[] idscheme = new string[50];
                    string[] clienteNombre = new string[50];

                    XmlReader xmlReader = XmlReader.Create(path);

                    while (xmlReader.Read())
                    {
                        if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "cbc:IssueDate"))
                        {
                            date = xmlReader.ReadInnerXml();
                        }
                        else if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "cbc:ID"))
                        {
                            id[cantId] = (xmlReader.ReadInnerXml());
                            cantId = cantId + 1;
                        }
                        else if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "cbc:CompanyID"))
                        {
                            if (xmlReader.HasAttributes)
                            {
                                idscheme[idschemes] = xmlReader.GetAttribute("schemeID");
                                idschemes++;
                                idschemeName[idschemesName] = xmlReader.GetAttribute("schemeName");
                                idschemesName++;
                                nit[cantNit] = (xmlReader.ReadInnerXml());
                                cantNit = cantNit + 1;
                            }
                        }
                        else if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "cbc:Note"))
                        {
                            note[cantNote] = (xmlReader.ReadInnerXml());
                            cantNote = cantNote + 1;
                        }

                        else if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "cbc:LineExtensionAmount"))
                        {
                            Vtotal[cantVtotal] = (xmlReader.ReadInnerXml());
                            cantVtotal = cantVtotal + 1;
                        }

                        else if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "cbc:CompanyID"))
                        {
                            nit[cantNit] = (xmlReader.ReadInnerXml());
                            cantNit = cantNit + 1;
                        }
                        else if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "cbc:TaxableAmount"))
                        {
                            subTotal[cantSubT] = (xmlReader.ReadInnerXml());
                            cantSubT = cantSubT + 1;
                        }
                        else if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "cbc:RegistrationName"))
                        {
                            clienteNombre[clientePosition] = (xmlReader.ReadInnerXml());
                            clientePosition = clientePosition + 1;
                        }
                        else if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "cbc:TaxAmount"))
                        {
                            iva[cantIva] = (xmlReader.ReadInnerXml());
                            cantIva = cantIva + 1;
                        }
                    }
                    String Nit = "31";
                    String FacturaEmpresaFactura = "";
                    String FacturaEmpresaFactura2 = "";
                   
                    if (idschemeName[1] == Nit)
                    {
                        if (idscheme[1] != null)
                        {
                            FacturaEmpresaFactura = id[1] + "-" + idscheme[1] + "   ";
                            FacturaEmpresaFactura2 = id[2] + "-" + idscheme[2] + "   ";


                        }
                    }
                    else
                    {
                        FacturaEmpresaFactura = id[1] + "   ";
                        FacturaEmpresaFactura2 = id[2] + "   ";

                    }

                   

                    //Lectura de tributos
                    conexion.Open();
                    string tributo = "SELECT Nom_Tributo, identificador FROM fe_Tributo"; 
                    SqlCommand consultaTri = new SqlCommand(tributo, conexion);
                    SqlDataReader consultaTributo = consultaTri.ExecuteReader();

                   
                    string[] tributos = new string[99];
                    int i = -1;

                    while (consultaTributo.Read())
                    {
                        i++;
                        /*string columna1 = consultaTributo["Nom_Tributo"].ToString();
                        string columna2 = consultaTributo["identificador"].ToString();
                         tributos.Add((columna1, columna2));*/
                        tributos[i] = consultaTributo["Nom_Tributo"].ToString();
                    }
                    conexion.Close();
               

                    if (NoEmpresaFactura == FacturaEmpresaFactura || NoEmpresaFactura == FacturaEmpresaFactura2)
                    //if (respuesta == true)
                    {
                        String separator = note[0];

                        char[] limitador = { ' ', '$', '*' };
                        string[] arreglo = separator.Split(limitador, StringSplitOptions.RemoveEmptyEntries);
                        string[] rete = new string[15]; rete[1] = "0"; rete[2] = "0"; rete[3] = "0"; rete[4] = "0";
                        string[] reteDesc = new string[15];
                        int retenciones = 7;
                        for (i = 0; i < arreglo.Length; i++)
                        {
                            rete[0] = Vtotal[0];
                            reteDesc[0] = ("Ingreso");
                            Console.WriteLine(rete[0] + "Ingreos");

                            rete[1] = iva[1];
                            reteDesc[1] = ("IVA");
                            Console.WriteLine(rete[1] + "Iva");

                            if (arreglo[i] == "Retefuente")
                            {
                                rete[2] = (arreglo[i + 2]);
                                reteDesc[2] = ("Rte.Fte");
                                //reteDesc[1] = ("Retefuente");
                            }
                            if (arreglo[i] == "ReteIva")
                            {
                                rete[3] = (arreglo[i + 2]);
                                reteDesc[3] = ("Rte.Iva");
                                //reteDesc[2] = ("ReteIva");

                            }

                            if (arreglo[i] == "ReteIca")
                            {
                                rete[4] = (arreglo[i + 5]);
                                //reteDesc[3] = ("ReteIca");
                                reteDesc[4] = ("Rte.Ica");

                                //Console.WriteLine(rete[3] + "ICA1");

                            }
                            if (arreglo[i] == "9.66" || arreglo[i] == "14" || arreglo[i] == "6.9" || arreglo[i] == "10" || arreglo[i] == "11.44")
                            {
                                rete[4] = (arreglo[i + 4]);
                                //reteDesc[3] = ("ReteIca");
                                reteDesc[4] = ("Rte.Ica");
                                //Console.WriteLine(rete[3] + "ICA2");
                                retenciones++;

                            }
                            if (arreglo[i] == "Pagar")
                            {
                                rete[5] = (arreglo[i + 1]);
                                // total = (arreglo[i + 1]);
                                reteDesc[5] = ("Cta x Cobrar");
                            }
                            for (int z = 0; z < tributos.Length; z++)
                            {
                                if (arreglo[i] == tributos[z] && tributos[z] != "ReteIca" && tributos[z] != "Retefuente" && tributos[z] != "ReteIva" && tributos[z] != "Pagar")
                                {
                                    rete[retenciones] = (arreglo[i + 2]);
                                    reteDesc[retenciones] = tributos[z];
                                    retenciones++;

                                }
                            }

                        }

                     
                        //double totals= Convert.ToDouble(total, System.Globalization.CultureInfo.InvariantCulture);
                        /*double res = Convert.ToDouble(iva[1], System.Globalization.CultureInfo.InvariantCulture);
                        iva[1] = string.Format("{0:f2}", res);*/
                        for (int x = 1; x <= 5; x++)
                        {
                            double CorreccRes = Convert.ToDouble(rete[x], System.Globalization.CultureInfo.InvariantCulture);
                            //rete[x] = string.Format("{0:f2}", CorreccRes);
                        }

                        double CxCcorreccion = Convert.ToDouble(Vtotal[0], System.Globalization.CultureInfo.InvariantCulture);
                        // Vtotal[0] = string.Format("{0:f2}", CxCcorreccion);
                        decimal ingresos = decimal.Parse(Vtotal[0])/100;
                        decimal ivaD = decimal.Parse(iva[1])/100;

                        decimal TCreditos = ingresos + ivaD;
                        //decimal TCreditos = decimal.Parse(Vtotal[0])) + (decimal.Parse(iva[1]);
                        //decimal TCreditos = decimal.Parse(Vtotal[0])) + (decimal.Parse(iva[1]);
                        //decimal TCreditos = Math.Round(decimal.Parse(Vtotal[0]) + decimal.Parse(iva[1]), 2);

                        /*String TCreditosStr = string.Format("{0:f2}", TCredito);
                        decimal TCreditos = decimal.Parse(TCreditosStr);*/
                        decimal TDebitos = decimal.Parse(rete[2])/100 + decimal.Parse(rete[3])/100 + decimal.Parse(rete[4])/100;
                        decimal CtaXCobrar = TCreditos - TDebitos;
                  
                        dgv_FacturaCargada.Rows.Clear();
                        conexion.Open();
                        //prueba
                        string NitCliente = "";
                        if (idschemeName[2] == Nit)
                            NitCliente = nit[2] + "-" + idscheme[2];
                        else
                            NitCliente = nit[2];
                        string cadenaCliente = "select nom_terc from dbo.cm_terce where nit_clie='" + NitCliente + "'";
                        SqlCommand comandoCliente = new SqlCommand(cadenaCliente, conexion);
                        SqlDataReader registrosClientes = comandoCliente.ExecuteReader();
                        bool registroCliente = registrosClientes.Read();
                        conexion.Close();

                        conexion.Open();
                        string cod = "";
                        if (idschemeName[2] == Nit)
                        {
                            cod = nit[2] + "-" + idscheme[2];
                        }
                        else
                        {
                            cod = nit[2];
                        }



                        rete[6] = CtaXCobrar.ToString();
                        string cadena = "select Cod_Cuenta,Tipo_Mov from dbo.fe_parametrosContables where No_idCLiente='" + cod + "'";
                        SqlCommand comando = new SqlCommand(cadena, conexion);
                        SqlDataReader registro = comando.ExecuteReader();
                        bool registros = registro.Read();
                        if (registro.Read())
                        {
                            conexion.Close();
                            conexion.Open();
                            string cadenaIngreso = "select Cod_Cuenta,Tipo_Mov,Tipo_Cuenta from dbo.fe_parametrosContables where No_idCLiente='" + cod + "'" + "and Tipo_Cuenta ='Ingreso'";
                            string cadenaIva = "select Cod_Cuenta,Tipo_Mov,Tipo_Cuenta from dbo.fe_parametrosContables where No_idCLiente='" + cod + "'" + "and Tipo_Cuenta ='IVA'";
                            string cadenaRfte = "select Cod_Cuenta,Tipo_Mov,Tipo_Cuenta from dbo.fe_parametrosContables where No_idCLiente='" + cod + "'" + "and Tipo_Cuenta ='Rte.Fte'";
                            string cadenaRiva = "select Cod_Cuenta,Tipo_Mov,Tipo_Cuenta from dbo.fe_parametrosContables where No_idCLiente='" + cod + "'" + "and Tipo_Cuenta ='Rte.Iva'";
                            string cadenaRica = "select Cod_Cuenta,Tipo_Mov,Tipo_Cuenta from dbo.fe_parametrosContables where No_idCLiente='" + cod + "'" + "and Tipo_Cuenta ='Rte.Ica'";
                            string cadenaCxc = "select Cod_Cuenta,Tipo_Mov,Tipo_Cuenta from dbo.fe_parametrosContables where No_idCLiente='" + cod + "'" + "and Tipo_Cuenta ='Cta x Cobrar'";
                            SqlCommand comandoIngreso = new SqlCommand(cadenaIngreso, conexion);
                            SqlDataReader registroIngreso = comandoIngreso.ExecuteReader();
                            if (registroIngreso.Read() && rete[4] != " ")
                            {
                                dgv_FacturaCargada.Rows.Add(registroIngreso["Cod_Cuenta"].ToString(), "Ingreso   Factura No. " + id[0] + "  " + clienteNombre[2], Vtotal[0], registroIngreso["Tipo_Mov"].ToString());
                            }
                            else
                            {
                                MessageBox.Show("El ingreso no tiene asignada una cuenta");
                            }
                            conexion.Close();
                            conexion.Open();
                            SqlCommand comandoIva = new SqlCommand(cadenaIva, conexion);
                            SqlDataReader registroIva = comandoIva.ExecuteReader();
                            if (registroIva.Read() && iva[1] != " ")
                            {
                                dgv_FacturaCargada.Rows.Add(registroIva["Cod_Cuenta"].ToString(), "Iva   Factura No. " + id[0] + "  " + clienteNombre[2], iva[1], registroIva["Tipo_Mov"].ToString());


                            }

                            conexion.Close();
                            conexion.Open();
                            SqlCommand comandoRfte = new SqlCommand(cadenaRfte, conexion);
                            SqlDataReader registroRfte = comandoRfte.ExecuteReader();

                            if (registroRfte.Read() && rete[1] != " ")
                            {
                                dgv_FacturaCargada.Rows.Add(registroRfte["Cod_Cuenta"].ToString(), "Rte.Fte   Factura No. " + id[0] + "  " + clienteNombre[2], rete[2], registroRfte["Tipo_Mov"].ToString());
                            }

                            conexion.Close();
                            conexion.Open();
                            SqlCommand comandoRiva = new SqlCommand(cadenaRiva, conexion);
                            SqlDataReader registroRiva = comandoRiva.ExecuteReader();
                            if (registroRiva.Read() && rete[2] != " ")
                            {
                                dgv_FacturaCargada.Rows.Add(registroRiva["Cod_Cuenta"].ToString(), "Rte.Iva   Factura No. " + id[0] + "  " + clienteNombre[2], rete[3], registroRiva["Tipo_Mov"].ToString());
                            }

                            conexion.Close();
                            conexion.Open();
                            SqlCommand comandoRica = new SqlCommand(cadenaRica, conexion);
                            SqlDataReader registroRica = comandoRica.ExecuteReader();
                            if (registroRica.Read() && rete[3] != " ")
                            {
                                dgv_FacturaCargada.Rows.Add(registroRica["Cod_Cuenta"].ToString(), "Rte.Ica  Factura No. " + id[0] + "  " + clienteNombre[2], rete[4], registroRica["Tipo_Mov"].ToString());
                                Console.WriteLine(rete[3] + "P");

                            }
                            conexion.Close();

                            conexion.Open();
                            //Tipo de identificación
                            string ConsultaTipoIdentificacion = "select * from  fe_TipoIden ";
                            SqlCommand comandoTipoIdentificacion = new SqlCommand(ConsultaTipoIdentificacion, conexion);
                            SqlDataReader registroTipoIdentificacion = comandoTipoIdentificacion.ExecuteReader();
                            string[] arrTipoIdentificacion = new string[99];
                            int a = -1;
                            while (registroTipoIdentificacion.Read())
                            {
                                a++;
                                arrTipoIdentificacion[a] = registroTipoIdentificacion["Tip_Iden"].ToString();
                                a++;
                                arrTipoIdentificacion[a] = registroTipoIdentificacion["Codigo_Dian"].ToString();


                            }
                            /*for (i = 0; i < rete.Length; i++)
                            {

                                Console.WriteLine(reteDesc[i] + "Retenciones");


                            }*/

                            conexion.Close();

                            conexion.Open();
                            SqlCommand comandoCxc = new SqlCommand(cadenaCxc, conexion);
                            SqlDataReader registroCxc = comandoCxc.ExecuteReader();
                            if (registroCxc.Read())
                            {
                                dgv_FacturaCargada.Rows.Add(registroCxc["Cod_Cuenta"].ToString(), "Cta x Cobrar   Factura No. " + id[0] + "  " + clienteNombre[2], CtaXCobrar.ToString(), registroCxc["Tipo_Mov"].ToString());
                            }

                            conexion.Close();
                            tb_CFNoFactura.Text = id[0];
                            cb_CFTipoId.Text = TipoIdEmpresaFactura;
                            tb_CFNoId.Text = nit[1] + "-" + idscheme[1];
                            tb_CFFechaEmision.Text = date;
                            tb_CFNoIdClente.Text = nit[2] + "-" + idscheme[2];
                            cb_CFTipoIdCliente.Text = "NI";
                            label17.Text = "Info Factura para : " + clienteNombre[2];

                            conexion.Open();
                            string NombreEmpFact = "";
                            //
                            string NitEmpresaFact = "";
                            if (idschemeName[1] == Nit)
                            {
                                NitEmpresaFact = nit[1] + "-" + idscheme[1];
                            }
                            else
                            {
                                NitEmpresaFact = nit[1];

                            }

                            string NombreEmpresaFact = "select nom_terc from dbo.cm_terce where nit_clie='" + NitEmpresaFact + "'";

                            //string NombreEmpresaFact = "select nom_terc from dbo.cm_terce where nit_clie='" + nit[1] + "-" + idscheme[1] + "'";
                            SqlCommand comandNEF = new SqlCommand(NombreEmpresaFact, conexion);
                            SqlDataReader consultaNEF = comandNEF.ExecuteReader();
                            if (consultaNEF.Read())
                            {
                                NombreEmpFact = consultaNEF["nom_terc"].ToString();
                                conexion.Close();
                            }
                            else
                            {
                                MessageBox.Show("!2!");
                                conexion.Close();
                            }

                            conexion.Open();
                            string dataValidaccion = "select Id_Factura from dbo.fe_ComprobantesV2 where Id_Factura='" + id[0] + "'";
                            SqlCommand consulta = new SqlCommand(dataValidaccion, conexion);
                            SqlDataReader consultaArc = consulta.ExecuteReader();
                            if (consultaArc.Read())
                            {
                                MessageBox.Show("Este documento ya fue cargado");
                                conexion.Close();


                            }
                            else
                            {
                                conexion.Close();
                                conexion.Open();
                                int posicion=1;
                                for (i = 0; i < reteDesc.Length; i++)
                                {
                                    string dataComprobanteTributo = "insert into dbo.fe_ComprobantesTributos values(@Cod_arbo,@Id_Factura, @Consecutivo,@Id_Tributos, @Valor)";
                                    SqlCommand agregarTri = new SqlCommand(dataComprobanteTributo, conexion);

                                    if (!string.IsNullOrEmpty(reteDesc[i]) && (double.TryParse(rete[i], out double valorNumerico) && valorNumerico != 0) || reteDesc[i] == tributos[i])

                                    {
                                        agregarTri.Parameters.Clear();
                                                                           
                                        agregarTri.Parameters.AddWithValue("@Cod_arbo", cont);
                                        agregarTri.Parameters.AddWithValue("@Id_Factura", id[0]);
                                        agregarTri.Parameters.AddWithValue("@Consecutivo", posicion);
                                        agregarTri.Parameters.AddWithValue("@Id_Tributos", reteDesc[i]);
                                        agregarTri.Parameters.AddWithValue("@Valor", rete[i]);
                                       

                                        posicion++;

                                        agregarTri.ExecuteNonQuery();

                                    }

                                }
                                conexion.Close();

                              
                                conexion.Open();
                                // string dataComprobante = "insert into dbo.fe_ComprobantesV2 values(@Contabilidad, @Id_Factura, @TipoId_EmpFactura, @No_idEmpFactura, @TipoId_Cliente, @No_idCLiente, @fechaEmision, @Ingreso, @Iva, @Rte_Fte, @Rte_Iva, @Rte_Ica, @Cta_Cobrar, @Nom_EmpFact, @Nom_Cliente, @Estado)";
                                string dataComprobante = "insert into dbo.fe_ComprobantesV2 values(@Contabilidad, @Id_Factura, @TipoId_EmpFactura, @No_idEmpFactura, @TipoId_Cliente, @No_idCLiente, @FechaEmision,@Valor, @Estado)";

                                SqlCommand agregar = new SqlCommand(dataComprobante, conexion);
                                string tipoIdEmpresa = "";
                                string idEmpFactura = "";
                                //string idEmpFactura = nit[1] + "-" + idscheme[1];
                                //string idCliente = nit[2] + "-" + idscheme[2];
                                i = 0;
                                while (i < arrTipoIdentificacion.Length)
                                {
                                    if (idschemeName[1] == arrTipoIdentificacion[i])
                                    {
                                        tipoIdEmpresa = arrTipoIdentificacion[i - 1];
                                        idEmpFactura = nit[1] + "-" + idscheme[1];
                                    }
                                    if (tipoIdEmpresa == "")
                                    {
                                        tipoIdEmpresa = "OT";
                                        idEmpFactura = nit[1];
                                    }

                                    i++;
                                }

                                string tipoIdCliente = "";
                                string idCliente = "";
                                i = 0;
                                while (i < arrTipoIdentificacion.Length)
                                {
                                    if (idschemeName[2] == arrTipoIdentificacion[i])
                                    {
                                        tipoIdCliente = arrTipoIdentificacion[i - 1];
                                        idCliente = nit[2] + "-" + idscheme[2];
                                    }
                                    if (tipoIdCliente == "")
                                    {
                                        tipoIdCliente = "OT";
                                        idCliente = nit[1];
                                    }
                                    i++;
                                }

                                //i = 0;





                                agregar.Parameters.AddWithValue("@Contabilidad", cont);
                                agregar.Parameters.AddWithValue("@Id_Factura", id[0]);
                                agregar.Parameters.AddWithValue("@TipoId_EmpFactura", tipoIdEmpresa);
                                agregar.Parameters.AddWithValue("@No_idEmpFactura", idEmpFactura);
                                agregar.Parameters.AddWithValue("@TipoId_Cliente", tipoIdCliente);
                                agregar.Parameters.AddWithValue("@No_idCLiente", idCliente);
                                agregar.Parameters.AddWithValue("@FechaEmision", date);
                                /*agregar.Parameters.AddWithValue("@Ingreso", Vtotal[0]);
                                  agregar.Parameters.AddWithValue("@Iva", iva[1]); //I + IVA - RETESTOTALES 
                                  agregar.Parameters.AddWithValue("@Rte_Fte", rete[1]);
                                  agregar.Parameters.AddWithValue("@Rte_Iva", rete[2]);
                                  agregar.Parameters.AddWithValue("@Rte_Ica", rete[3]);
                                  agregar.Parameters.AddWithValue("@Cta_Cobrar", rete[7]);*/

                                //agregar.Parameters.AddWithValue("@IdTributo", rete[3]);
                                agregar.Parameters.AddWithValue("@Valor", TCreditos);


                                /* agregar.Parameters.AddWithValue("@Nom_EmpFact", NombreEmpFact);
                                 agregar.Parameters.AddWithValue("@Nom_Cliente", clienteNombre[2]);*/
                                agregar.Parameters.AddWithValue("@Estado", "Cargado");

                                agregar.ExecuteNonQuery();



                                MessageBox.Show("Factura cargada con exito!");
                                conexion.Close();
                            }
                        }

                        else if (registroCliente == false)
                        {
                            MessageBox.Show("El cliente no se encuentra registrado!");


                            conexion.Close();
                        }
                        else
                        {
                            MessageBox.Show("El cliente no tiene definido los parametros contables!");
                            conexion.Close();

                        }
                        cargaDg.cargaFC(dataGridView1, "Facturas");
                    }
                    else
                    {
                        MessageBox.Show("ERROR : La contabilidad Seleccionada no corresponde con esta factura");


                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una contabilidad!");
            }

        }

        /* Consultar Facturas */
        private void btn_FCConsultaFactura_Click(object sender, EventArgs e)
        {
            ConsultarDocumentos(dataGridView1, dgv_FCFacturasCargadas);

          /*  string IdFactura = this.dataGridView1.CurrentCell.Value.ToString();
            dgv_FCFacturasCargadas.Rows.Clear();
            bool validar;
            tb_FCIdFactura.Text = IdFactura;
            string idFactura = IdFactura;
            string[] facturaData = new string[99]; string[] facturaType = new string[99]; string[] facturaInfo = new string[99];
            conexion.Open();

            String cadenaInfoFactura = "Select Contabilidad,Id_Factura,TipoId_EmpFactura,No_idEmpFactura,TipoId_Cliente,No_idCLiente,FechaEmision from fe_comprobantesV2 where Id_Factura = '" + idFactura + "'";
            SqlCommand comandoInfo = new SqlCommand(cadenaInfoFactura, conexion);
            SqlDataReader registroInfo = comandoInfo.ExecuteReader();
            if (registroInfo.Read())
            {
                facturaInfo[1] = registroInfo["Contabilidad"].ToString();
                facturaInfo[2] = registroInfo["Id_Factura"].ToString();
                facturaInfo[3] = registroInfo["TipoId_EmpFactura"].ToString();
                facturaInfo[4] = registroInfo["No_idEmpFactura"].ToString();
                facturaInfo[5] = registroInfo["TipoId_Cliente"].ToString();
                facturaInfo[6] = registroInfo["No_idCLiente"].ToString();
                facturaInfo[7] = registroInfo["FechaEmision"].ToString();
                //validar = true;
            }
            else
            {
                MessageBox.Show("La Factura que esta buscando no existe!!");
                //validar = false;
            }
            registroInfo.Close();

            String Count = "select COUNT (*) from fe_ComprobantesTributos  where Id_Factura = '" + idFactura + "'";
            SqlCommand comandoCount = new SqlCommand(Count, conexion);
            Int32 totalDatos = (Int32)comandoCount.ExecuteScalar();
            // Console.WriteLine("Count");
            conexion.Close();


            conexion.Open();

            String cadenaInfoFacturaReten2 = "Select Id_Factura,Id_Tributos,Valor from fe_ComprobantesTributos where Id_Factura = '" + idFactura + "'";
            SqlCommand comandoInfoReten2 = new SqlCommand(cadenaInfoFacturaReten2, conexion);
            SqlDataReader registroInfoReten2 = comandoInfoReten2.ExecuteReader();
            int contadorInfo = 0;
            int arregloInfo = 8;





            while (registroInfoReten2.Read() && contadorInfo < totalDatos)
            {

                facturaInfo[arregloInfo] = registroInfoReten2["Id_Tributos"].ToString();

                arregloInfo++;
                facturaInfo[arregloInfo] = registroInfoReten2["Valor"].ToString();

                arregloInfo++;
                contadorInfo++;

            }


            validar = true;



            /*string cadenaInfoFactira = "select Contabilidad,Id_Factura,TipoId_EmpFactura,No_idEmpFactura,TipoId_Cliente,No_idCLiente,fechaEmision,Ingreso,Iva,Rte_Fte,Rte_Iva,Rte_Ica,Cta_Cobrar,Nom_EmpFact,Nom_Cliente from fe_comprobantes where Id_Factura = '" + idFactura + "'";
            SqlCommand comandoIF = new SqlCommand(cadenaInfoFactira, conexion);
            SqlDataReader registroIF = comandoIF.ExecuteReader();
            if (registroIF.Read())
            {
                facturaInfo[1] = registroIF["Contabilidad"].ToString();
                facturaInfo[2] = registroIF["Id_Factura"].ToString();
                facturaInfo[3] = registroIF["TipoId_EmpFactura"].ToString();
                facturaInfo[4] = registroIF["No_idEmpFactura"].ToString();
                facturaInfo[5] = registroIF["TipoId_Cliente"].ToString();
                facturaInfo[6] = registroIF["No_idCLiente"].ToString();

                facturaInfo[7] = registroIF["Ingreso"].ToString();
                facturaInfo[8] = registroIF["Iva"].ToString();
                facturaInfo[9] = registroIF["Rte_Fte"].ToString();
                facturaInfo[10] = registroIF["Rte_Iva"].ToString();
                facturaInfo[11] = registroIF["Rte_Ica"].ToString();
                facturaInfo[12] = registroIF["Cta_Cobrar"].ToString();
                facturaInfo[13] = registroIF["Nom_EmpFact"].ToString();
                facturaInfo[14] = registroIF["Nom_Cliente"].ToString();
                facturaInfo[16] = registroIF["fechaEmision"].ToString();

                validar = true;
            }
            else
            {
                MessageBox.Show("La Factura que esta buscando no existe!!");
                validar = false;
            }*/
           // conexion.Close();
            //String separator = facturaInfo[16];
        /*    String separator = facturaInfo[7];
            char[] limitador = { ' ' };
            string[] arreglo = separator.Split(limitador, StringSplitOptions.RemoveEmptyEntries);
            label21.Text = "Fecha Emision: " + arreglo[0];
            if (validar)
            {
                dataGridView1.Visible = false; dgv_FCFacturasCargadas.Visible = true; btn_FCVolver.Visible = true; btn_FCGuardarExcel.Visible = true;
                int cantidadCod = 0;
                conexion.Open();
                string cadenaCodigC = "select * from fe_ParametrosContables where No_IdCLiente = '" + facturaInfo[6] + "'";
                SqlCommand comandoCodigC = new SqlCommand(cadenaCodigC, conexion);
                SqlDataReader registroCodigC = comandoCodigC.ExecuteReader();
                while (registroCodigC.Read())
                {
                    facturaData[cantidadCod] = registroCodigC[3].ToString();
                    facturaType[cantidadCod] = registroCodigC[5].ToString();
                    cantidadCod++;
                }
                conexion.Close();
                conexion.Open();
                string cont = "";
                string cadenaConsultaArbol = "select des_arbo from dbo.gn_arbol where cod_arbo='" + facturaInfo[1] + "'";
                SqlCommand comandoCARBOL = new SqlCommand(cadenaConsultaArbol, conexion);
                SqlDataReader registroCArbol = comandoCARBOL.ExecuteReader();
                if (registroCArbol.Read())
                {
                    cont = registroCArbol["des_arbo"].ToString();
                }
                else
                {
                    MessageBox.Show("ERROR : La contabilidad seleccionada no existe!");
                }
                conexion.Close();
                string[] CodigoCuenta = new string[99];
                //Pr
                string[] NombreCuenta = new string[99];


                conexion.Open();
                string cadenaConsultaCodC = "select Cod_Cuenta,Tipo_Cuenta from fe_parametrosContables where No_IdCLiente='" + facturaInfo[6] + "' and Contabilidad ='" + facturaInfo[1] + "'";
                SqlCommand comandoCCodC = new SqlCommand(cadenaConsultaCodC, conexion);
                SqlDataReader registroCCodC = comandoCCodC.ExecuteReader();
                int i = 0;
                while (registroCCodC.Read())
                {
                    CodigoCuenta[i] = registroCCodC["Cod_Cuenta"].ToString();
                    NombreCuenta[i] = registroCCodC["Tipo_Cuenta"].ToString();
                    i++;
                }
                conexion.Close();
                dgv_FCFacturasCargadas.Rows.Clear();

                conexion.Open();
                string ConsultaTributo = "select * from  fe_Tributo ";
                SqlCommand comandoTributo = new SqlCommand(ConsultaTributo, conexion);
                SqlDataReader registroTributo = comandoTributo.ExecuteReader();
                string[] arrTributo = new string[99];
                int a = 0;
                while (registroTributo.Read())
                {
                    arrTributo[a] = registroTributo["Nom_Tributo"].ToString();
                    a++;
                }
             
                conexion.Close();

                conexion.Open();
                string cadenaConsT = "select Man_Trib from fe_parametrosContables where Contabilidad= '" + facturaInfo[1] + "' and TipoId_Cliente='" + facturaInfo[5] + "' and No_idCLiente='" + facturaInfo[6] + "'";
                SqlCommand comandoConsT = new SqlCommand(cadenaConsT, conexion);
                SqlDataReader registroConsT = comandoConsT.ExecuteReader();
                string[] NombreContabilidad = { "Ingreso", "IVA", "Rte.Fte", "Rte.Iva", "Rte.Ica", "Cta x Cobrar" };
                string[] parContVal = new string[99];
                int l = 0;
                while (registroConsT.Read())
                {

                    parContVal[l] = registroConsT["Man_Trib"].ToString();
                    l++;
                }
                for (int j = 0; j < NombreContabilidad.Length; j++)
                {
                    if (CodigoCuenta[j] != "")
                    {
                            for (int grd = 0; grd < facturaInfo.Length; grd++)
                            {
                                if (/*!string.IsNullOrEmpty(facturaInfo[grd]) && NombreContabilidad[j] == facturaInfo[grd])
                                {
                                    Console.WriteLine(arrTributo[j] + "...Grd...." + facturaInfo[grd+1]);

                                    dgv_FCFacturasCargadas.Rows.Add(cont, facturaInfo[4], facturaInfo[6], CodigoCuenta[j], NombreContabilidad[j], facturaInfo[grd +1], facturaType[j]);
                                }
                                /*if (arrTributo[j] == facturaInfo[grd])
                                {
                                    //Console.WriteLine("Paso al if");
                                    dgv_FCFacturasCargadas.Rows.Add(cont, facturaInfo[4], facturaInfo[6], CodigoCuenta[j], NombreContabilidad[j], facturaInfo[grd + 1], facturaType[j]);
                                }*/
                               /* else
                                {
                                    //Console.WriteLine("No paso");

                                }

                            }

                        

                        /* if (parContVal[j] == "T    ")
                         {
                             dgv_FCFacturasCargadas.Rows.Add(cont, facturaInfo[4], facturaInfo[6], CodigoCuenta[j], NombreContabilidad[j], facturaInfo[8 + j], facturaType[j]);
                         }
                         else
                         {
                             dgv_FCFacturasCargadas.Rows.Add(cont, facturaInfo[4], "", CodigoCuenta[j], NombreContabilidad[j], facturaInfo[8 + j], facturaType[j]);
                         }*/
                  /*  }
                }

                btn_FCGenerarComprobante.Visible = true; label21.Visible = true;
            }
            else
            {

            }
            conexion.Close();*/
        }
      
        private void btn_FCVolver_Click(object sender, EventArgs e)
        {
            btnVolver(dataGridView1, dgv_FCFacturasCargadas, btn_FCVolver, btn_FCGuardarExcel, btn_FCGenerarComprobante, tb_FCIdFactura, label21,"Facturas");
                       
        }
        //Generar comprobante
        private void btn_FCGenerarComprobante_Click(object sender, EventArgs e)
        {
            string columna = "Facturas" ;
            generarComprobantes(columna, tb_FCIdFactura.Text);

            /*string[] MovNo = new string[99]; string[] MovType = new string[99]; string[] facturaInfo = new string[99];
            string[] TipoCuen = new string[99]; string estadoFactura = ""; string[] TipoCuenta = new string[99];

            //Busca la Informacion de la Factura en la Base de datos usando el ID de la Factura
            conexion.Open();


            String cadenaInfoFactura = "Select Contabilidad,Id_Factura,TipoId_EmpFactura,No_idEmpFactura,TipoId_Cliente,No_idCLiente,FechaEmision,Estado from fe_comprobantesV2 where Id_Factura = '" + tb_FCIdFactura.Text + "'";
            SqlCommand comandoInfo = new SqlCommand(cadenaInfoFactura, conexion);
            SqlDataReader registroInfo = comandoInfo.ExecuteReader();
            if (registroInfo.Read())
            {
                facturaInfo[1] = registroInfo["Contabilidad"].ToString();
                facturaInfo[2] = registroInfo["Id_Factura"].ToString();
                facturaInfo[3] = registroInfo["TipoId_EmpFactura"].ToString();
                facturaInfo[4] = registroInfo["No_idEmpFactura"].ToString();
                facturaInfo[5] = registroInfo["TipoId_Cliente"].ToString();
                facturaInfo[6] = registroInfo["No_idCLiente"].ToString();
                facturaInfo[7] = registroInfo["FechaEmision"].ToString();
                estadoFactura = registroInfo["Estado"].ToString();
                //validar = true;
            }
            else
            {
                MessageBox.Show("La factura que esta Exportando No Existe!!");
                //validar = false;
            }
            registroInfo.Close();


            String Count = "select COUNT (*) from fe_ComprobantesTributos  where Id_Factura = '" + tb_FCIdFactura.Text + "'";
            SqlCommand comandoCount = new SqlCommand(Count, conexion);
            Int32 totalDatos = (Int32)comandoCount.ExecuteScalar();
            conexion.Close();


            conexion.Open();

            String cadenaInfoFacturaReten2 = "Select Id_Factura,Id_Tributos,Valor from fe_ComprobantesTributos where Id_Factura = '" + tb_FCIdFactura.Text + "'";
            SqlCommand comandoInfoReten2 = new SqlCommand(cadenaInfoFacturaReten2, conexion);
            SqlDataReader registroInfoReten2 = comandoInfoReten2.ExecuteReader();
            int contadorInfo = 0;
            int arregloInfo = 10;

            while (registroInfoReten2.Read() && contadorInfo < totalDatos)
            {
                facturaInfo[arregloInfo] = registroInfoReten2["Id_Tributos"].ToString();
                arregloInfo++;
                facturaInfo[arregloInfo] = registroInfoReten2["Valor"].ToString();
                arregloInfo++;
                contadorInfo++;

            }


            /* string cadenaInfoFactira = "select Contabilidad,Id_Factura,TipoId_EmpFactura,No_idEmpFactura,TipoId_Cliente,No_idCLiente,fechaEmision,Ingreso,Iva,Rte_Fte,Rte_Iva,Rte_Ica,Cta_Cobrar,Nom_EmpFact,Nom_Cliente,Estado from fe_comprobantes where Id_Factura = '" + tb_FCIdFactura.Text + "'";
             SqlCommand comandoIF = new SqlCommand(cadenaInfoFactira, conexion);
             SqlDataReader registroIF = comandoIF.ExecuteReader();
             if (registroIF.Read())
             {
                 facturaInfo[1] = registroIF["Contabilidad"].ToString();
                 facturaInfo[2] = registroIF["Id_Factura"].ToString();
                 facturaInfo[3] = registroIF["TipoId_EmpFactura"].ToString();
                 facturaInfo[4] = registroIF["No_idEmpFactura"].ToString();
                 facturaInfo[5] = registroIF["TipoId_Cliente"].ToString();
                 facturaInfo[6] = registroIF["No_idCLiente"].ToString();

                 facturaInfo[7] = registroIF["Ingreso"].ToString();
                 facturaInfo[8] = registroIF["Iva"].ToString();
                 facturaInfo[9] = registroIF["Rte_Fte"].ToString();
                 facturaInfo[10] = registroIF["Rte_Iva"].ToString();
                 facturaInfo[11] = registroIF["Rte_Ica"].ToString();
                 facturaInfo[12] = registroIF["Cta_Cobrar"].ToString();
                 facturaInfo[13] = registroIF["Nom_EmpFact"].ToString();
                 facturaInfo[14] = registroIF["Nom_Cliente"].ToString();
                 facturaInfo[16] = registroIF["fechaEmision"].ToString();
                 estadoFactura = registroIF["Estado"].ToString();
             }
             else
             {
                 MessageBox.Show("La factura que esta Exportando No Existe!!");
             */
            /*conexion.Close();
            if (estadoFactura == "Exportado")
            {
                MessageBox.Show("La factura: " + facturaInfo[2] + " Ya se encuentra Exportada.");
            }
            else
            {
                facturaInfo[7] = facturaInfo[7].Replace("/", "-");
                //facturaInfo[16] = facturaInfo[16].Replace("/", "-");
                DateTime FechaFactura = Convert.ToDateTime(facturaInfo[7]);
                //DateTime FechaFactura = Convert.ToDateTime(facturaInfo[16]);

                // Consulta a PC "Parametros Contables" Para encontrar el Tipo de Movimiento de las cuentas Contables
                conexion.Open();
                string cadenaConsultaPC = "select Tipo_Mov,Cod_Cuenta,Man_Trib, Tipo_Cuenta from fe_ParametrosContables where Contabilidad = '" + facturaInfo[1] + "' and No_idCLiente ='" + facturaInfo[6] + "'";
                SqlCommand comandoConsultaPC = new SqlCommand(cadenaConsultaPC, conexion);
                SqlDataReader registroConsultaPC = comandoConsultaPC.ExecuteReader();
                
                int i = 0;
                while (registroConsultaPC.Read())
                {
                    MovType[i] = (registroConsultaPC[0].ToString());
                    MovNo[i] = (registroConsultaPC[1].ToString());
                    TipoCuen[i] = (registroConsultaPC[2].ToString());
                    TipoCuenta[i]= (registroConsultaPC[3].ToString());
                    i++;

                }

                conexion.Close();
               
                //Suma de parametros Contables por tipo
                double TotalCreditos = 0; double TotalDebitos = 0;


                int a = -1;
                    for (int j = 0; j <12; j++)
                    {

                    string valorFactura = facturaInfo[10 + j]; 
                    if (double.TryParse(valorFactura, out double credito))
                    {
                        a = a + 1;
                        if (MovType[a] == "C")
                        {

                            TotalCreditos = TotalCreditos + credito;

                            // TotalCreditos = TotalCreditos + double.Parse(valorFactura);

                        }
                        else if (MovType[a] == "D" )
                        {
                            //TotalDebitos = TotalDebitos + double.Parse(valorFactura);
                            TotalDebitos = TotalDebitos + credito;

                        }

                        else
                        {
                            Console.WriteLine(double.Parse(facturaInfo[10 + j]));

                        }
                    }
                    
                        
                }
                //Consulta a PG "Parametros Generales" Para encontrar el Tipo de Comprobante
                conexion.Open();
               
                string cadenaTipoFactura = "select Facturas from fe_ParametrosGenerales where NoId = '" + facturaInfo[4] + "' and Contabilidad = '" + facturaInfo[1] + "'";
                SqlCommand comandoTF = new SqlCommand(cadenaTipoFactura, conexion);
                SqlDataReader registroTF = comandoTF.ExecuteReader();
                if (registroTF.Read())
                {
                    facturaInfo[8] = registroTF["Facturas"].ToString();
                 
                }


                conexion.Close();
                //if 
                conexion.Open();

                string cadenaNumCons = "select num_cons from gn_conse where cod_arbo = '" + facturaInfo[1] + "' and cod_cons = '" + facturaInfo[8] + "'";
                SqlCommand comandoNumCons = new SqlCommand(cadenaNumCons, conexion);
                SqlDataReader registroNumCons = comandoNumCons.ExecuteReader();
                if (registroNumCons.Read())
                {
                    facturaInfo[9] = registroNumCons["num_cons"].ToString();

                }

                conexion.Close();
                //if

                conexion.Open();
                string cadenaInsertarCmMoc = "insert into cm_movim values(@cod_arbo, @tip_comp, @num_comp, @fec_movi, @tot_movi,@est_movi ,@mov_gest, @est_guard, @Val_Girar, NULL,NULL, NULL,NULL)";
                SqlCommand agregarCmMoc = new SqlCommand(cadenaInsertarCmMoc, conexion);

                agregarCmMoc.Parameters.AddWithValue("@cod_arbo", int.Parse(facturaInfo[1]));
                agregarCmMoc.Parameters.AddWithValue("@tip_comp", facturaInfo[8]);
                agregarCmMoc.Parameters.AddWithValue("@num_comp", int.Parse(facturaInfo[9]));
                agregarCmMoc.Parameters.AddWithValue("@fec_movi", FechaFactura);
                agregarCmMoc.Parameters.AddWithValue("@tot_movi", TotalDebitos);

                agregarCmMoc.Parameters.AddWithValue("@est_movi", "S");
                agregarCmMoc.Parameters.AddWithValue("@mov_gest", "CT");
                agregarCmMoc.Parameters.AddWithValue("@est_guard", "S");
                agregarCmMoc.Parameters.AddWithValue("@Val_Girar", 0);

                agregarCmMoc.ExecuteNonQuery();
                //error
                conexion.Close();

                conexion.Open();
                string ConsultaTributo = "select * from  fe_Tributo ";
                SqlCommand comandoTributo = new SqlCommand(ConsultaTributo, conexion);
                SqlDataReader registroTributo = comandoTributo.ExecuteReader();
                string[] arrTributo = new string[99];
                a = 0;
                while (registroTributo.Read())
                {
                    arrTributo[a] = registroTributo["Nom_Tributo"].ToString();
                    a++;

                }
              

                conexion.Close();
                string[] NombreContabilidad = { "Ingreso", "IVA", "Rte.Fte", "Rte.Iva", "Rte.Ica", "Cta x Cobrar" };
                int position = 1;
                for (int x = 0; x < TipoCuenta.Length; x++)
                {
                    if (MovType[x] != "")
                    {
                        for (i = 0; i < facturaInfo.Length; i++)
                        {
                         
                            if (TipoCuen[x] == "T    " && TipoCuenta[x] == facturaInfo[i] && !string.IsNullOrWhiteSpace(TipoCuenta[x]))
                            {

                                conexion.Open();
                                string cadenaInsertarCwMoc = "insert into cw_movim values(@cod_arbo, @tip_comp, @num_comp, @cod_cuen, @rmt_cumo,@nit_clie,@tip_iden,NULL ,@des_deta,NULL ,@vlr_movi, @tip_movi, @bas_rete, NULL,@Cod_Usua)";
                                //  string codCuent="select cod_cuent from cw_movim";

                                SqlCommand agregarCwMoc = new SqlCommand(cadenaInsertarCwMoc, conexion);
                             
                                agregarCwMoc.Parameters.AddWithValue("@cod_arbo", int.Parse(facturaInfo[1]));
                                agregarCwMoc.Parameters.AddWithValue("@tip_comp", facturaInfo[8]);
                                agregarCwMoc.Parameters.AddWithValue("@num_comp", int.Parse(facturaInfo[9]));
                                agregarCwMoc.Parameters.AddWithValue("@cod_cuen", MovNo[x]);
                                agregarCwMoc.Parameters.AddWithValue("@rmt_cumo", position);
                                agregarCwMoc.Parameters.AddWithValue("@des_deta", "Fra. " + facturaInfo[2] + " " + facturaInfo[i] + " De Cliente: " + facturaInfo[6]);
                                agregarCwMoc.Parameters.AddWithValue("@vlr_movi", double.Parse(facturaInfo[i+1]));
                                agregarCwMoc.Parameters.AddWithValue("@tip_movi", MovType[x]);
                                agregarCwMoc.Parameters.AddWithValue("@bas_rete", 0);
                                agregarCwMoc.Parameters.AddWithValue("@Cod_Usua", "JRIVERA");
                                agregarCwMoc.Parameters.AddWithValue("@nit_clie", facturaInfo[6]);
                                agregarCwMoc.Parameters.AddWithValue("@tip_iden", facturaInfo[5]);

                                agregarCwMoc.ExecuteNonQuery();
                                conexion.Close();
                                position++;


                                

                            }
                            else if (TipoCuenta[x] == facturaInfo[i] && !string.IsNullOrWhiteSpace(TipoCuenta[x]))
                            {

                                conexion.Open();
                                string cadenaInsertarCwMoc = "insert into cw_movim values(@cod_arbo, @tip_comp, @num_comp, @cod_cuen, @rmt_cumo,NULL ,NULL ,NULL ,@des_deta,NULL ,@vlr_movi, @tip_movi, @bas_rete, NULL,@Cod_Usua)";
                                SqlCommand agregarCwMoc = new SqlCommand(cadenaInsertarCwMoc, conexion);

                                agregarCwMoc.Parameters.AddWithValue("@cod_arbo", int.Parse(facturaInfo[1]));
                                agregarCwMoc.Parameters.AddWithValue("@tip_comp", facturaInfo[8]);
                                agregarCwMoc.Parameters.AddWithValue("@num_comp", int.Parse(facturaInfo[9]));
                                agregarCwMoc.Parameters.AddWithValue("@cod_cuen", MovNo[x]);
                                agregarCwMoc.Parameters.AddWithValue("@rmt_cumo", position);
                                agregarCwMoc.Parameters.AddWithValue("@des_deta", "Fra. " + facturaInfo[2] + " " + facturaInfo[i] + " De Cliente: " + facturaInfo[6]);
                                agregarCwMoc.Parameters.AddWithValue("@vlr_movi", double.Parse(facturaInfo[i+1]));
                                agregarCwMoc.Parameters.AddWithValue("@tip_movi", MovType[x]);
                                agregarCwMoc.Parameters.AddWithValue("@bas_rete", 0);
                                agregarCwMoc.Parameters.AddWithValue("@Cod_Usua", "JRIVERA");

                                agregarCwMoc.ExecuteNonQuery();
                                conexion.Close();
                                position++;


                            }
                            else
                            {

                            }

                        }
                      
                       
                    }
                    else
                    {
                        MessageBox.Show("Agregar cuenta");

                    }
                }
                MessageBox.Show("Registro Exitoso No: " + (int.Parse(facturaInfo[9])) + " .");

                dataGridView1.Visible = true; dgv_FCFacturasCargadas.Visible = false; btn_FCVolver.Visible = false; btn_FCGuardarExcel.Visible = false;
                btn_FCGenerarComprobante.Visible = false; tb_FCIdFactura.Text = ""; label21.Visible = false;

                int conv = int.Parse(facturaInfo[9]);
                conexion.Open();
                string update = "update gn_conse set num_cons='" + (conv + 1) + "' where cod_arbo ='" + facturaInfo[1] + "' and cod_cons ='" + facturaInfo[8] + "'";
                SqlCommand actualizar = new SqlCommand(update, conexion);
                actualizar.ExecuteNonQuery();
                conexion.Close();

                conexion.Open();
                string insert = "update fe_comprobantesV2 set Estado='Exportado' where Id_Factura ='" + facturaInfo[2] + "'";
                SqlCommand agregar = new SqlCommand(insert, conexion);
                agregar.ExecuteNonQuery();
                conexion.Close();

                dataGridView1.Rows.Clear();
                cargaDg.cargaFC(dataGridView1);

            }*/

        }
        //Boton Generar excel
        private void btn_FCGuardarExcel_Click(object sender, EventArgs e)
        {
            string[] facturaData = new string[99]; string[] facturaType = new string[99]; string[] facturaInfo = new string[99];
            conexion.Open();
            String cadenaInfoFactura = "Select Contabilidad,Id_Factura,TipoId_EmpFactura,No_idEmpFactura,TipoId_Cliente,No_idCLiente,FechaEmision from fe_comprobantesV2 where Id_Factura = '" + tb_FCIdFactura.Text + "'";
            SqlCommand comandoInfo = new SqlCommand(cadenaInfoFactura, conexion);
            SqlDataReader registroInfo = comandoInfo.ExecuteReader();
            if (registroInfo.Read())
            {
                facturaInfo[1] = registroInfo["Contabilidad"].ToString();
                facturaInfo[2] = registroInfo["Id_Factura"].ToString();
                facturaInfo[3] = registroInfo["TipoId_EmpFactura"].ToString();
                facturaInfo[4] = registroInfo["No_idEmpFactura"].ToString();
                facturaInfo[5] = registroInfo["TipoId_Cliente"].ToString();
                facturaInfo[6] = registroInfo["No_idCLiente"].ToString();
                facturaInfo[7] = registroInfo["FechaEmision"].ToString();
                //validar = true;
            }
            else
            {
                MessageBox.Show("La factura que esta Exportando No Existe!!");
                //validar = false;
            }
            registroInfo.Close();

            String Count = "select COUNT (*) from fe_ComprobantesTributos  where Id_Factura = '" + tb_FCIdFactura.Text + "'";
            SqlCommand comandoCount = new SqlCommand(Count, conexion);
            Int32 totalDatos = (Int32)comandoCount.ExecuteScalar();
            conexion.Close();


            conexion.Open();

            String cadenaInfoFacturaReten2 = "Select Id_Factura,Id_Tributos,Valor from fe_ComprobantesTributos where Id_Factura = '" + tb_FCIdFactura.Text + "'";
            SqlCommand comandoInfoReten2 = new SqlCommand(cadenaInfoFacturaReten2, conexion);
            SqlDataReader registroInfoReten2 = comandoInfoReten2.ExecuteReader();
            int contadorInfo = 0;
            int arregloInfo = 10;





            while (registroInfoReten2.Read() && contadorInfo < totalDatos)
            {

                facturaInfo[arregloInfo] = registroInfoReten2["Id_Tributos"].ToString();

                arregloInfo++;

                facturaInfo[arregloInfo] = registroInfoReten2["Valor"].ToString();
                arregloInfo++;
                contadorInfo++;

            }

            /* string cadenaInfoFactira = "select Contabilidad,Id_Factura,TipoId_EmpFactura,No_idEmpFactura,TipoId_Cliente,No_idCLiente,fechaEmision,Ingreso,Iva,Rte_Fte,Rte_Iva,Rte_Ica,Cta_Cobrar,Nom_EmpFact,Nom_Cliente from fe_comprobantes where Id_Factura = '" + tb_FCIdFactura.Text + "'";
             SqlCommand comandoIF = new SqlCommand(cadenaInfoFactira, conexion);
             SqlDataReader registroIF = comandoIF.ExecuteReader();
             if (registroIF.Read())
             {
                 facturaInfo[1] = registroIF["Contabilidad"].ToString();
                 facturaInfo[2] = registroIF["Id_Factura"].ToString();
                 facturaInfo[3] = registroIF["TipoId_EmpFactura"].ToString();
                 facturaInfo[4] = registroIF["No_idEmpFactura"].ToString();
                 facturaInfo[5] = registroIF["TipoId_Cliente"].ToString();
                 facturaInfo[6] = registroIF["No_idCLiente"].ToString();

                 facturaInfo[7] = registroIF["Ingreso"].ToString();
                 facturaInfo[8] = registroIF["Iva"].ToString();
                 facturaInfo[9] = registroIF["Rte_Fte"].ToString();
                 facturaInfo[10] = registroIF["Rte_Iva"].ToString();
                 facturaInfo[11] = registroIF["Rte_Ica"].ToString();
                 facturaInfo[12] = registroIF["Cta_Cobrar"].ToString();
                 facturaInfo[13] = registroIF["Nom_EmpFact"].ToString();
                 facturaInfo[14] = registroIF["Nom_Cliente"].ToString();
                 facturaInfo[16] = registroIF["fechaEmision"].ToString();
             }
             else
             {
                 MessageBox.Show("La Factura que esta Buscando No Existe!!");
             }*/
            conexion.Close();

            conexion.Open();
            string cadenaTipoFactura = "select Facturas from fe_ParametrosGenerales where NoId = '" + facturaInfo[4] + "' and Contabilidad = '" + facturaInfo[1] + "'";
            SqlCommand comandoTF = new SqlCommand(cadenaTipoFactura, conexion);
            SqlDataReader registroTF = comandoTF.ExecuteReader();
            if (registroTF.Read())
            {
                facturaInfo[8] = registroTF["Facturas"].ToString();
            }

            conexion.Close();

            conexion.Open();
            string cadenaNumCons = "select num_cons from gn_conse where cod_arbo = '" + facturaInfo[1] + "' and cod_cons = '" + facturaInfo[8] + "'";
            SqlCommand comandoNumCons = new SqlCommand(cadenaNumCons, conexion);
            SqlDataReader registroNumCons = comandoNumCons.ExecuteReader();
            if (registroNumCons.Read())
            {
                facturaInfo[9] = registroNumCons["num_cons"].ToString();
            }

            conexion.Close();

            int cantidadCod = 0;
            conexion.Open();
            string cadenaCodigC = "select * from fe_ParametrosContables where No_IdCLiente = '" + facturaInfo[6] + "'";
            SqlCommand comandoCodigC = new SqlCommand(cadenaCodigC, conexion);
            SqlDataReader registroCodigC = comandoCodigC.ExecuteReader();
            while (registroCodigC.Read())
            {
                facturaData[cantidadCod] = registroCodigC[3].ToString();
                facturaType[cantidadCod] = registroCodigC[5].ToString();
                cantidadCod++;
            }
            conexion.Close();
            string[] TipoCuen = new string[99];
            for (int i = 0; i < 6; i++)
            {
                conexion.Open();
                string cadenaCIC = "select cod_cuen,man_trib from dbo.cm_cuent where cod_cuen='" + facturaData[i] + "'";
                SqlCommand leerCIC = new SqlCommand(cadenaCIC, conexion);
                SqlDataReader registroCIC = leerCIC.ExecuteReader();
                if (registroCIC.Read())
                {
                    TipoCuen[i] = registroCIC["man_trib"].ToString();
                }
                conexion.Close();
            }

            bool validarCodigos = true; int movimiento = 0;

            for (int i = 0; i < 6; i++)
            {
                int position = i + 7;
                if (facturaData[i] == "" && facturaInfo[position] != "0.00")
                {
                    validarCodigos = false;
                    movimiento = i;
                    MessageBox.Show(facturaData[i] + " " + facturaInfo[position]);
                }
            }

            if (validarCodigos)
            {
                string ruta = "./Plantilla.xlsx";
                SLDocument sl = new SLDocument(ruta);

                System.Data.DataTable dt = new System.Data.DataTable();
                int CargarDataExcel = 0; int positionDataExcel = 1;
                string[] NombreContabilidad = { "Ingreso", "IVA", "Rte.Fte", "Rte.Iva", "Rte.Ica", "Cta x Cobrar", "" };
                for (int i = 0; i < NombreContabilidad.Length; i++)
                {

                    for (int j = 0; j < facturaInfo.Length; j++)
                    {
                      
                        if (NombreContabilidad[i] == facturaInfo[j])
                        {
                            sl.SetCellValue("A" + positionDataExcel, facturaInfo[8]);
                            sl.SetCellValue("B" + positionDataExcel, int.Parse(facturaInfo[9]));
                            sl.SetCellValue("C" + positionDataExcel, DateTime.Parse(facturaInfo[7]));
                            sl.SetCellValue("D" + positionDataExcel, long.Parse(facturaData[0 + i]));
                            if (TipoCuen[0 + i] == "T")
                            {
                                sl.SetCellValue("E" + positionDataExcel, facturaInfo[6]);
                                sl.SetCellValue("F" + positionDataExcel, facturaInfo[5]);
                            }
                            sl.SetCellValue("H" + positionDataExcel, NombreContabilidad[i] + " FACTURA No. " + facturaInfo[2] + " " + facturaInfo[6]);
                            sl.SetCellValue("J" + positionDataExcel, double.Parse(facturaInfo[j + 1]));
                            sl.SetCellValue("K" + positionDataExcel, facturaType[0 + i]);
                            CargarDataExcel++; positionDataExcel++;
                        }
                    }

                }

                SaveFileDialog guarda = new SaveFileDialog();
                guarda.Filter = "Libro de Excel|*.xlsx";
                guarda.Title = "Guardar Reporte";
                guarda.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                if (guarda.ShowDialog() == DialogResult.OK)
                {
                    sl.SaveAs(guarda.FileName);
                    MessageBox.Show("Archivo Guardado");
                }
            }
            else
            {
                MessageBox.Show("ERROR: La factura tiene Movimientos que Faltan en parametros contables");
            }
            Console.WriteLine("5");
        }
        //Filtros busqueda de documentos
        private void btn_FCFiltro_Click(object sender, EventArgs e)
        {
            string contabilidad = "";

            conexion.Open();
            SqlCommand comandoConta = new SqlCommand("select cod_arbo from dbo.gn_arbol where des_arbo ='" + cb_FCEmpresaFactura.Text + "'", conexion);
            SqlDataReader leerConta = comandoConta.ExecuteReader();
            if (leerConta.Read())
            {
                contabilidad = leerConta["cod_arbo"].ToString();
            }
            conexion.Close();

            if (cb_FCEstado.Text == "Seleccione un Item..." && cb_FCEmpresaFactura.Text == "Seleccione un Item...")
            {
                cargaDg.cargaFC(dataGridView1, "Facturas");
            }
            if (cb_FCEstado.Text != "Seleccione un Item..." && cb_FCEmpresaFactura.Text == "Seleccione un Item...")
            {
                dataGridView1.Rows.Clear();
                conexion.Open();
                SqlCommand cmd = new SqlCommand("select * from fe_comprobantesV2 where Estado ='" + cb_FCEstado.Text + "'", conexion);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr[2].ToString(), dr[1].ToString(), dr[4].ToString(), dr[6].ToString(), dr[7].ToString(), dr[9].ToString());
                   // dataGridView1.Rows.Add(dr[1].ToString(), dr[0].ToString(), dr[13].ToString(), dr[14].ToString(), dr[6].ToString(), dr[15].ToString());

                }
                conexion.Close();
            }
            if (cb_FCEstado.Text == "Seleccione un Item..." && cb_FCEmpresaFactura.Text != "Seleccione un Item...")
            {
                dataGridView1.Rows.Clear();
                conexion.Open();
                SqlCommand cmd = new SqlCommand("select * from fe_comprobantesV2 where Contabilidad ='" + contabilidad + "'", conexion);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr[2].ToString(), dr[1].ToString(), dr[4].ToString(), dr[6].ToString(), dr[7].ToString(), dr[9].ToString());
                    //dataGridView1.Rows.Add(dr[1].ToString(), dr[0].ToString(), dr[13].ToString(), dr[14].ToString(), dr[6].ToString(), dr[15].ToString());
                }
                conexion.Close();
            }
            if (cb_FCEstado.Text != "Seleccione un Item..." && cb_FCEmpresaFactura.Text != "Seleccione un Item...")
            {
                dataGridView1.Rows.Clear();
                conexion.Open();
                SqlCommand cmd = new SqlCommand("select * from fe_comprobantesV2 where Contabilidad ='" + contabilidad + "' and Estado ='" + cb_FCEstado.Text + "'", conexion);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr[2].ToString(), dr[1].ToString(), dr[4].ToString(), dr[6].ToString(), dr[7].ToString(), dr[9].ToString());

                   // dataGridView1.Rows.Add(dr[1].ToString(), dr[0].ToString(), dr[13].ToString(), dr[14].ToString(), dr[6].ToString(), dr[15].ToString());
                }
                conexion.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        //Tributo
        private void btnGuardarTributo_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string nombre = tbNombreTributo.Text; string id = tbIdentificadorTrib.Text; string cont = " ";
            string cadenaConsultaTributo = "select identificador from dbo.fe_Tributo where identificador='" + id + "'";
            SqlCommand comandoTributo = new SqlCommand(cadenaConsultaTributo, conexion);
            SqlDataReader registroTributo = comandoTributo.ExecuteReader();
            if (registroTributo.Read())
            {
                MessageBox.Show("ERROR :El tributo ya se encuentra registrado!");
                conexion.Close();

            }
            else
            {
                conexion.Close();

                conexion.Open();
                string insertTri = "insert into fe_Tributo values (@Nom_Tributo,@identificador)";
                SqlCommand agregar = new SqlCommand(insertTri, conexion);
                agregar.Parameters.AddWithValue("@Nom_Tributo", nombre);
                agregar.Parameters.AddWithValue("@identificador", id);
                agregar.ExecuteNonQuery();
                conexion.Close();
                tbNombreTributo.Text = "";
                tbIdentificadorTrib.Text = "";


                dataGridTributo.Rows.Clear();
                cargaDg.cargaTri(dataGridTributo);

            }

        }

        private void btnActualizarTributo_Click(object sender, EventArgs e)
        {
            Form formulario1 = new FormEditTribute();
            formulario1.Show();
            dataGridTributo.Rows.Clear();

        }
        private void pBActualizar_Click(object sender, EventArgs e)
        {
            dataGridTributo.Rows.Clear();
            cargaDg.cargaTri(dataGridTributo);
        }
        private void cb_FCEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tp_Tributos_Click(object sender, EventArgs e)
        {

        }

        private void dataGridTipoIdentificación_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click_1(object sender, EventArgs e)
        {

        }

        private void tp_TipoIdentificacion_Click(object sender, EventArgs e)
        {

        }
        //Tipo Identificacion
        private void btnAgregarIden_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string Descripcion = tbTipoIdentificación.Text; string id = tbCodigoIdentificación.Text;
            string cadenaConsultaTipIden = "select Codigo_Dian from dbo.fe_TipoIden where Codigo_Dian='" + id + "'";
            SqlCommand comandoTributo = new SqlCommand(cadenaConsultaTipIden, conexion);
            SqlDataReader registroTributo = comandoTributo.ExecuteReader();
            if (registroTributo.Read())
            {
                MessageBox.Show("ERROR :El tipo de identificación ya se encuentra registrado!");
                conexion.Close();

            }
            else
            {
                conexion.Close();

                conexion.Open();
                string insertTipIdent = "insert into fe_TipoIden values (@Tip_Iden,@Codigo_Dian)";
                SqlCommand agregar = new SqlCommand(insertTipIdent, conexion);
                agregar.Parameters.AddWithValue("@Tip_Iden", Descripcion);
                agregar.Parameters.AddWithValue("@Codigo_Dian", id);
                agregar.ExecuteNonQuery();
                conexion.Close();
                tbTipoIdentificación.Text = "";
                tbCodigoIdentificación.Text = "";


                dataGridTipoIdentificación.Rows.Clear();
                cargaDg.cargaIdentificacion(dataGridTipoIdentificación);

            }

        }

        private void btnActualizarIden_Click(object sender, EventArgs e)
        {
            Form formulario1 = new FormEditTipIden();
            formulario1.Show();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            dataGridTipoIdentificación.Rows.Clear();
            cargaDg.cargaIdentificacion(dataGridTipoIdentificación);


        }

    
        /*Nota Credito*/
        private void btn_BuscarDocumentoNC_Click(object sender, EventArgs e)
        {
            string consultas = "Tipo_MovNC";
            CargarDocumentos(cb_ContabilidadND.Text, consultas, dgv_NotaCreditoCargada);
        }
        private void btn_ComprobanteNC_Click(object sender, EventArgs e)
        {
            string columna = "Nota_Credito";
            generarComprobantes(columna, tb_IdNC.Text);

        }
        private void btn_ConsultaNC_Click(object sender, EventArgs e)
        {
            ConsultarDocumentos(dgv_FondoNC, dgv_NcCargadas);
        }
        private void btn_VolverNC_Click(object sender, EventArgs e)
        {
            btnVolver(dgv_FondoNC, dgv_NcCargadas, btn_VolverNC, btn_ExcelNC, btn_ComprobanteNC, tb_IdNC, lbl_FechaNC, "Nota_Credito");

        }

        private void tp_CargarFactura_Click(object sender, EventArgs e)
        {

        }
        //Nota Debito
        private void btn_BuscarDocumentoND_Click(object sender, EventArgs e)
        {
            string consultas = "Tipo_MovND";
            CargarDocumentos(cb_ContabilidadND.Text, consultas, dgv_NotaDebitoCargada);
           
        }


        private void btn_GenerarComprobanteND_Click(object sender, EventArgs e)
        {
            string columna = "Nota_Debito";
            generarComprobantes(columna, tb_IdND.Text);
        }
              
        private void btn_ConsultaND_Click(object sender, EventArgs e)
        {
            ConsultarDocumentos(dgv_FondoND, dgv_NdCargadas);
        }
        private void btn_VolverND_Click(object sender, EventArgs e)
        {
            btnVolver(dgv_FondoND, dgv_NdCargadas, btn_VolverND, btn_GuardarExcelND, btn_GenerarComprobanteND, tb_IdND, lbl_FechaND, "Nota_Dedito");
        }

        //Clases
        private void CargarDocumentos(string cb,string ConTipoMov, DataGridView dgv)
        {
        
           if (cb != "Seleccione un Item...")
           {
              conexion.Open();
              string cont = " ";
          
           string cadenaConsultaArbol = "select cod_arbo from dbo.gn_arbol where des_arbo='" + cb + "'";
           SqlCommand comandoCARBOL = new SqlCommand(cadenaConsultaArbol, conexion);
           SqlDataReader registroCArbol = comandoCARBOL.ExecuteReader();
              if (registroCArbol.Read())
              {
                  cont = registroCArbol["cod_arbo"].ToString();
              }
              else
              {
                   MessageBox.Show("ERROR : La contabilidad seleccionada no existe!");
              }
           conexion.Close();
           conexion.Open();
           string NoEmpresaFactura = ""; string TipoIdEmpresaFactura = "";
           string cadenaConsultaEF = "select NoId,TipoId from fe_ParametrosGenerales where Contabilidad='" + cont + "'";
           SqlCommand comandoCEF = new SqlCommand(cadenaConsultaEF, conexion);
           SqlDataReader registroCEF = comandoCEF.ExecuteReader();
           if (registroCEF.Read())
           {
               NoEmpresaFactura = registroCEF["NoId"].ToString();
           TipoIdEmpresaFactura = registroCEF["TipoId"].ToString();
           Console.WriteLine(NoEmpresaFactura + ",,,,,,," + TipoIdEmpresaFactura);
           }
           else
           {
           MessageBox.Show("ERROR 2: La contabilidad seleccionada no existe!");
           }
           conexion.Close();
           openFileDialog1.Filter = "archivos xml (*.xml)|*.xml";
           if (openFileDialog1.ShowDialog() == DialogResult.OK)
           {
               Lbl_Abrir.Text = openFileDialog1.FileName;
           }
           String path = Lbl_Abrir.Text;

           if (path != "0")
           {
               int cantId = 0; int cantNote = 0; int cantIva = 0; int cantVtotal = 0; int cantNit = 0; int idschemes = 0;
               int clientePosition = 0; int cantSubT = 0; int idschemesName = 0;

               String date = " "; string[] subTotal = new string[50];

               string[] id = new string[50]; string[] note = new string[10]; string[] iva = new string[50];
               string[] Vtotal = new string[50]; string[] nit = new string[50]; string[] idschemeName = new string[50]; string[] idscheme = new string[50];
               string[] clienteNombre = new string[50];

               XmlReader xmlReader = XmlReader.Create(path);

               while (xmlReader.Read())
               {
                   if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "cbc:IssueDate"))
                   {
                       date = xmlReader.ReadInnerXml();
                   }
                   else if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "cbc:ID"))
                   {
                       id[cantId] = (xmlReader.ReadInnerXml());
                       cantId = cantId + 1;
                   }
                   else if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "cbc:CompanyID"))
                   {
                       if (xmlReader.HasAttributes)
                       {
                           idscheme[idschemes] = xmlReader.GetAttribute("schemeID");
                           idschemes++;
                           idschemeName[idschemesName] = xmlReader.GetAttribute("schemeName");
                           idschemesName++;
                           nit[cantNit] = (xmlReader.ReadInnerXml());
                           cantNit = cantNit + 1;
                       }
                   }
                   else if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "cbc:Note"))
                   {
                       note[cantNote] = (xmlReader.ReadInnerXml());
                       cantNote = cantNote + 1;
                   }

                   else if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "cbc:LineExtensionAmount"))
                   {
                       Vtotal[cantVtotal] = (xmlReader.ReadInnerXml());
                       cantVtotal = cantVtotal + 1;
                   }

                   else if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "cbc:CompanyID"))
                   {
                       nit[cantNit] = (xmlReader.ReadInnerXml());
                       cantNit = cantNit + 1;
                   }
                   else if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "cbc:TaxableAmount"))
                   {
                       subTotal[cantSubT] = (xmlReader.ReadInnerXml());
                       cantSubT = cantSubT + 1;
                   }
                   else if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "cbc:RegistrationName"))
                   {
                       clienteNombre[clientePosition] = (xmlReader.ReadInnerXml());
                       clientePosition = clientePosition + 1;
                   }
                   else if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "cbc:TaxAmount"))
                   {
                       iva[cantIva] = (xmlReader.ReadInnerXml());
                       cantIva = cantIva + 1;
                   }
               }
               String Nit = "31";
               String FacturaEmpresa = "";
               String FacturaEmpresa2 = "";

               if (idschemeName[1] == Nit)
               {
                   if (idscheme[1] != null)
                   {
                       FacturaEmpresa = id[2] + "-" + idscheme[1] + "   ";
                       FacturaEmpresa2 = id[3] + "-" + idscheme[2] + "   ";


                   }
               }
               else
               {
                   FacturaEmpresa = id[2] + "   ";
                   FacturaEmpresa2 = id[2] + "   ";

               }

               Console.WriteLine(FacturaEmpresa);
               Console.WriteLine(FacturaEmpresa2);

               //Lectura de tributos
               conexion.Open();
               string tributo = "SELECT Nom_Tributo, identificador FROM fe_Tributo";
               SqlCommand consultaTri = new SqlCommand(tributo, conexion);
               SqlDataReader consultaTributo = consultaTri.ExecuteReader();


               string[] tributos = new string[99];
               int i = -1;

               while (consultaTributo.Read())
               {
                   i++;
                   tributos[i] = consultaTributo["Nom_Tributo"].ToString();
               }
               conexion.Close();


               if (NoEmpresaFactura == FacturaEmpresa || NoEmpresaFactura == FacturaEmpresa2)
               //if (respuesta == true)
               {
                   String separator = note[0];

                   char[] limitador = { ' ', '$', '*' };
                   string[] arreglo = separator.Split(limitador, StringSplitOptions.RemoveEmptyEntries);
                   string[] rete = new string[15]; rete[1] = "0"; rete[2] = "0"; rete[3] = "0"; rete[4] = "0";
                   string[] reteDesc = new string[15];
                   int retenciones = 7;
                   for (i = 0; i < arreglo.Length; i++)
                   {
                    rete[0] = Vtotal[0];
                    reteDesc[0] = ("Ingreso");
                    Console.WriteLine(rete[0] + "Ingreos");

                    rete[1] = iva[1];
                    reteDesc[1] = ("IVA");
                    Console.WriteLine(rete[1] + "Iva");

                    if (arreglo[i] == "Retefuente")
                    {
                        rete[2] = (arreglo[i + 2]);
                        reteDesc[2] = ("Rte.Fte");
                        //reteDesc[1] = ("Retefuente");
                    }
                    if (arreglo[i] == "ReteIva")
                    {
                        rete[3] = (arreglo[i + 2]);
                        reteDesc[3] = ("Rte.Iva");
                        //reteDesc[2] = ("ReteIva");

                    }

                    if (arreglo[i] == "ReteIca")
                    {
                        rete[4] = (arreglo[i + 5]);
                        //reteDesc[3] = ("ReteIca");
                        reteDesc[4] = ("Rte.Ica");

                        //Console.WriteLine(rete[3] + "ICA1");

                    }
                    if (arreglo[i] == "9.66" || arreglo[i] == "14" || arreglo[i] == "6.9" || arreglo[i] == "10" || arreglo[i] == "11.44")
                    {
                        rete[4] = (arreglo[i + 4]);
                        //reteDesc[3] = ("ReteIca");
                        reteDesc[4] = ("Rte.Ica");
                        //Console.WriteLine(rete[3] + "ICA2");
                        retenciones++;

                    }
                    if (arreglo[i] == "Pagar")
                    {
                        rete[5] = (arreglo[i + 1]);
                        // total = (arreglo[i + 1]);
                        reteDesc[5] = ("Cta x Cobrar");
                    }
                    for (int z = 0; z < tributos.Length; z++)
                    {
                        if (arreglo[i] == tributos[z] && tributos[z] != "ReteIca" && tributos[z] != "Retefuente" && tributos[z] != "ReteIva" && tributos[z] != "Pagar")
                        {
                            rete[retenciones] = (arreglo[i + 2]);
                            reteDesc[retenciones] = tributos[z];
                            retenciones++;

                        }
                    }

                }


                for (int x = 1; x <= 5; x++)
                {
                    double CorreccRes = Convert.ToDouble(rete[x], System.Globalization.CultureInfo.InvariantCulture);
                }

                double CxCcorreccion = Convert.ToDouble(Vtotal[0], System.Globalization.CultureInfo.InvariantCulture);
                decimal ingresos = decimal.Parse(Vtotal[0]) / 100;
                decimal ivaD = decimal.Parse(iva[1]) / 100;

                decimal TCreditos = ingresos + ivaD;

                decimal TDebitos = decimal.Parse(rete[2]) / 100 + decimal.Parse(rete[3]) / 100 + decimal.Parse(rete[4]) / 100;
                decimal CtaXCobrar = TCreditos - TDebitos;

                dgv_FacturaCargada.Rows.Clear();
                Console.WriteLine(ConTipoMov);
                conexion.Open();
                string NitCliente = "";
                if (idschemeName[2] == Nit)
                    NitCliente = nit[2] + "-" + idscheme[2];
                else
                    NitCliente = nit[2];
                string cadenaCliente = "select nom_terc from dbo.cm_terce where nit_clie='" + NitCliente + "'";
                SqlCommand comandoCliente = new SqlCommand(cadenaCliente, conexion);
                SqlDataReader registrosClientes = comandoCliente.ExecuteReader();
                bool registroCliente = registrosClientes.Read();
                conexion.Close();

                conexion.Open();
                string cod = "";
                if (idschemeName[2] == Nit)
                {
                    cod = nit[2] + "-" + idscheme[2];
                }
                else
                {
                    cod = nit[2];
                }
                rete[6] = CtaXCobrar.ToString();
                string cadena = "select Cod_Cuenta,Tipo_Mov from dbo.fe_parametrosContables where No_idCLiente='" + cod + "'";
                SqlCommand comando = new SqlCommand(cadena, conexion);
                SqlDataReader registro = comando.ExecuteReader();
                bool registros = registro.Read();
                if (registro.Read())
                {
                    conexion.Close();
                    conexion.Open();
                    string cadenaIngreso = "select Cod_Cuenta,"+ ConTipoMov + ",Tipo_Cuenta from dbo.fe_parametrosContables where No_idCLiente='" + cod + "'" + "and Tipo_Cuenta ='Ingreso'";
                    string cadenaIva = "select Cod_Cuenta,"+ ConTipoMov + ",Tipo_Cuenta from dbo.fe_parametrosContables where No_idCLiente='" + cod + "'" + "and Tipo_Cuenta ='IVA'";
                    string cadenaRfte = "select Cod_Cuenta,"+ ConTipoMov + ",Tipo_Cuenta from dbo.fe_parametrosContables where No_idCLiente='" + cod + "'" + "and Tipo_Cuenta ='Rte.Fte'";
                    string cadenaRiva = "select Cod_Cuenta,"+ ConTipoMov + ",Tipo_Cuenta from dbo.fe_parametrosContables where No_idCLiente='" + cod + "'" + "and Tipo_Cuenta ='Rte.Iva'";
                    string cadenaRica = "select Cod_Cuenta,"+ ConTipoMov + ",Tipo_Cuenta from dbo.fe_parametrosContables where No_idCLiente='" + cod + "'" + "and Tipo_Cuenta ='Rte.Ica'";
                    string cadenaCxc = "select Cod_Cuenta,"+ ConTipoMov + ",Tipo_Cuenta from dbo.fe_parametrosContables where No_idCLiente='" + cod + "'" + "and Tipo_Cuenta ='Cta x Cobrar'";
                    SqlCommand comandoIngreso = new SqlCommand(cadenaIngreso, conexion);
                    SqlDataReader registroIngreso = comandoIngreso.ExecuteReader();

                    if (registroIngreso.Read() && rete[4] != " ")
                    {
                        dgv.Rows.Add(registroIngreso["Cod_Cuenta"].ToString(), "Ingreso   Factura No. " + id[0] + "  " + clienteNombre[2], Vtotal[0], registroIngreso[ConTipoMov].ToString());
                    }
                    else
                    {
                        MessageBox.Show("El ingreso no tiene asignada una cuenta");
                    }
                    conexion.Close();
                    conexion.Open();
                    SqlCommand comandoIva = new SqlCommand(cadenaIva, conexion);
                    SqlDataReader registroIva = comandoIva.ExecuteReader();
                    if (registroIva.Read() && iva[1] != " ")
                    {
                       dgv.Rows.Add(registroIva["Cod_Cuenta"].ToString(), "Iva   Factura No. " + id[0] + "  " + clienteNombre[2], iva[1], registroIva[ConTipoMov].ToString());
                    }

                    conexion.Close();
                    conexion.Open();
                    SqlCommand comandoRfte = new SqlCommand(cadenaRfte, conexion);
                    SqlDataReader registroRfte = comandoRfte.ExecuteReader();

                    if (registroRfte.Read() && rete[1] != " ")
                    {
                       dgv.Rows.Add(registroRfte["Cod_Cuenta"].ToString(), "Rte.Fte   Factura No. " + id[0] + "  " + clienteNombre[2], rete[2], registroRfte[ConTipoMov].ToString());
                    }

                    conexion.Close();
                    conexion.Open();
                    SqlCommand comandoRiva = new SqlCommand(cadenaRiva, conexion);
                    SqlDataReader registroRiva = comandoRiva.ExecuteReader();
                    if (registroRiva.Read() && rete[2] != " ")
                    {
                        dgv.Rows.Add(registroRiva["Cod_Cuenta"].ToString(), "Rte.Iva   Factura No. " + id[0] + "  " + clienteNombre[2], rete[3], registroRiva[ConTipoMov].ToString());
                    }

                    conexion.Close();
                    conexion.Open();
                    SqlCommand comandoRica = new SqlCommand(cadenaRica, conexion);
                    SqlDataReader registroRica = comandoRica.ExecuteReader();
                    if (registroRica.Read() && rete[3] != " ")
                    {
                        dgv.Rows.Add(registroRica["Cod_Cuenta"].ToString(), "Rte.Ica  Factura No. " + id[0] + "  " + clienteNombre[2], rete[4], registroRica[ConTipoMov].ToString());
                        Console.WriteLine(rete[3] + "P");

                    }
                    conexion.Close();

                    conexion.Open();
                    //Tipo de identificación
                    string ConsultaTipoIdentificacion = "select * from  fe_TipoIden ";
                    SqlCommand comandoTipoIdentificacion = new SqlCommand(ConsultaTipoIdentificacion, conexion);
                    SqlDataReader registroTipoIdentificacion = comandoTipoIdentificacion.ExecuteReader();
                    string[] arrTipoIdentificacion = new string[99];
                    int a = -1;
                    while (registroTipoIdentificacion.Read())
                    {
                        a++;
                        arrTipoIdentificacion[a] = registroTipoIdentificacion["Tip_Iden"].ToString();
                        a++;
                        arrTipoIdentificacion[a] = registroTipoIdentificacion["Codigo_Dian"].ToString();
                    }
                    conexion.Close();

                    conexion.Open();
                    SqlCommand comandoCxc = new SqlCommand(cadenaCxc, conexion);
                    SqlDataReader registroCxc = comandoCxc.ExecuteReader();
                    if (registroCxc.Read())
                    {
                        dgv_FacturaCargada.Rows.Add(registroCxc["Cod_Cuenta"].ToString(), "Cta x Cobrar   Factura No. " + id[0] + "  " + clienteNombre[2], CtaXCobrar.ToString(), registroCxc[ConTipoMov].ToString());
                    }

                    conexion.Close();
                    tb_CFNoFactura.Text = id[0];
                    cb_CFTipoId.Text = TipoIdEmpresaFactura;
                    tb_CFNoId.Text = nit[1] + "-" + idscheme[1];
                    tb_CFFechaEmision.Text = date;
                    tb_CFNoIdClente.Text = nit[2] + "-" + idscheme[2];
                    cb_CFTipoIdCliente.Text = "NI";
                    label17.Text = "Info Factura para : " + clienteNombre[2];

                    conexion.Open();
                    string NombreEmpFact = "";
                    string NitEmpresaFact = "";
                    if (idschemeName[1] == Nit)
                    {
                        NitEmpresaFact = nit[1] + "-" + idscheme[1];
                    }
                    else
                    {
                        NitEmpresaFact = nit[1];

                    }

                    string NombreEmpresaFact = "select nom_terc from dbo.cm_terce where nit_clie='" + NitEmpresaFact + "'";

                    SqlCommand comandNEF = new SqlCommand(NombreEmpresaFact, conexion);
                    SqlDataReader consultaNEF = comandNEF.ExecuteReader();
                    if (consultaNEF.Read())
                    {
                        NombreEmpFact = consultaNEF["nom_terc"].ToString();
                        conexion.Close();
                    }
                    else
                    {
                        MessageBox.Show("!2!");
                        conexion.Close();
                    }

                    conexion.Open();
                    string dataValidaccion = "select Id_Factura from dbo.fe_ComprobantesV2 where Id_Factura='" + id[0] + "'";
                    SqlCommand consulta = new SqlCommand(dataValidaccion, conexion);
                    SqlDataReader consultaArc = consulta.ExecuteReader();
                    if (consultaArc.Read())
                    {
                        MessageBox.Show("Este documento ya fue cargado");
                        conexion.Close();


                    }
                    else
                    {
                        conexion.Close();
                        conexion.Open();
                        int posicion = 1;
                        for (i = 0; i < reteDesc.Length; i++)
                        {
                            string dataComprobanteTributo = "insert into dbo.fe_ComprobantesTributos values(@Cod_arbo,@Id_Factura, @Consecutivo,@Id_Tributos, @Valor)";
                            SqlCommand agregarTri = new SqlCommand(dataComprobanteTributo, conexion);

                            if (!string.IsNullOrEmpty(reteDesc[i]) && (double.TryParse(rete[i], out double valorNumerico) && valorNumerico != 0) || reteDesc[i] == tributos[i])

                            {
                                agregarTri.Parameters.Clear();

                                agregarTri.Parameters.AddWithValue("@Cod_arbo", cont);
                                agregarTri.Parameters.AddWithValue("@Id_Factura", id[0]);
                                agregarTri.Parameters.AddWithValue("@Consecutivo", posicion);
                                agregarTri.Parameters.AddWithValue("@Id_Tributos", reteDesc[i]);
                                agregarTri.Parameters.AddWithValue("@Valor", rete[i]);


                                posicion++;

                                agregarTri.ExecuteNonQuery();
                            }

                        }
                        conexion.Close();


                        conexion.Open();
                        string dataComprobante = "insert into dbo.fe_ComprobantesV2 values(@Contabilidad, @Id_Factura, @TipoId_EmpFactura, @No_idEmpFactura, @TipoId_Cliente, @No_idCLiente, @FechaEmision,@Valor, @Estado)";

                        SqlCommand agregar = new SqlCommand(dataComprobante, conexion);
                        string tipoIdEmpresa = "";
                        string idEmpFactura = "";

                        i = 0;
                        while (i < arrTipoIdentificacion.Length)
                        {
                            if (idschemeName[1] == arrTipoIdentificacion[i])
                            {
                                tipoIdEmpresa = arrTipoIdentificacion[i - 1];
                                idEmpFactura = nit[1] + "-" + idscheme[1];
                            }
                            if (tipoIdEmpresa == "")
                            {
                                tipoIdEmpresa = "OT";
                                idEmpFactura = nit[1];
                            }

                            i++;
                        }

                        string tipoIdCliente = "";
                        string idCliente = "";
                        i = 0;
                        while (i < arrTipoIdentificacion.Length)
                        {
                            if (idschemeName[2] == arrTipoIdentificacion[i])
                            {
                                tipoIdCliente = arrTipoIdentificacion[i - 1];
                                idCliente = nit[2] + "-" + idscheme[2];
                            }
                            if (tipoIdCliente == "")
                            {
                                tipoIdCliente = "OT";
                                idCliente = nit[1];
                            }
                            i++;
                        }
                        agregar.Parameters.AddWithValue("@Contabilidad", cont);
                        agregar.Parameters.AddWithValue("@Id_Factura", id[0]);
                        agregar.Parameters.AddWithValue("@TipoId_EmpFactura", tipoIdEmpresa);
                        agregar.Parameters.AddWithValue("@No_idEmpFactura", idEmpFactura);
                        agregar.Parameters.AddWithValue("@TipoId_Cliente", tipoIdCliente);
                        agregar.Parameters.AddWithValue("@No_idCLiente", idCliente);
                        agregar.Parameters.AddWithValue("@FechaEmision", date);
                        agregar.Parameters.AddWithValue("@Valor", TCreditos);

                        agregar.Parameters.AddWithValue("@Estado", "Cargado");

                        agregar.ExecuteNonQuery();

                        MessageBox.Show("Nota Credito cargada con exito!");
                        conexion.Close();
                    }
                }

                else if (registroCliente == false)
                {
                    MessageBox.Show("El cliente no se encuentra registrado!");


                    conexion.Close();
                }
                else
                {
                    MessageBox.Show("El cliente no tiene definido los parametros contables!");
                    conexion.Close();

                }
                cargaDg.cargaFC(dataGridView1,"Facturas");
            }
            else
            {
                MessageBox.Show("ERROR : La contabilidad Seleccionada no corresponde con esta factura");


            }
        }
        }
        else
        {
            MessageBox.Show("Seleccione una contabilidad!");
        }

        }
       



        //Clases
        public void generarComprobantes(string documento, string tb)
        {
            string[] MovNo = new string[99]; string[] MovType = new string[99]; string[] facturaInfo = new string[99];
            string[] TipoCuen = new string[99]; string estadoFactura = ""; string[] TipoCuenta = new string[99];

            //Busca la Informacion de la Factura en la Base de datos usando el ID de la Factura
            conexion.Open();


            String cadenaInfoFactura = "Select Contabilidad,Id_Factura,TipoId_EmpFactura,No_idEmpFactura,TipoId_Cliente,No_idCLiente,FechaEmision,Estado from fe_comprobantesV2 where Id_Factura = '" +tb + "'";
            SqlCommand comandoInfo = new SqlCommand(cadenaInfoFactura, conexion);
            SqlDataReader registroInfo = comandoInfo.ExecuteReader();
            if (registroInfo.Read())
            {
                facturaInfo[1] = registroInfo["Contabilidad"].ToString();
                facturaInfo[2] = registroInfo["Id_Factura"].ToString();
                facturaInfo[3] = registroInfo["TipoId_EmpFactura"].ToString();
                facturaInfo[4] = registroInfo["No_idEmpFactura"].ToString();
                facturaInfo[5] = registroInfo["TipoId_Cliente"].ToString();
                facturaInfo[6] = registroInfo["No_idCLiente"].ToString();
                facturaInfo[7] = registroInfo["FechaEmision"].ToString();
                estadoFactura = registroInfo["Estado"].ToString();
                //validar = true;
            }
            else
            {
                MessageBox.Show("La factura que esta Exportando No Existe!!");
                //validar = false;
            }
            registroInfo.Close();


            String Count = "select COUNT (*) from fe_ComprobantesTributos  where Id_Factura = '" +tb + "'";
            SqlCommand comandoCount = new SqlCommand(Count, conexion);
            Int32 totalDatos = (Int32)comandoCount.ExecuteScalar();
            conexion.Close();


            conexion.Open();

            String cadenaInfoFacturaReten2 = "Select Id_Factura,Id_Tributos,Valor from fe_ComprobantesTributos where Id_Factura = '" +tb + "'";
            SqlCommand comandoInfoReten2 = new SqlCommand(cadenaInfoFacturaReten2, conexion);
            SqlDataReader registroInfoReten2 = comandoInfoReten2.ExecuteReader();
            int contadorInfo = 0;
            int arregloInfo = 10;

            while (registroInfoReten2.Read() && contadorInfo < totalDatos)
            {
                facturaInfo[arregloInfo] = registroInfoReten2["Id_Tributos"].ToString();
                arregloInfo++;
                facturaInfo[arregloInfo] = registroInfoReten2["Valor"].ToString();
                arregloInfo++;
                contadorInfo++;

            }



            conexion.Close();
            if (estadoFactura == "Exportado")
            {
                MessageBox.Show("La factura: " + facturaInfo[2] + " Ya se encuentra Exportada.");
            }
            else
            {
                facturaInfo[7] = facturaInfo[7].Replace("/", "-");
                DateTime FechaFactura = Convert.ToDateTime(facturaInfo[7]);

                // Consulta a PC "Parametros Contables" Para encontrar el Tipo de Movimiento de las cuentas Contables
                conexion.Open();
                string cadenaConsultaPC = "select Tipo_Mov,Cod_Cuenta,Man_Trib,RTRIM(Tipo_Cuenta) from fe_ParametrosContables where Contabilidad = '" + facturaInfo[1] + "' and No_idCLiente ='" + facturaInfo[6] + "'";
                SqlCommand comandoConsultaPC = new SqlCommand(cadenaConsultaPC, conexion);
                SqlDataReader registroConsultaPC = comandoConsultaPC.ExecuteReader();
                Console.WriteLine(cadenaConsultaPC);

                int i = 0;
                while (registroConsultaPC.Read())
                {
                    MovType[i] = (registroConsultaPC[0].ToString());
                    MovNo[i] = (registroConsultaPC[1].ToString());
                    TipoCuen[i] = (registroConsultaPC[2].ToString());
                    TipoCuenta[i] = (registroConsultaPC[3].ToString());
                    i++;
                    Console.WriteLine(TipoCuenta[i]+"---TIPOCUENTA");
                }

                conexion.Close();

                //Suma de parametros Contables por tipo
                double TotalCreditos = 0; double TotalDebitos = 0;


                int a = -1;
                for (int j = 0; j < 12; j++)
                {

                    string valorFactura = facturaInfo[10 + j];
                    if (double.TryParse(valorFactura, out double credito))
                    {
                        a = a + 1;
                        if (MovType[a] == "C")
                        {

                            TotalCreditos = TotalCreditos + credito;

                            // TotalCreditos = TotalCreditos + double.Parse(valorFactura);

                        }
                        else if (MovType[a] == "D")
                        {
                            //TotalDebitos = TotalDebitos + double.Parse(valorFactura);
                            TotalDebitos = TotalDebitos + credito;

                        }

                        else
                        {
                            Console.WriteLine(double.Parse(facturaInfo[10 + j]));

                        }
                    }


                }
                //Consulta a PG "Parametros Generales" Para encontrar el Tipo de Comprobante
                conexion.Open();

                string cadenaTipoFactura = "select "+documento+" from fe_ParametrosGenerales where NoId = '" + facturaInfo[4] + "' and Contabilidad = '" + facturaInfo[1] + "'";
                SqlCommand comandoTF = new SqlCommand(cadenaTipoFactura, conexion);
                SqlDataReader registroTF = comandoTF.ExecuteReader();
                if (registroTF.Read())
                {
                    facturaInfo[8] = registroTF[documento].ToString();
                    Console.WriteLine(facturaInfo[8]);

                }

                conexion.Close();
                //if 
                conexion.Open();

                string cadenaNumCons = "select num_cons from gn_conse where cod_arbo = '" + facturaInfo[1] + "' and cod_cons = '" + facturaInfo[8] + "'";
                SqlCommand comandoNumCons = new SqlCommand(cadenaNumCons, conexion);
                SqlDataReader registroNumCons = comandoNumCons.ExecuteReader();
                if (registroNumCons.Read())
                {
                    facturaInfo[9] = registroNumCons["num_cons"].ToString();

                }

                conexion.Close();
                //if

                conexion.Open();
                string cadenaInsertarCmMoc = "insert into cm_movim values(@cod_arbo, @tip_comp, @num_comp, @fec_movi, @tot_movi,@est_movi ,@mov_gest, @est_guard, @Val_Girar, NULL,NULL, NULL,NULL)";
                SqlCommand agregarCmMoc = new SqlCommand(cadenaInsertarCmMoc, conexion);

                agregarCmMoc.Parameters.AddWithValue("@cod_arbo", int.Parse(facturaInfo[1]));
                agregarCmMoc.Parameters.AddWithValue("@tip_comp", facturaInfo[8]);
                agregarCmMoc.Parameters.AddWithValue("@num_comp", int.Parse(facturaInfo[9]));
                agregarCmMoc.Parameters.AddWithValue("@fec_movi", FechaFactura);
                agregarCmMoc.Parameters.AddWithValue("@tot_movi", TotalDebitos);
                agregarCmMoc.Parameters.AddWithValue("@est_movi", "S");
                agregarCmMoc.Parameters.AddWithValue("@mov_gest", "CT");
                agregarCmMoc.Parameters.AddWithValue("@est_guard", "S");
                agregarCmMoc.Parameters.AddWithValue("@Val_Girar", 0);

                agregarCmMoc.ExecuteNonQuery();
                //error
                conexion.Close();

                conexion.Open();
                string ConsultaTributo = "select * from  fe_Tributo ";
                SqlCommand comandoTributo = new SqlCommand(ConsultaTributo, conexion);
                SqlDataReader registroTributo = comandoTributo.ExecuteReader();
                string[] arrTributo = new string[99];
                a = 0;
                while (registroTributo.Read())
                {
                    arrTributo[a] = registroTributo["Nom_Tributo"].ToString();
                    a++;

                }
                conexion.Close();
                string[] NombreContabilidad = { "Ingreso", "IVA", "Rte.Fte", "Rte.Iva", "Rte.Ica", "Cta x Cobrar" };
                int position = 1;
                for (int x = 0; x < TipoCuenta.Length; x++)
                {

                    if (MovType[x] != "")
                    {
                        for (i = 0; i < facturaInfo.Length; i++)
                        {
                            Console.WriteLine(facturaInfo[i]+"Faturainfo");

                            if (TipoCuen[x] == "T    " && TipoCuenta[x] == facturaInfo[i] && !string.IsNullOrWhiteSpace(TipoCuenta[x]))
                            {

                                conexion.Open();
                                string cadenaInsertarCwMoc = "insert into cw_movim values(@cod_arbo, @tip_comp, @num_comp, @cod_cuen, @rmt_cumo,@nit_clie,@tip_iden,NULL ,@des_deta,NULL ,@vlr_movi, @tip_movi, @bas_rete, NULL,@Cod_Usua)";
                                //  string codCuent="select cod_cuent from cw_movim";

                                SqlCommand agregarCwMoc = new SqlCommand(cadenaInsertarCwMoc, conexion);

                                agregarCwMoc.Parameters.AddWithValue("@cod_arbo", int.Parse(facturaInfo[1]));
                                agregarCwMoc.Parameters.AddWithValue("@tip_comp", facturaInfo[8]);
                                agregarCwMoc.Parameters.AddWithValue("@num_comp", int.Parse(facturaInfo[9]));
                                agregarCwMoc.Parameters.AddWithValue("@cod_cuen", MovNo[x]);
                                agregarCwMoc.Parameters.AddWithValue("@rmt_cumo", position);
                                agregarCwMoc.Parameters.AddWithValue("@des_deta", "Fra. " + facturaInfo[2] + " " + facturaInfo[i] + " De Cliente: " + facturaInfo[6]);
                                agregarCwMoc.Parameters.AddWithValue("@vlr_movi", double.Parse(facturaInfo[i + 1]));
                                agregarCwMoc.Parameters.AddWithValue("@tip_movi", MovType[x]);
                                agregarCwMoc.Parameters.AddWithValue("@bas_rete", 0);
                                agregarCwMoc.Parameters.AddWithValue("@Cod_Usua", "JRIVERA");
                                agregarCwMoc.Parameters.AddWithValue("@nit_clie", facturaInfo[6]);
                                agregarCwMoc.Parameters.AddWithValue("@tip_iden", facturaInfo[5]);

                                agregarCwMoc.ExecuteNonQuery();
                                conexion.Close();
                                position++;

                                Console.WriteLine(" Paso 1");



                            }
                            else if (TipoCuenta[x] == facturaInfo[i] && !string.IsNullOrWhiteSpace(TipoCuenta[x]))
                            {

                                conexion.Open();
                                string cadenaInsertarCwMoc = "insert into cw_movim values(@cod_arbo, @tip_comp, @num_comp, @cod_cuen, @rmt_cumo,NULL ,NULL ,NULL ,@des_deta,NULL ,@vlr_movi, @tip_movi, @bas_rete, NULL,@Cod_Usua)";
                                SqlCommand agregarCwMoc = new SqlCommand(cadenaInsertarCwMoc, conexion);

                                agregarCwMoc.Parameters.AddWithValue("@cod_arbo", int.Parse(facturaInfo[1]));
                                agregarCwMoc.Parameters.AddWithValue("@tip_comp", facturaInfo[8]);
                                agregarCwMoc.Parameters.AddWithValue("@num_comp", int.Parse(facturaInfo[9]));
                                agregarCwMoc.Parameters.AddWithValue("@cod_cuen", MovNo[x]);
                                agregarCwMoc.Parameters.AddWithValue("@rmt_cumo", position);
                                agregarCwMoc.Parameters.AddWithValue("@des_deta", "Fra. " + facturaInfo[2] + " " + facturaInfo[i] + " De Cliente: " + facturaInfo[6]);
                                agregarCwMoc.Parameters.AddWithValue("@vlr_movi", double.Parse(facturaInfo[i + 1]));
                                agregarCwMoc.Parameters.AddWithValue("@tip_movi", MovType[x]);
                                agregarCwMoc.Parameters.AddWithValue("@bas_rete", 0);
                                agregarCwMoc.Parameters.AddWithValue("@Cod_Usua", "JRIVERA");

                                agregarCwMoc.ExecuteNonQuery();
                                conexion.Close();
                                position++;
                                Console.WriteLine(" Paso 2");


                            }
                            else
                            {
                                Console.WriteLine("No Paso");
                            }
                            

                        }


                    }
                    else
                    {
                        MessageBox.Show("Agregar cuenta");

                    }
                }
                MessageBox.Show("Registro Exitoso No: " + (int.Parse(facturaInfo[9])) + " .");

                dataGridView1.Visible = true; dgv_FCFacturasCargadas.Visible = false; btn_FCVolver.Visible = false; btn_FCGuardarExcel.Visible = false;
                btn_FCGenerarComprobante.Visible = false;tb = ""; label21.Visible = false;

                int conv = int.Parse(facturaInfo[9]);
                conexion.Open();
                string update = "update gn_conse set num_cons='" + (conv + 1) + "' where cod_arbo ='" + facturaInfo[1] + "' and cod_cons ='" + facturaInfo[8] + "'";
                SqlCommand actualizar = new SqlCommand(update, conexion);
                actualizar.ExecuteNonQuery();
                conexion.Close();

                conexion.Open();
                string insert = "update fe_comprobantesV2 set Estado='Exportado' where Id_Factura ='" + facturaInfo[2] + "'";
                SqlCommand agregar = new SqlCommand(insert, conexion);
                agregar.ExecuteNonQuery();
                conexion.Close();

                dataGridView1.Rows.Clear();
                cargaDg.cargaFC(dataGridView1, "Facturas");

            }
            
        }
        private void ConsultarDocumentos(DataGridView dgv1, DataGridView dgv2)
        {
            string IdFactura = dgv1.CurrentCell.Value.ToString();
            dgv2.Rows.Clear();
            bool validar;
            tb_FCIdFactura.Text = IdFactura;
            string idFactura = IdFactura;
            string[] facturaData = new string[99]; string[] facturaType = new string[99]; string[] facturaInfo = new string[99];
            conexion.Open();

            String cadenaInfoFactura = "Select Contabilidad,Id_Factura,TipoId_EmpFactura,No_idEmpFactura,TipoId_Cliente,No_idCLiente,FechaEmision from fe_comprobantesV2 where Id_Factura = '" + idFactura + "'";
            SqlCommand comandoInfo = new SqlCommand(cadenaInfoFactura, conexion);
            SqlDataReader registroInfo = comandoInfo.ExecuteReader();
            if (registroInfo.Read())
            {
                facturaInfo[1] = registroInfo["Contabilidad"].ToString();
                facturaInfo[2] = registroInfo["Id_Factura"].ToString();
                facturaInfo[3] = registroInfo["TipoId_EmpFactura"].ToString();
                facturaInfo[4] = registroInfo["No_idEmpFactura"].ToString();
                facturaInfo[5] = registroInfo["TipoId_Cliente"].ToString();
                facturaInfo[6] = registroInfo["No_idCLiente"].ToString();
                facturaInfo[7] = registroInfo["FechaEmision"].ToString();
            }
            else
            {
                MessageBox.Show("La Factura que esta buscando no existe!!");
            }
            registroInfo.Close();

            String Count = "select COUNT (*) from fe_ComprobantesTributos  where Id_Factura = '" + idFactura + "'";
            SqlCommand comandoCount = new SqlCommand(Count, conexion);
            Int32 totalDatos = (Int32)comandoCount.ExecuteScalar();
            conexion.Close();


            conexion.Open();

            String cadenaInfoFacturaReten2 = "Select Id_Factura,Id_Tributos,Valor from fe_ComprobantesTributos where Id_Factura = '" + idFactura + "'";
            SqlCommand comandoInfoReten2 = new SqlCommand(cadenaInfoFacturaReten2, conexion);
            SqlDataReader registroInfoReten2 = comandoInfoReten2.ExecuteReader();
            int contadorInfo = 0;
            int arregloInfo = 8;

            while (registroInfoReten2.Read() && contadorInfo < totalDatos)
            {

                facturaInfo[arregloInfo] = registroInfoReten2["Id_Tributos"].ToString();

                arregloInfo++;
                facturaInfo[arregloInfo] = registroInfoReten2["Valor"].ToString();

                arregloInfo++;
                contadorInfo++;

            }
            validar = true;

            conexion.Close();
            String separator = facturaInfo[7];
            char[] limitador = { ' ' };
            string[] arreglo = separator.Split(limitador, StringSplitOptions.RemoveEmptyEntries);
            label21.Text = "Fecha Emision: " + arreglo[0];
            if (validar)
            {
                dgv1.Visible = false; dgv2.Visible = true; btn_FCVolver.Visible = true; btn_FCGuardarExcel.Visible = true;
                int cantidadCod = 0;
                conexion.Open();
                string cadenaCodigC = "select * from fe_ParametrosContables where No_IdCLiente = '" + facturaInfo[6] + "'";
                SqlCommand comandoCodigC = new SqlCommand(cadenaCodigC, conexion);
                SqlDataReader registroCodigC = comandoCodigC.ExecuteReader();
                while (registroCodigC.Read())
                {
                    facturaData[cantidadCod] = registroCodigC[3].ToString();
                    facturaType[cantidadCod] = registroCodigC[5].ToString();
                    cantidadCod++;
                }
                conexion.Close();
                conexion.Open();
                string cont = "";
                string cadenaConsultaArbol = "select des_arbo from dbo.gn_arbol where cod_arbo='" + facturaInfo[1] + "'";
                SqlCommand comandoCARBOL = new SqlCommand(cadenaConsultaArbol, conexion);
                SqlDataReader registroCArbol = comandoCARBOL.ExecuteReader();
                if (registroCArbol.Read())
                {
                    cont = registroCArbol["des_arbo"].ToString();
                }
                else
                {
                    MessageBox.Show("ERROR : La contabilidad seleccionada no existe!");
                }
                conexion.Close();
                string[] CodigoCuenta = new string[99];
                //Pr
                string[] NombreCuenta = new string[99];


                conexion.Open();
                string cadenaConsultaCodC = "select Cod_Cuenta,Tipo_Cuenta from fe_parametrosContables where No_IdCLiente='" + facturaInfo[6] + "' and Contabilidad ='" + facturaInfo[1] + "'";
                SqlCommand comandoCCodC = new SqlCommand(cadenaConsultaCodC, conexion);
                SqlDataReader registroCCodC = comandoCCodC.ExecuteReader();
                int i = 0;
                while (registroCCodC.Read())
                {
                    CodigoCuenta[i] = registroCCodC["Cod_Cuenta"].ToString();
                    NombreCuenta[i] = registroCCodC["Tipo_Cuenta"].ToString();
                    i++;
                }
                conexion.Close();
                dgv2.Rows.Clear();

                conexion.Open();
                string ConsultaTributo = "select * from  fe_Tributo ";
                SqlCommand comandoTributo = new SqlCommand(ConsultaTributo, conexion);
                SqlDataReader registroTributo = comandoTributo.ExecuteReader();
                string[] arrTributo = new string[99];
                int a = 0;
                while (registroTributo.Read())
                {
                    arrTributo[a] = registroTributo["Nom_Tributo"].ToString();
                    a++;
                }

                conexion.Close();

                conexion.Open();
                string cadenaConsT = "select Man_Trib from fe_parametrosContables where Contabilidad= '" + facturaInfo[1] + "' and TipoId_Cliente='" + facturaInfo[5] + "' and No_idCLiente='" + facturaInfo[6] + "'";
                SqlCommand comandoConsT = new SqlCommand(cadenaConsT, conexion);
                SqlDataReader registroConsT = comandoConsT.ExecuteReader();
                string[] NombreContabilidad = { "Ingreso", "IVA", "Rte.Fte", "Rte.Iva", "Rte.Ica", "Cta x Cobrar" };
                string[] parContVal = new string[99];
                int l = 0;
                while (registroConsT.Read())
                {

                    parContVal[l] = registroConsT["Man_Trib"].ToString();
                    l++;
                }
                for (int j = 0; j < NombreContabilidad.Length; j++)
                {
                    if (CodigoCuenta[j] != "")
                    {
                        for (int grd = 0; grd < facturaInfo.Length; grd++)
                        {
                            if (NombreContabilidad[j] == facturaInfo[grd])
                            {
                                //Console.WriteLine(arrTributo[j] + "...Grd...." + facturaInfo[grd + 1]);

                                dgv2.Rows.Add(cont, facturaInfo[4], facturaInfo[6], CodigoCuenta[j], NombreContabilidad[j], facturaInfo[grd + 1], facturaType[j]);
                            }
                           
                            else
                            {
                                //Console.WriteLine("No paso");

                            }

                        }
                    }
                }

                btn_FCGenerarComprobante.Visible = true; label21.Visible = true;
            }
            else
            {

            }
            conexion.Close();
        }

        private void cb_FCEmpresaFactura_SelectedIndexChanged(object sender, EventArgs e)
        {

        }       
      
        public void btnVolver(DataGridView dgvolver, DataGridView dgComprobantes, Control btnVolver, Control btnExcel, Control btnComprobante,TextBox tbId, Control lbl,string tbl)
        {
            dgvolver.Visible = true; dgComprobantes.Visible = false; btnVolver.Visible = false; btnExcel.Visible = false;
            btnComprobante.Visible = false; tbId.Text = ""; lbl.Visible = false;
            dgvolver.Rows.Clear();
            cargaDg.cargaFC(dgvolver, tbl);         
        }
        public void guardarExcel()
        {
            string[] facturaData = new string[99]; string[] facturaType = new string[99]; string[] facturaInfo = new string[99];
            conexion.Open();
            String cadenaInfoFactura = "Select Contabilidad,Id_Factura,TipoId_EmpFactura,No_idEmpFactura,TipoId_Cliente,No_idCLiente,FechaEmision from fe_comprobantesV2 where Id_Factura = '" + tb_FCIdFactura.Text + "'";
            SqlCommand comandoInfo = new SqlCommand(cadenaInfoFactura, conexion);
            SqlDataReader registroInfo = comandoInfo.ExecuteReader();
            if (registroInfo.Read())
            {
                facturaInfo[1] = registroInfo["Contabilidad"].ToString();
                facturaInfo[2] = registroInfo["Id_Factura"].ToString();
                facturaInfo[3] = registroInfo["TipoId_EmpFactura"].ToString();
                facturaInfo[4] = registroInfo["No_idEmpFactura"].ToString();
                facturaInfo[5] = registroInfo["TipoId_Cliente"].ToString();
                facturaInfo[6] = registroInfo["No_idCLiente"].ToString();
                facturaInfo[7] = registroInfo["FechaEmision"].ToString();
                //validar = true;
            }
            else
            {
                MessageBox.Show("La factura que esta Exportando No Existe!!");
                //validar = false;
            }
            registroInfo.Close();

            String Count = "select COUNT (*) from fe_ComprobantesTributos  where Id_Factura = '" + tb_FCIdFactura.Text + "'";
            SqlCommand comandoCount = new SqlCommand(Count, conexion);
            Int32 totalDatos = (Int32)comandoCount.ExecuteScalar();
            conexion.Close();


            conexion.Open();

            String cadenaInfoFacturaReten2 = "Select Id_Factura,Id_Tributos,Valor from fe_ComprobantesTributos where Id_Factura = '" + tb_FCIdFactura.Text + "'";
            SqlCommand comandoInfoReten2 = new SqlCommand(cadenaInfoFacturaReten2, conexion);
            SqlDataReader registroInfoReten2 = comandoInfoReten2.ExecuteReader();
            int contadorInfo = 0;
            int arregloInfo = 10;





            while (registroInfoReten2.Read() && contadorInfo < totalDatos)
            {

                facturaInfo[arregloInfo] = registroInfoReten2["Id_Tributos"].ToString();

                arregloInfo++;

                facturaInfo[arregloInfo] = registroInfoReten2["Valor"].ToString();
                arregloInfo++;
                contadorInfo++;

            }

            /* string cadenaInfoFactira = "select Contabilidad,Id_Factura,TipoId_EmpFactura,No_idEmpFactura,TipoId_Cliente,No_idCLiente,fechaEmision,Ingreso,Iva,Rte_Fte,Rte_Iva,Rte_Ica,Cta_Cobrar,Nom_EmpFact,Nom_Cliente from fe_comprobantes where Id_Factura = '" + tb_FCIdFactura.Text + "'";
             SqlCommand comandoIF = new SqlCommand(cadenaInfoFactira, conexion);
             SqlDataReader registroIF = comandoIF.ExecuteReader();
             if (registroIF.Read())
             {
                 facturaInfo[1] = registroIF["Contabilidad"].ToString();
                 facturaInfo[2] = registroIF["Id_Factura"].ToString();
                 facturaInfo[3] = registroIF["TipoId_EmpFactura"].ToString();
                 facturaInfo[4] = registroIF["No_idEmpFactura"].ToString();
                 facturaInfo[5] = registroIF["TipoId_Cliente"].ToString();
                 facturaInfo[6] = registroIF["No_idCLiente"].ToString();

                 facturaInfo[7] = registroIF["Ingreso"].ToString();
                 facturaInfo[8] = registroIF["Iva"].ToString();
                 facturaInfo[9] = registroIF["Rte_Fte"].ToString();
                 facturaInfo[10] = registroIF["Rte_Iva"].ToString();
                 facturaInfo[11] = registroIF["Rte_Ica"].ToString();
                 facturaInfo[12] = registroIF["Cta_Cobrar"].ToString();
                 facturaInfo[13] = registroIF["Nom_EmpFact"].ToString();
                 facturaInfo[14] = registroIF["Nom_Cliente"].ToString();
                 facturaInfo[16] = registroIF["fechaEmision"].ToString();
             }
             else
             {
                 MessageBox.Show("La Factura que esta Buscando No Existe!!");
             }*/
            conexion.Close();

            conexion.Open();
            string cadenaTipoFactura = "select Facturas from fe_ParametrosGenerales where NoId = '" + facturaInfo[4] + "' and Contabilidad = '" + facturaInfo[1] + "'";
            SqlCommand comandoTF = new SqlCommand(cadenaTipoFactura, conexion);
            SqlDataReader registroTF = comandoTF.ExecuteReader();
            if (registroTF.Read())
            {
                facturaInfo[8] = registroTF["Facturas"].ToString();
            }

            conexion.Close();

            conexion.Open();
            string cadenaNumCons = "select num_cons from gn_conse where cod_arbo = '" + facturaInfo[1] + "' and cod_cons = '" + facturaInfo[8] + "'";
            SqlCommand comandoNumCons = new SqlCommand(cadenaNumCons, conexion);
            SqlDataReader registroNumCons = comandoNumCons.ExecuteReader();
            if (registroNumCons.Read())
            {
                facturaInfo[9] = registroNumCons["num_cons"].ToString();
            }

            conexion.Close();

            int cantidadCod = 0;
            conexion.Open();
            string cadenaCodigC = "select * from fe_ParametrosContables where No_IdCLiente = '" + facturaInfo[6] + "'";
            SqlCommand comandoCodigC = new SqlCommand(cadenaCodigC, conexion);
            SqlDataReader registroCodigC = comandoCodigC.ExecuteReader();
            while (registroCodigC.Read())
            {
                facturaData[cantidadCod] = registroCodigC[3].ToString();
                facturaType[cantidadCod] = registroCodigC[5].ToString();
                cantidadCod++;
            }
            conexion.Close();
            string[] TipoCuen = new string[99];
            for (int i = 0; i < 6; i++)
            {
                conexion.Open();
                string cadenaCIC = "select cod_cuen,man_trib from dbo.cm_cuent where cod_cuen='" + facturaData[i] + "'";
                SqlCommand leerCIC = new SqlCommand(cadenaCIC, conexion);
                SqlDataReader registroCIC = leerCIC.ExecuteReader();
                if (registroCIC.Read())
                {
                    TipoCuen[i] = registroCIC["man_trib"].ToString();
                }
                conexion.Close();
            }

            bool validarCodigos = true; int movimiento = 0;

            for (int i = 0; i < 6; i++)
            {
                int position = i + 7;
                if (facturaData[i] == "" && facturaInfo[position] != "0.00")
                {
                    validarCodigos = false;
                    movimiento = i;
                    MessageBox.Show(facturaData[i] + " " + facturaInfo[position]);
                }
            }

            if (validarCodigos)
            {
                string ruta = "./Plantilla.xlsx";
                SLDocument sl = new SLDocument(ruta);

                System.Data.DataTable dt = new System.Data.DataTable();
                int CargarDataExcel = 0; int positionDataExcel = 1;
                string[] NombreContabilidad = { "Ingreso", "IVA", "Rte.Fte", "Rte.Iva", "Rte.Ica", "Cta x Cobrar", "" };
                for (int i = 0; i < NombreContabilidad.Length; i++)
                {

                    for (int j = 0; j < facturaInfo.Length; j++)
                    {

                        if (NombreContabilidad[i] == facturaInfo[j])
                        {
                            sl.SetCellValue("A" + positionDataExcel, facturaInfo[8]);
                            sl.SetCellValue("B" + positionDataExcel, int.Parse(facturaInfo[9]));
                            sl.SetCellValue("C" + positionDataExcel, DateTime.Parse(facturaInfo[7]));
                            sl.SetCellValue("D" + positionDataExcel, long.Parse(facturaData[0 + i]));
                            if (TipoCuen[0 + i] == "T")
                            {
                                sl.SetCellValue("E" + positionDataExcel, facturaInfo[6]);
                                sl.SetCellValue("F" + positionDataExcel, facturaInfo[5]);
                            }
                            sl.SetCellValue("H" + positionDataExcel, NombreContabilidad[i] + " FACTURA No. " + facturaInfo[2] + " " + facturaInfo[6]);
                            sl.SetCellValue("J" + positionDataExcel, double.Parse(facturaInfo[j + 1]));
                            sl.SetCellValue("K" + positionDataExcel, facturaType[0 + i]);
                            CargarDataExcel++; positionDataExcel++;
                        }
                    }

                }

                SaveFileDialog guarda = new SaveFileDialog();
                guarda.Filter = "Libro de Excel|*.xlsx";
                guarda.Title = "Guardar Reporte";
                guarda.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                if (guarda.ShowDialog() == DialogResult.OK)
                {
                    sl.SaveAs(guarda.FileName);
                    MessageBox.Show("Archivo Guardado");
                }
            }
            else
            {
                MessageBox.Show("ERROR: La factura tiene Movimientos que Faltan en parametros contables");
            }
            Console.WriteLine("5");

        }

        private void btn_ExcelNC_Click(object sender, EventArgs e)
        {

        }

        private void btn_GuardarExcelND_Click(object sender, EventArgs e)
        {

        }
    }
}





