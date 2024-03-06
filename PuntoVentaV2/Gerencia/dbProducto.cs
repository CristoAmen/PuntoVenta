using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PuntoVentaV2.Gerencia
{
    internal class dbProducto
    {
        private MySqlConnection conexion;
        private String strConexion;
        private MySqlCommand comando;
        private String strConsulta;
        private MySqlDataAdapter adaptador;

        public dbProducto()
        {
            conexion = new MySqlConnection();
            strConexion = "Server=localhost;UserId=root;Password=admin;DataBase=puntoventa";
            conexion.ConnectionString = strConexion;
            comando = new MySqlCommand();
            adaptador = new MySqlDataAdapter();
        }

        public Boolean abrir()
        {
            Boolean exito = false;
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
                exito = true;
            }
            return exito;
        }

        public Boolean cerrar()
        {
            Boolean exito = false;
            if (conexion.State == ConnectionState.Closed)
            {
                exito = false;
            }
            else
            {
                conexion.Close();
                exito = true;
            }
            return exito;
        }
        public DataTable ConsultarCodigo(ClassProducto obj)
        {
            DataTable datos = new DataTable();
            String sqlConsulta = "select  ID, nombre, precio from producto where ID = @ID";
            comando.Parameters.Clear();
            comando.Parameters.Add("@ID", MySqlDbType.Int16).Value = obj.Id;
            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.cerrar();
            return datos;
        }
        public void Agregar(ClassProducto obj)
        {
            String sqlConsulta = "insert into producto (nombre, precio) values(@nombre, @precio)";
            comando.Parameters.Clear();
            comando.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = obj.Nombre;
            comando.Parameters.Add("@precio", MySqlDbType.Float).Value = obj.Precio;

            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.cerrar();
        }
    }
}
