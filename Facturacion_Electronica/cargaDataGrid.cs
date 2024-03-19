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
            SqlCommand cmd = new SqlCommand("select fe_ParametrosGenerales.Contabilidad ,fe_ParametrosGenerales.Facturas , fe_ParametrosGenerales.TipoId ,fe_ParametrosGenerales.NoId, gn_arbol.des_arbo from fe_ParametrosGenerales LEFT JOIN gn_arbol ON fe_ParametrosGenerales.Contabilidad=gn_arbol.cod_arbo order by fe_ParametrosGenerales.Contabilidad ", con);
            SqlDataReader dr = cmd.ExecuteReader();
            /* SqlCommand cmd = new SqlCommand("select xx,yy,zz from table1 inner join table2 on table1.XXX=table2.YYY", new SqlConnection("Your connection string here"));

             cmd.Connection.Open();

             SqlDataReader sr = cmd.ExecuteReader();*/
            /*SELECT Customers.CustomerName, Customers.ContactName,Customers.Address, Orders.OrderID
            FROM Customers
            LEFT JOIN Orders
            ON Customers.CustomerID = Orders.CustomerID
            ORDER BY Customers.CustomerName;*/


            while (dr.Read())
            {
                dg.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
            }
            con.Close();
        }

        public void cargaTri(DataGridView dg)
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
            SqlCommand cmd = new SqlCommand("select * from fe_Tributo", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                dg.Rows.Add(dr[1].ToString(), dr[2].ToString());
            }
            con.Close();
        }

        public void cargaIdentificacion(DataGridView dg)
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
            SqlCommand cmd = new SqlCommand("select * from fe_TipoIden", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                dg.Rows.Add(dr[1].ToString(), dr[2].ToString());
            }
            con.Close();
        }


        public void cargaFC(DataGridView dg, string CampoTabla)
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
            string[] facturas = new string[99];
            string[] Empresaid = new string[99];

            int i = 0;
            SqlCommand cmds = new SqlCommand("select "+CampoTabla+",NoId from fe_parametrosgenerales", con);
            SqlDataReader drs = cmds.ExecuteReader();
            while (drs.Read())
            {
                facturas[i] = drs[CampoTabla].ToString();
                Empresaid[i] = drs["NoId"].ToString();
                i++;
            }
            con.Close();

            con.Open();

            for (int a =0; a <Empresaid.Length;a++)
            {
                if (!string.IsNullOrEmpty(facturas[a]))
                {
                    SqlCommand cmd = new SqlCommand("select * from fe_comprobantesV2 where LEFT(id_factura, 2)=@IdFactura and No_IdEmpFactura=@IdEmpresa", con);
                    cmd.Parameters.AddWithValue("@IdFactura", facturas[a]);
                    cmd.Parameters.AddWithValue("@IdEmpresa", Empresaid[a]);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            dg.Rows.Add(dr[2].ToString(), dr[1].ToString(), dr[4].ToString(), dr[6].ToString(), dr[7].ToString(), dr[9].ToString());
                        }
                    }
                }                                   
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
