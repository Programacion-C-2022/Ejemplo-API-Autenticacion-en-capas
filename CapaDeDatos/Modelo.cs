using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace CapaDeDatos
{
    public abstract class Modelo
    {
        public string IpBaseDeDatos;
        public string UsuarioBaseDeDatos;
        public string PasswordBaseDeDatos;
        public string NombreBaseDeDatos;
        public string PuertoBaseDeDatos;
        public MySqlConnection conexion;
        public MySqlCommand comando;
        public MySqlDataReader dataReader;


        public Modelo()
        {
            conectarBaseDeDatos();
            inicializarComando();

        }

        private void inicializarComando()
        {
            this.comando = new MySqlCommand();
            this.comando.Connection = this.conexion;
        }

        private void conectarBaseDeDatos()
        {
            this.inicializarConexion();
            this.conexion = new MySqlConnection(
                $"server={this.IpBaseDeDatos};" +
                $"userid={this.UsuarioBaseDeDatos};" +
                $"password={this.PasswordBaseDeDatos};" +
                $"database={this.NombreBaseDeDatos};" +
                $"port={this.PuertoBaseDeDatos}"
            );
            this.conexion.Open();
        }

        private void inicializarConexion()
        {
            this.IpBaseDeDatos = "127.0.0.1";
            this.NombreBaseDeDatos = "autenticacion";
            this.UsuarioBaseDeDatos = "root";
            this.PasswordBaseDeDatos = "root";
        }
    }
}
