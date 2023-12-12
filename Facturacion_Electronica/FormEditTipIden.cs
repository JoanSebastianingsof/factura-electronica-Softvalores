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
    public partial class FormEditTipIden : Form
    {
        llenarcombobox combo = new llenarcombobox();
        SqlConnection conexion = Conexion.Conectar();

        public FormEditTipIden()
        {
            InitializeComponent();
            combo.captarTipIden(cbTipoIdentificacion);

        }

        private void btnActualizarTributo_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string Descripcion = cbTipoIdentificacion.Text; string id = tbTipoIdentificacion.Text; 

            string cadenaConsultaTributo = "select * from dbo.fe_TipoIden where Tip_Iden='" + Descripcion + "'";
            SqlCommand comandoTributo = new SqlCommand(cadenaConsultaTributo, conexion);
            SqlDataReader registroTributo = comandoTributo.ExecuteReader();
            if (registroTributo.Read())
            {
                if ((registroTributo["Tip_Iden"].ToString()) == Descripcion)
                {
                    conexion.Close();

                    conexion.Open();
                    string update = "update fe_TipoIden set Codigo_Dian='" + id + "' where Tip_Iden='" + Descripcion + "'";
                    SqlCommand actualizar = new SqlCommand(update, conexion);
                    actualizar.ExecuteNonQuery();
                    conexion.Close();
                    cbTipoIdentificacion.Text = "";
                    tbTipoIdentificacion.Text = "";
                    MessageBox.Show("Registro actualizado");
                }
                else
                {
                    MessageBox.Show("ERROR :El tipo de identificación No existe!");

                }


            }
            else
            {

                MessageBox.Show("ERROR!");
                conexion.Close();

            }
            this.Close();
        }
    }
}
