using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PuntoVentaV2.Gerencia
{
    internal class dbEmpleado
    {
        private MySqlConnection conexion;
        private String strConexion;
        private MySqlCommand comando;
        private String strConsulta;
        private MySqlDataAdapter adaptador;

        public dbEmpleado()
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

        public void Agregar(ClassEmpleado obj)
        {
            String sqlConsulta = "insert into empleados (nombre, aPaterno, aMaterno, curp, numTel, puesto) values(@nombre, @aPaterno, @aMaterno, @curp, @numTel, @puesto)";
            comando.Parameters.Clear();
            comando.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = obj.Nombre;
            comando.Parameters.Add("@aPaterno", MySqlDbType.VarChar).Value = obj.aPaterno;
            comando.Parameters.Add("@aMaterno", MySqlDbType.VarChar).Value = obj.aMaterno;
            comando.Parameters.Add("@curp", MySqlDbType.VarChar).Value = obj.Curp;
            comando.Parameters.Add("@numTel", MySqlDbType.VarChar).Value = obj.Telefono;
            comando.Parameters.Add("@puesto", MySqlDbType.Int16).Value = obj.Puesto;
            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.cerrar();
        }

        public DataTable ConsultarCodigoH(ClassEmpleado obj)
        {
            DataTable datos = new DataTable();
            String sqlConsulta = "select  idEmpleado, nombre, aPaterno, aMaterno, curp, numTel, puesto from empleados where curp = @curp";
            comando.Parameters.Clear();
            comando.Parameters.Add("@curp", MySqlDbType.VarChar).Value = obj.Curp;
            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.cerrar();
            return datos;
        }
        public void EliminarE(ClassEmpleado obj)
        {
            String sqlConsulta = "delete from empleados where idEmpleado = @idEmpleado";
            comando.Parameters.Add("@idEmpleado", MySqlDbType.Int16).Value = obj.Id;
            comando.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = obj.Nombre;
            comando.Parameters.Add("@aPaterno", MySqlDbType.VarChar).Value = obj.aPaterno;
            comando.Parameters.Add("@aMaterno", MySqlDbType.VarChar).Value = obj.aMaterno;
            comando.Parameters.Add("@curp", MySqlDbType.VarChar).Value = obj.Curp;
            comando.Parameters.Add("@numTel", MySqlDbType.VarChar).Value = obj.Telefono;
            comando.Parameters.Add("@puesto", MySqlDbType.Int16).Value = obj.Puesto;
            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.cerrar();
        }
        public DataTable ConsultarTodos()
        {
            DataTable datos = new DataTable();
            String strConsulta = "select * from empleados";
            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = strConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.cerrar();
            return datos;
        }
        public DataTable Consultar(String tabla)
        {
            DataTable datos = new DataTable();
            String sqlConsulta = "select * from puesto";

            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.cerrar();
            return datos;
        }
        public DataTable ConsultarPuesto(ClassEmpleado obj)
        {
            DataTable datos = new DataTable();
            String sqlConsulta = "select * from empleados where idEmpleado = @idEmpleado";
            comando.Parameters.Clear();
            comando.Parameters.Add("@idEmpleado", MySqlDbType.Int16).Value = obj.Id;
            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.cerrar();
            return datos;
        }
        public DataTable DesactivarFK()
        {
            DataTable datos = new DataTable();
            String sqlConsulta = "SET FOREIGN_KEY_CHECKS=0;";

            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.cerrar();
            return datos;
        }
        public DataTable ActivarFK()
        {
            DataTable datos = new DataTable();
            String sqlConsulta = "SET FOREIGN_KEY_CHECKS=1;";

            this.abrir();
            comando.Connection = conexion;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.cerrar();
            return datos;
        }
    }
}
