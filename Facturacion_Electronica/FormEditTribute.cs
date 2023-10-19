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
    public partial class FormEditTribute : Form
    {
        llenarcombobox combo = new llenarcombobox();
        SqlConnection conexion = Conexion.Conectar();


        public FormEditTribute()
        {
            InitializeComponent();
            combo.captarTributo(comboBox1);

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* if (comboBox1.SelectedIndex > 0)
            {
                string[] valores = combo.captarInfo(comboBox1.Text);
                int id = Int32.Parse(valores[0]);

                combo.captarTributo(captarTributo, id);
            }*/
        }

        private void FormEditTribute_Load(object sender, EventArgs e)
        {

        }

        private void btnActualizarTributo_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string nombre = comboBox1.Text; string id = tbIdentificadorTrib.Text; string cont = " ";

            string cadenaConsultaTributo = "select * from dbo.fe_Tributo where Nom_Tributo='" + nombre + "'";
            SqlCommand comandoTributo = new SqlCommand(cadenaConsultaTributo, conexion);
            SqlDataReader registroTributo = comandoTributo.ExecuteReader();
            if (registroTributo.Read())
            {
                if ((registroTributo["Nom_Tributo"].ToString()) == nombre)
                {
                    conexion.Close();

                    conexion.Open();
                    string update = "update fe_Tributo set identificador='" + id + "' where Nom_Tributo='" + nombre + "'";
                    SqlCommand actualizar = new SqlCommand(update, conexion);
                    actualizar.ExecuteNonQuery();
                    conexion.Close();
                    comboBox1.Text = "";
                    tbIdentificadorTrib.Text = "";
                    MessageBox.Show("Registro actualizado");
                }
                else
                {
                    MessageBox.Show("ERROR :El tributo No existe!");

                }


            }
            else
            {

                MessageBox.Show("ERROR!");
                conexion.Close();

            }
            this.Close();
           /* conexion.Open();
            SqlCommand cmd = new SqlCommand("select * from fe_Tributo", conexion);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                dataGridTributo.Rows.Add(dr[1].ToString(), dr[2].ToString());
            }
            conexion.Close();*/
        }
    }
}
