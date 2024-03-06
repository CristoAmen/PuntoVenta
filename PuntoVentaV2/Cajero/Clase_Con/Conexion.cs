using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoVentaV2.Cajero.Clase_Con
{
    internal class Conexion
    {
        //Esto son cosas para conectarse al Servidor, ya que no podia hacerlo de la forma facil, joder
        MySqlConnection conex = new MySqlConnection();


        static string servidor = "localhost";
        static string bd = "puntoventa";
        static string usuario = "root";
        static string password = "admin";
        static string puerto = "3306";


        string CadenaConexion = "server = " + servidor + ";" + "port = " + puerto + ";" +
            "user id = " + usuario + ";" + "password = " + password + ";" + "Database = " + bd + ";";

        public MySqlConnection establecerCon()
        {

            try
            {

                conex.ConnectionString = CadenaConexion;
                conex.Open();

            }
            catch (Exception ex)
            {
            }
            return conex;
        }
        public void cerrar()
        {
            conex.Close();
        }
    }
}
