using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace Facturacion_Electronica
{
    class llenarcombobox
    {
        SqlConnection con = Conexion.Conectar();

        public void seleccionar(ComboBox cb)
        {
            cb.Items.Clear();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from dbo.gn_arbol", con);
            SqlDataReader dr = cmd.ExecuteReader();
            string[] arrayConsulta = null;
            while (dr.Read()) 
            {
               // cb.Items.Add( dr[1].ToString());

                 string[] array = {
                 //cb.Items.Add( dr[0].ToString());
                  dr[0].ToString(),
                  dr[1].ToString()
                 };
                 arrayConsulta= array ;
                 cb.Items.Add(arrayConsulta[1]);

            }
            con.Close();
            cb.Items.Insert(0, "Seleccione un Item...");
            cb.SelectedIndex = 0;
        }

        public string[] captarInfo(string nombre)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from dbo.gn_arbol where des_arbo='" + nombre + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            string[] resultado = null;
            while (dr.Read())
            {
                string[] valores =
                {
                    dr[0].ToString(),
                    dr[2].ToString(),
                    dr[3].ToString()
                };
                resultado = valores;

            }
            con.Close();
            return resultado;
        }
        public void captarTributo(ComboBox cb )
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select Nom_Tributo from fe_Tributo", con);
            SqlDataReader dr = cmd.ExecuteReader();
           // string[] resultado = null;
            while (dr.Read())
            {
                cb.Items.Add(dr[0].ToString());

            }
            con.Close();
            cb.Items.Insert(0, "Seleccione un Item...");
            cb.SelectedIndex = 0;
        }
        public void captarTipIden(ComboBox cb)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select Tip_Iden from fe_TipoIden", con);
            SqlDataReader dr = cmd.ExecuteReader();
            // string[] resultado = null;
            while (dr.Read())
            {
                cb.Items.Add(dr[0].ToString());

            }
            con.Close();
            cb.Items.Insert(0, "Seleccione un Item...");
            cb.SelectedIndex = 0;
        }
        public void cargar(ComboBox cb, int id)
        {
            cb.Items.Clear();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from dbo.gn_conse where cod_arbo='" + id + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb.Items.Add(dr[1].ToString());
            }
            con.Close();
            cb.Items.Insert(0, "Seleccione un Item...");
            cb.SelectedIndex = 0;
        }

        public void cargarClientes(ComboBox cb, int id,string Tid)
        {
            cb.Items.Clear();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from fe_parametrosContables where Contabilidad='" + id + "' and Tipo_Cuenta ='Ingreso'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb.Items.Add(dr[2].ToString());
            }
            con.Close();
            cb.Items.Insert(0, "Seleccione un Item...");
            cb.SelectedIndex = 0;
        }

        public void cargarNomClientes(ComboBox cb, int id, string Tid)
        {
            cb.Items.Clear();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from fe_parametrosContables where Contabilidad='" + id + "' and Tipo_Cuenta ='Ingreso'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            string [] ids = new string[19]; int position = 0;
            while (dr.Read())
            {
                ids[position] = (dr[2].ToString());
                position++;
            }
            con.Close();
            
            for (int x=0; x < ids.Length; x++)
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select nom_terc from dbo.cm_terce where nit_clie='" + ids[x] + "' and tip_iden ='"+Tid+"'", con);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                if (dr1.Read())
                {
                    cb.Items.Add(dr1["nom_terc"].ToString());
                }
                con.Close();
            }
            
            cb.Items.Insert(0, "Seleccione un Item...");
            cb.SelectedIndex = 0;
        }
    }
}
