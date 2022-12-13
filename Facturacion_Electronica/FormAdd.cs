using Facturacion_Electronica;
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

namespace grid
{
    public partial class FormAdd : Form
    {
        llenarcombobox combo = new llenarcombobox();
        SqlConnection conexion = Conexion.Conectar();
        public FormAdd()
        {
            InitializeComponent();
            //cb_Contabilidad.Text = "als";
            combo.seleccionar(cb_Contabilidad);

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void PC_F2Agregar_Click(object sender, EventArgs e)
        {
            if (cb_Contabilidad.Text != "Seleccione un Item..." && cb_TipoIdCliente.Text != "Seleccione un Item..." && txt_NoIdCliente.Text != "")
            {
                conexion.Open();
                string cadenaConsulta = "select nit_clie,tip_iden from dbo.cm_terce where nit_clie='" + txt_NoIdCliente.Text + "' and tip_iden='"+ cb_TipoIdCliente.Text + "'";
                SqlCommand comandoCosnsulta = new SqlCommand(cadenaConsulta, conexion);
                SqlDataReader registroConsulta = comandoCosnsulta.ExecuteReader();
                if (registroConsulta.Read())
                {
                    lbl_TCodCuen.Visible = true; label1.Visible = true; label2.Visible = true; label3.Visible = true; label4.Visible = true; label5.Visible = true;
                    label6.Visible = true; txt_CxC.Visible = true; txt_Ingreso.Visible = true; txt_Iva.Visible = true; txt_rFuente.Visible = true; txt_rIca.Visible = true;
                    txt_rIva.Visible = true; btn_F2Guardar.Visible = true; comboBox1.Visible = true; comboBox2.Visible = true; comboBox3.Visible = true;
                    comboBox4.Visible = true; comboBox5.Visible = true; comboBox6.Visible = true;
                }
                else
                {
                    MessageBox.Show("ERROR : Los datos del cliente incorrectos!");
                }
                conexion.Close();
            }
            else
            {
                MessageBox.Show("Los campos del Cliente deben estar diligenciados");
            }
            
        }

        private void btn_F2Guardar_Click(object sender, EventArgs e)
        {
                bool ValCodigos = true;
                conexion.Open();
                string cont = " ";
                string[] NombreContabilidad = { " ", "Ingreso", "IVA", "Rte.Fte", "Rte.Iva", "Rte.Ica", "Cta x Cobrar" };
                string cadenaConsultaArbol = "select cod_arbo from dbo.gn_arbol where des_arbo='" + cb_Contabilidad.Text + "'";
                SqlCommand comandoCARBOL = new SqlCommand(cadenaConsultaArbol, conexion);
                SqlDataReader registroCArbol = comandoCARBOL.ExecuteReader();
                if (registroCArbol.Read())
                {
                    cont = registroCArbol["cod_arbo"].ToString();
                }
                else
                {
                    MessageBox.Show("ERROR : La Contabilidad Seleccionada no Existe!");
                }
                conexion.Close();

                string[] TipoCuen = new string[50]; string[] CodCuenta = new string[50]; CodCuenta[1] = txt_Ingreso.Text; CodCuenta[2] = txt_Iva.Text; CodCuenta[3] = txt_rFuente.Text;
                CodCuenta[4] = txt_rIva.Text; CodCuenta[5] = txt_rIca.Text; CodCuenta[6] = txt_CxC.Text;

                for (int i = 1; i <= 6; i++)
                {
                    conexion.Open();
                    string cadenaCIC = "select cod_cuen,man_trib from dbo.cm_cuent where cod_cuen='" + CodCuenta[i] + "' and cod_arbo ='"+ cont + "'";
                    SqlCommand leerCIC = new SqlCommand(cadenaCIC, conexion);
                    SqlDataReader registroCIC = leerCIC.ExecuteReader();
                    if (registroCIC.Read())
                    {
                        TipoCuen[i] = registroCIC["man_trib"].ToString();
                    }
                    else
                    {
                        if (CodCuenta[i] == "")
                        {
                            MessageBox.Show("El codigo asignado a (" + NombreContabilidad[i] + ") esta vacio.");
                            TipoCuen[i] = "v";
                        }
                        else
                        {
                            MessageBox.Show("El codigo asignado a (" + NombreContabilidad[i] + ") No Existe!!, Por favor revisar si el codigo esta bien escrito o se encuntra registrado.");
                            ValCodigos = false;
                        }
                    }
                    conexion.Close();
                }

                if (ValCodigos)
                {
                    string Contabilidad = cont; 
                    string tipoId_Client = cb_TipoIdCliente.Text;
                    string No_Client = txt_NoIdCliente.Text;
                    conexion.Open();
                    string cadena = "insert into fe_ParametrosContables values(@Contabilidad, @TipoId_Cliente, @No_idCLiente, @Cod_Cuenta, @Tipo_Cuenta, @Tipo_Mov, @Man_Trib)";
                    SqlCommand agregar = new SqlCommand(cadena, conexion);

                    agregar.Parameters.Clear();

                    agregar.Parameters.AddWithValue("@Contabilidad", Contabilidad);
                    agregar.Parameters.AddWithValue("@TipoId_Cliente", tipoId_Client);
                    agregar.Parameters.AddWithValue("@No_idCLiente", No_Client);
                    agregar.Parameters.AddWithValue("@Tipo_Cuenta", "Ingreso");
                    agregar.Parameters.AddWithValue("@Cod_Cuenta", txt_Ingreso.Text);
                    agregar.Parameters.AddWithValue("@Tipo_Mov", comboBox1.Text);
                    agregar.Parameters.AddWithValue("@Man_Trib", TipoCuen[1]);

                    agregar.ExecuteNonQuery();

                    agregar.Parameters.Clear();

                    agregar.Parameters.AddWithValue("@Contabilidad", Contabilidad);
                    agregar.Parameters.AddWithValue("@TipoId_Cliente", tipoId_Client);
                    agregar.Parameters.AddWithValue("@No_idCLiente", No_Client);
                    agregar.Parameters.AddWithValue("@Tipo_Cuenta", "IVA");
                    agregar.Parameters.AddWithValue("@Cod_Cuenta", txt_Iva.Text);
                    agregar.Parameters.AddWithValue("@Tipo_Mov", comboBox2.Text);
                    agregar.Parameters.AddWithValue("@Man_Trib", TipoCuen[2]);

                    agregar.ExecuteNonQuery();

                    agregar.Parameters.Clear();

                    agregar.Parameters.AddWithValue("@Contabilidad", Contabilidad);
                    agregar.Parameters.AddWithValue("@TipoId_Cliente", tipoId_Client);
                    agregar.Parameters.AddWithValue("@No_idCLiente", No_Client);
                    agregar.Parameters.AddWithValue("@Tipo_Cuenta", "Rte.Fte");
                    agregar.Parameters.AddWithValue("@Cod_Cuenta", txt_rFuente.Text);
                    agregar.Parameters.AddWithValue("@Tipo_Mov", comboBox3.Text);
                    agregar.Parameters.AddWithValue("@Man_Trib", TipoCuen[3]);

                    agregar.ExecuteNonQuery();

                    agregar.Parameters.Clear();

                    agregar.Parameters.AddWithValue("@Contabilidad", Contabilidad);
                    agregar.Parameters.AddWithValue("@TipoId_Cliente", tipoId_Client);
                    agregar.Parameters.AddWithValue("@No_idCLiente", No_Client);
                    agregar.Parameters.AddWithValue("@Tipo_Cuenta", "Rte.Iva");
                    agregar.Parameters.AddWithValue("@Cod_Cuenta", txt_rIva.Text);
                    agregar.Parameters.AddWithValue("@Tipo_Mov", comboBox4.Text);
                    agregar.Parameters.AddWithValue("@Man_Trib", TipoCuen[4]);

                    agregar.ExecuteNonQuery();

                    agregar.Parameters.Clear();

                    agregar.Parameters.AddWithValue("@Contabilidad", Contabilidad);
                    agregar.Parameters.AddWithValue("@TipoId_Cliente", tipoId_Client);
                    agregar.Parameters.AddWithValue("@No_idCLiente", No_Client);
                    agregar.Parameters.AddWithValue("@Tipo_Cuenta", "Rte.Ica");
                    agregar.Parameters.AddWithValue("@Cod_Cuenta", txt_rIca.Text);
                    agregar.Parameters.AddWithValue("@Tipo_Mov", comboBox5.Text);
                    agregar.Parameters.AddWithValue("@Man_Trib", TipoCuen[5]);

                    agregar.ExecuteNonQuery();

                    agregar.Parameters.Clear();

                    agregar.Parameters.AddWithValue("@Contabilidad", Contabilidad);
                    agregar.Parameters.AddWithValue("@TipoId_Cliente", tipoId_Client);
                    agregar.Parameters.AddWithValue("@No_idCLiente", No_Client);
                    agregar.Parameters.AddWithValue("@Tipo_Cuenta", "Cta x Cobrar");
                    agregar.Parameters.AddWithValue("@Cod_Cuenta", txt_CxC.Text);
                    agregar.Parameters.AddWithValue("@Tipo_Mov", comboBox6.Text);
                    agregar.Parameters.AddWithValue("@Man_Trib", TipoCuen[6]);

                    agregar.ExecuteNonQuery();

                    MessageBox.Show("Datos agregados con Exito");
                    conexion.Close();

                    lbl_TCodCuen.Visible = false; label1.Visible = false; label2.Visible = false; label3.Visible = false; label4.Visible = false; label5.Visible = false;
                    label6.Visible = false; txt_CxC.Visible = false; txt_Ingreso.Visible = false; txt_Iva.Visible = false; txt_rFuente.Visible = false; txt_rIca.Visible = false;
                    txt_rIva.Visible = false; btn_F2Guardar.Visible = false; comboBox1.Visible = false; comboBox2.Visible = false; comboBox3.Visible = false;
                    comboBox4.Visible = false; comboBox5.Visible = false; comboBox6.Visible = false;

                    txt_Ingreso.Text = "";
                    txt_Iva.Text = "";
                    txt_rFuente.Text = "";
                    txt_rIca.Text = "";
                    txt_rIva.Text = "";
                    txt_CxC.Text = "";
                    txt_NoIdCliente.Text = "";
                    this.Close();
                }
                
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
            Form formulario1 = new Pagina_Principal();
            //formulario1.Show();
            formulario1.Update();
        }

        private void PC_F2Buscar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string cont = " ";

            string cadenaConsultaArbol = "select cod_arbo from dbo.gn_arbol where des_arbo='" + cb_Contabilidad.Text + "'";
            SqlCommand comandoCARBOL = new SqlCommand(cadenaConsultaArbol, conexion);
            SqlDataReader registroCArbol = comandoCARBOL.ExecuteReader();
            if (registroCArbol.Read())
            {
                cont = registroCArbol["cod_arbo"].ToString();
            }
            else
            {
                MessageBox.Show("ERROR : La Contabilidad Seleccionada no Existe!");
            }
            conexion.Close();

            if (txt_NoIdCliente.Text == " " || cb_Contabilidad.Text == "Seleccione un Item..." || cb_TipoIdCliente.Text == " ")
            {
                MessageBox.Show("Los campos (Id Cliente, Contabilidad, Tipo Id) no pueden estar vacios.");
            }
            else
            {
                string[] CodCuen = new string[50]; string[] TipoMov = new string[50]; int position = 1;
                conexion.Open();
                string cadenaCons = "select Cod_Cuenta,Tipo_Mov from fe_ParametrosContables where No_idCLiente='" + txt_NoIdCliente.Text + "' and TipoId_Cliente='" + cb_TipoIdCliente.Text+ "' and Contabilidad ='"+ cont + "'";
                SqlCommand comandoCons = new SqlCommand(cadenaCons, conexion);
                SqlDataReader registroCons = comandoCons.ExecuteReader();
                if (registroCons.Read())
                {
                    CodCuen[0]=registroCons["Cod_Cuenta"].ToString();
                    TipoMov[0] = registroCons["Tipo_Mov"].ToString();
                    while (registroCons.Read())
                    {
                        CodCuen[position]=registroCons[0].ToString();
                        TipoMov[position]=registroCons[1].ToString();
                        position++;
                    }
                    conexion.Close();

                    txt_Ingreso.Text = CodCuen[0];
                    txt_Iva.Text = CodCuen[1];
                    txt_rFuente.Text = CodCuen[2];
                    txt_rIva.Text = CodCuen[3];
                    txt_rIca.Text = CodCuen[4];
                    txt_CxC.Text = CodCuen[5];

                    comboBox1.Text = TipoMov[0];
                    comboBox2.Text = TipoMov[1];
                    comboBox3.Text = TipoMov[2];
                    comboBox4.Text = TipoMov[3];
                    comboBox5.Text = TipoMov[4];
                    comboBox6.Text = TipoMov[5];

                    lbl_TCodCuen.Visible = true; label1.Visible = true; label2.Visible = true; label3.Visible = true; label4.Visible = true; label5.Visible = true;
                    label6.Visible = true; txt_CxC.Visible = true; txt_Ingreso.Visible = true; txt_Iva.Visible = true; txt_rFuente.Visible = true; txt_rIca.Visible = true;
                    txt_rIva.Visible = true;  comboBox1.Visible = true; comboBox2.Visible = true; comboBox3.Visible = true;
                    comboBox4.Visible = true; comboBox5.Visible = true; comboBox6.Visible = true; button1.Visible = true;

                    //registroCons["Contabilidad"].ToString();

                }
                else
                {
                    MessageBox.Show("No existe resulato de esta Consulta");
                    conexion.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*conexion.Open();
            string cadenaDelete = "DELETE FROM fe_ParametrosContables where No_idCLiente = '"+ txt_NoIdCliente.Text + "'";
            SqlCommand delete = new SqlCommand(cadenaDelete, conexion);
            delete.ExecuteNonQuery();
            conexion.Close();

            conexion.Open();
            string cont = " ";

            string cadenaConsultaArbol = "select cod_arbo from dbo.gn_arbol where des_arbo='" + cb_Contabilidad.Text + "'";
            SqlCommand comandoCARBOL = new SqlCommand(cadenaConsultaArbol, conexion);
            SqlDataReader registroCArbol = comandoCARBOL.ExecuteReader();
            if (registroCArbol.Read())
            {
                cont = registroCArbol["cod_arbo"].ToString();
            }
            else
            {
                MessageBox.Show("ERROR : La Contabilidad Seleccionada no Existe!");
            }
            conexion.Close();

            string[] TipoCuen = new string[50]; string[] CodCuenta = new string[50]; CodCuenta[1] = txt_Ingreso.Text; CodCuenta[2] = txt_Iva.Text; CodCuenta[3] = txt_rFuente.Text;
            CodCuenta[4] = txt_rIva.Text; CodCuenta[5] = txt_rIca.Text; CodCuenta[6] = txt_CxC.Text;

            for (int i = 1; i <= 6; i++)
            {
                conexion.Open();
                string cadenaCIC = "select cod_cuen,man_trib from dbo.cm_cuent where cod_cuen='" + CodCuenta[i] + "'";
                SqlCommand leerCIC = new SqlCommand(cadenaCIC, conexion);
                SqlDataReader registroCIC = leerCIC.ExecuteReader();
                if (registroCIC.Read())
                {
                    TipoCuen[i] = registroCIC["man_trib"].ToString();
                }
                else
                {
                    //MessageBox.Show("El codigo " + CodCuenta[i] + " No Existe");
                    CodCuenta[i] = "nn";
                }
                conexion.Close();
            }


            string Contabilidad = cont;
            string tipoId_Client = cb_TipoIdCliente.Text;
            string No_Client = txt_NoIdCliente.Text;

            string[] NombreContabilidad = { " ","Ingreso", "IVA", "Rte.Fte", "Rte.Iva", "Rte.Ica", "Cta x Cobrar"};
            //MessageBox.Show(NombreContabilidad[i]);
            string[] CodigosG = new string[99]; CodigosG[1] = txt_Ingreso.Text; CodigosG[2] = txt_Iva.Text; CodigosG[3] = txt_rFuente.Text;
            CodigosG[4] = txt_rIva.Text; CodigosG[5] = txt_rIca.Text; CodigosG[6] = txt_CxC.Text;
            string[] TipoMovG = new string[99]; TipoMovG[1] = comboBox1.Text; TipoMovG[2] = comboBox2.Text; TipoMovG[3] = comboBox3.Text;
            TipoMovG[4] = comboBox4.Text; TipoMovG[5] = comboBox5.Text; TipoMovG[6] = comboBox6.Text;
            for (int i =1;i<=6;i++)
            {
                    conexion.Open();
                    string Mod = "update fe_ParametrosContables set Contabilidad='" + cont + "' , TipoId_Cliente='" + cb_TipoIdCliente.Text + "' , No_idCLiente='" + txt_NoIdCliente.Text + "' , Cod_Cuenta='" + CodigosG[i] + "' , Tipo_Cuenta='"+ NombreContabilidad[i]+ "' ,Tipo_Mov='" + TipoMovG[i] + "', Man_Trib='" + TipoCuen[i] + "' where Contabilidad ='" + cont + "' and No_idCLiente='" + txt_NoIdCliente.Text + "' and Tipo_Cuenta ='" + NombreContabilidad[i] + "'";
                    SqlCommand Modificar = new SqlCommand(Mod, conexion);
                    Modificar.ExecuteNonQuery();
                    conexion.Close(); //MessageBox.Show(NombreContabilidad[i]);

            }

            MessageBox.Show("Datos agregados con Exito");
            conexion.Close();

            lbl_TCodCuen.Visible = false; label1.Visible = false; label2.Visible = false; label3.Visible = false; label4.Visible = false; label5.Visible = false;
            label6.Visible = false; txt_CxC.Visible = false; txt_Ingreso.Visible = false; txt_Iva.Visible = false; txt_rFuente.Visible = false; txt_rIca.Visible = false;
            txt_rIva.Visible = false; btn_F2Guardar.Visible = false; comboBox1.Visible = false; comboBox2.Visible = false; comboBox3.Visible = false;
            comboBox4.Visible = false; comboBox5.Visible = false; comboBox6.Visible = false;

            txt_Ingreso.Text = "";
            txt_Iva.Text = "";
            txt_rFuente.Text = "";
            txt_rIca.Text = "";
            txt_rIva.Text = "";
            txt_CxC.Text = "";
            txt_NoIdCliente.Text = "";*/
        }

        private void cb_Contabilidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}