using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using PuntoVentaV2.Cajero.Clase_Con;

namespace PuntoVentaV2.Gerencia
{
    internal class dbUsuario
    {
        private MySqlConnection conexion;
        private String strConexion;
        private MySqlCommand comando;
        private String strConsulta;
        private MySqlDataAdapter adaptador;

        public dbUsuario()
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
        public DataTable Consultar(String tabla)
        {
            DataTable datos = new DataTable();
            String sqlConsulta = "select * from empleados";

            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.cerrar();
            return datos;
        }
        public DataTable ConsultarU(String tabla)
        {
            DataTable datos = new DataTable();
            String sqlConsulta = "select * from usuarios";

            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.cerrar();
            return datos;
        }
        public DataTable ConsultarCodigo(ClassUsuario obj)
        {
            DataTable datos = new DataTable();
            String sqlConsulta = "select idUsuario, pass from usuarios where idUsuario = @idUsuario";
            comando.Parameters.Clear();
            comando.Parameters.Add("@idUsuario", MySqlDbType.Int16).Value = obj.Id;
            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.cerrar();
            return datos;
        }
        public void Agregar(ClassUsuario obj)
        {
            String sqlConsulta = "insert into usuarios (idUsuario, pass, puesto) values(@idUsuario, @pass, @puesto)";
            comando.Parameters.Clear();
            comando.Parameters.Add("@idUsuario", MySqlDbType.Int16).Value = obj.Id;
            comando.Parameters.Add("@pass", MySqlDbType.VarChar).Value = obj.Password;
            comando.Parameters.Add("@puesto", MySqlDbType.Int16).Value = obj.Puesto;
            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.cerrar();
        }
        public void Actualizar(ClassUsuario obj)
        {
            String sqlConsulta = "update usuarios set pass = @pass where idUsuario = @idUsuario";
            comando.Parameters.Clear();
            comando.Parameters.Add("@idUsuario", MySqlDbType.Int16).Value = obj.Id;
            comando.Parameters.Add("@pass", MySqlDbType.VarChar).Value = obj.Password;
            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.cerrar();
        }
        public void EliminarU(ClassUsuario obj)
        {
            String sqlConsulta = "delete from usuarios where idUsuario = @idUsuario";
            comando.Parameters.Clear();
            comando.Parameters.Add("@idUsuario", MySqlDbType.Int16).Value = obj.Id;
            comando.Parameters.Add("@pass", MySqlDbType.VarChar).Value = obj.Password;
            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.cerrar();
        }
        public DataTable Login(ClassUsuario obj)
        {
            DataTable datos = new DataTable();
            String sqlConsulta = "select idUsuario, pass, puesto from usuarios where idUsuario = @idUsuario";
            comando.Parameters.Clear();
            comando.Parameters.Add("@idUsuario", MySqlDbType.Int16).Value = obj.Id;
            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.cerrar();
            return datos;
        }
        public DataTable ConsultarPuesto(ClassUsuario obj)
        {
            DataTable datos = new DataTable();
            String sqlConsulta = "select * from usuarios where idUsuario = @idUsuario";
            comando.Parameters.Clear();
            comando.Parameters.Add("@idUsuario", MySqlDbType.Int16).Value = obj.Id;
            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.cerrar();
            return datos;
        }
        public void EliminarUDE(ClassUsuario obj)
        {
            String sqlConsulta = "delete from usuarios where idUsuario = @idUsuario";
            comando.Parameters.Clear();
            comando.Parameters.Add("@idUsuario", MySqlDbType.Int16).Value = obj.Id;
            comando.Parameters.Add("@pass", MySqlDbType.VarChar).Value = obj.Password;
            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.cerrar();
        }
    }
}
