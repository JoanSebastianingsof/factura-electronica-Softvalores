using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

namespace Facturacion_Electronica
{
    class Conexion 
    {
        public static SqlConnection Conectar()
        {
            TextReader LeerBaseDatos = new StreamReader("DataBase.txt");
            string DBinfo = LeerBaseDatos.ReadToEnd();
            LeerBaseDatos.Close();

            char[] limitador = { '"' };
            string[] arreglo = DBinfo.Split(limitador, StringSplitOptions.RemoveEmptyEntries);

            string cadenaCon = "data source = " + arreglo[1] + "; initial catalog = " + arreglo[3] + "; user id = " + arreglo[5] + "; password = " + arreglo[7] + "";

            SqlConnection con = new SqlConnection();

            try
            {
                SqlConnection ConexionBD = new SqlConnection(cadenaCon);
                return ConexionBD;
            }
            catch (SqlException ex)
            {
                return null;
            }
        }
    }
}
