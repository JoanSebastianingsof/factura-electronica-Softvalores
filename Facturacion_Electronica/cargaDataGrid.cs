using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

namespace Facturacion_Electronica
{
    class cargaDataGrid
    {
        
        public void cargaPG(DataGridView dg)
        {
            TextReader LeerBaseDatos = new StreamReader("DataBase.txt");
            string DBinfo = LeerBaseDatos.ReadToEnd();
            LeerBaseDatos.Close();

            char[] limitador = { '"' };
            string[] arreglo = DBinfo.Split(limitador, StringSplitOptions.RemoveEmptyEntries);

            string cadenaCon = "data source = " + arreglo[1] + "; initial catalog = " + arreglo[3] + "; user id = " + arreglo[5] + "; password = " + arreglo[7] + "";
            SqlConnection con = new SqlConnection(cadenaCon);

            dg.Rows.Clear();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from fe_ParametrosGenerales order by Contabilidad", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                dg.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
            }
            con.Close();
        }

        public void cargaFC(DataGridView dg)
        {
            TextReader LeerBaseDatos = new StreamReader("DataBase.txt");
            string DBinfo = LeerBaseDatos.ReadToEnd();
            LeerBaseDatos.Close();

            char[] limitador = { '"' };
            string[] arreglo = DBinfo.Split(limitador, StringSplitOptions.RemoveEmptyEntries);

            string cadenaCon = "data source = " + arreglo[1] + "; initial catalog = " + arreglo[3] + "; user id = " + arreglo[5] + "; password = " + arreglo[7] + "";
            SqlConnection con = new SqlConnection(cadenaCon);


            dg.Rows.Clear();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from fe_comprobantes", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                dg.Rows.Add(dr[1].ToString(), dr[0].ToString(), dr[13].ToString(), dr[14].ToString(), dr[6].ToString(), dr[15].ToString());
            }
            con.Close();
        }

        public void cargaPC(DataGridView dg)
        {
            TextReader LeerBaseDatos = new StreamReader("DataBase.txt");
            string DBinfo = LeerBaseDatos.ReadToEnd();
            LeerBaseDatos.Close();

            char[] limitador = { '"' };
            string[] arreglo = DBinfo.Split(limitador, StringSplitOptions.RemoveEmptyEntries);

            string cadenaCon = "data source = " + arreglo[1] + "; initial catalog = " + arreglo[3] + "; user id = " + arreglo[5] + "; password = " + arreglo[7] + "";
            SqlConnection con = new SqlConnection(cadenaCon);

            dg.Rows.Clear();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from fe_parametrosContables", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if ((dr[6].ToString()) == "T")
                {
                    dg.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
                }
                else
                {
                    dg.Rows.Add(" ", " ", dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
                }
            }
            con.Close();
        }
    }
}
