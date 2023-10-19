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

namespace Facturacion_Electronica
{
    public partial class FormEdit : Form
    {
        llenarcombobox combo = new llenarcombobox();
        SqlConnection conexion = Conexion.Conectar();
        String oldContabilidad;
        String oldTipoId;
        String oldNoId;
        public FormEdit(string R_Cont,string R_TipoId,string R_NoId)
        {
            InitializeComponent();
            combo.seleccionar(cb_Contabilidad);
            cb_Contabilidad.Text = R_Cont;
            cb_TipoIdCliente.Text = R_TipoId;
            txt_NoIdCliente.Text = R_NoId;
            oldContabilidad = R_Cont;
            oldTipoId = R_TipoId;
            oldNoId = R_NoId;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btn_F2Guardar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string cadenaConsultaArbolOld = "select cod_arbo from dbo.gn_arbol where des_arbo='" + oldContabilidad + "'";
            SqlCommand comandoCARBOLOld = new SqlCommand(cadenaConsultaArbolOld, conexion);
            SqlDataReader registroCArbolOld = comandoCARBOLOld.ExecuteReader();
            if (registroCArbolOld.Read())
            {
                oldContabilidad = registroCArbolOld["cod_arbo"].ToString();
            }
            else
            {
                MessageBox.Show("ERROR : La Contabilidad Seleccionada no Existe!");
            }
            conexion.Close();
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
                string cadenaCIC = "select cod_cuen,man_trib from dbo.cm_cuent where cod_cuen='" + CodCuenta[i] + "'  and cod_arbo ='" + cont + "'";
                SqlCommand leerCIC = new SqlCommand(cadenaCIC, conexion);
                SqlDataReader registroCIC = leerCIC.ExecuteReader();
                if (registroCIC.Read())
                {
                    TipoCuen[i] = registroCIC["man_trib"].ToString();
                }
                else
                {
                    if (CodCuenta[i] == "            ")
                    {
                        MessageBox.Show("El codigo asignado a (" + NombreContabilidad[i]+") esta vacio.");
                        CodCuenta[i] = "nn";
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

                string[] CodigosG = new string[99]; CodigosG[1] = txt_Ingreso.Text; CodigosG[2] = txt_Iva.Text; CodigosG[3] = txt_rFuente.Text;
                CodigosG[4] = txt_rIva.Text; CodigosG[5] = txt_rIca.Text; CodigosG[6] = txt_CxC.Text;
                string[] TipoMovG = new string[99]; TipoMovG[1] = comboBox1.Text; TipoMovG[2] = comboBox2.Text; TipoMovG[3] = comboBox3.Text;
                TipoMovG[4] = comboBox4.Text; TipoMovG[5] = comboBox5.Text; TipoMovG[6] = comboBox6.Text;
                for (int i = 1; i <= 6; i++)
                {
                    conexion.Open();
                    string Mod = "update fe_ParametrosContables set Contabilidad='" + cont + "' , TipoId_Cliente='" + tipoId_Client + "' , No_idCLiente='" + No_Client + "' , Cod_Cuenta='" + CodigosG[i] + "' , Tipo_Cuenta='" + NombreContabilidad[i] + "' ,Tipo_Mov='" + TipoMovG[i] + "', Man_Trib='" + TipoCuen[i] + "' where Contabilidad ='" + oldContabilidad + "' and No_idCLiente='" + oldNoId + "' and Tipo_Cuenta ='" + NombreContabilidad[i] + "'";
                    SqlCommand Modificar = new SqlCommand(Mod, conexion);
                    Modificar.ExecuteNonQuery();
                    conexion.Close();
                }
                MessageBox.Show("Datos agregados con Exito");
                conexion.Close();
                this.Close();
            }
        }

        private void PC_F2Buscar_Click(object sender, EventArgs e)
        {

        }

        private void FormEdit_Load(object sender, EventArgs e)
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
                string cadenaCons = "select Cod_Cuenta,Tipo_Mov from fe_ParametrosContables where No_idCLiente='" + txt_NoIdCliente.Text + "' and TipoId_Cliente='" + cb_TipoIdCliente.Text + "' and Contabilidad ='" + cont + "'";
                SqlCommand comandoCons = new SqlCommand(cadenaCons, conexion);
                SqlDataReader registroCons = comandoCons.ExecuteReader();
                if (registroCons.Read())
                {
                    CodCuen[0] = registroCons["Cod_Cuenta"].ToString();
                    TipoMov[0] = registroCons["Tipo_Mov"].ToString();
                    while (registroCons.Read())
                    {
                        CodCuen[position] = registroCons[0].ToString();
                        TipoMov[position] = registroCons[1].ToString();
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
                    txt_rIva.Visible = true; comboBox1.Visible = true; comboBox2.Visible = true; comboBox3.Visible = true;
                    comboBox4.Visible = true; comboBox5.Visible = true; comboBox6.Visible = true; //button1.Visible = true;

                }
                else
                {
                    MessageBox.Show("No existe resulato de esta Consulta");
                    conexion.Close();
                }
            }
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_Ingreso_TextChanged(object sender, EventArgs e)
        {

        }

        private void PC_F2Agregar_Click(object sender, EventArgs e)
        {

        }

        private void cb_Contabilidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
