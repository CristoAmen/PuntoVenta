using PuntoVentaV2.Cajero.Clase_Con;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PuntoVentaV2.Gerencia;

namespace PuntoVentaV2
{
    internal class Modelo
    {
        public ClassUsuario porUsuario(string usuario)
        {
            MySqlDataReader reader;
            MySqlConnection conexion = ConexionL.getConexion();
            conexion.Open();

            string sql = "SELECT idUsuario, pass FROM usuarios WHERE idUsuario LIKE @idUsuario";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@idUsuario", usuario);

            reader = comando.ExecuteReader();

            ClassUsuario usr = null;

            while (reader.Read())
            {
                usr = new ClassUsuario();
                usr.Id = int.Parse(reader["idUsuario"].ToString());
                usr.Password = reader["pass"].ToString();
            }
            return usr;
        }
    }
}
