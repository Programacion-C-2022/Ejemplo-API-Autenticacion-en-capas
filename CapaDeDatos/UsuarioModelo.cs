using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class UsuarioModelo : Modelo
    {
        public int Id;
        public string Nombre;
        public string Password;

        public UsuarioModelo(int id)
        {
            this.Obtener(id);
        }

        public UsuarioModelo()
        {

        }


        public bool Autenticar(string passwordEntrada)
        {
            // Busca un usuario por el nombre
            this.ObtenerPorNombre();
            // Si ni existe el nombre de usuario, se devuelve false y falla la autenticacion
            if (this.Nombre == "") return false;
            // Si existe el nombre de usuario y coincide con el password ingresado con el hash almacenado, 
            // pasa la autenticacion con exito
            if (this.Password == hashearPassword(passwordEntrada)) return true;
            // Si ni existe el nombre de usuario, se devuelve false y falla la autenticacion
            return false;
        }
        public void ObtenerPorNombre()
        {
            // Se busca el nombre de usuario y password hasheado
            this.comando.CommandText = "SELECT nombre,password FROM usuarios WHERE nombre = @nombre";
            this.comando.Parameters.AddWithValue("@nombre", this.Nombre);
            this.comando.Prepare();
            this.dataReader = this.comando.ExecuteReader();

            // Si no devuelve filas la consulta, se sale de la funcion
            if (!this.dataReader.HasRows) return;

            // Si devuelve filas, se agregan los datos de la fila a los campos de la instancia
            this.dataReader.Read();
            this.Nombre = this.dataReader["nombre"].ToString();
            this.Password = this.dataReader["password"].ToString();
        }



        public void Guardar()
        {
            if (this.Id.ToString() != "0") Actualizar();
            else Insertar();
        }

        private void Insertar()
        {
            this.comando.CommandText = "INSERT INTO usuarios VALUES (@id, @nombre,@password)";
            this.comando.Parameters.AddWithValue("@id", this.Id.ToString());
            this.comando.Parameters.AddWithValue("@nombre", this.Nombre);
            this.comando.Parameters.AddWithValue("@password", hashearPassword(this.Password));
            this.comando.Prepare();
            this.comando.ExecuteNonQuery();
        }

        private string hashearPassword(string password)
        {
            return MD5Hash.Hash.Content(password);
        }

        public void Obtener(int id)
        {
            obtenerFilaPorId(id);
            llenarCamposDesdeDataReader();

        }

        private void llenarCamposDesdeDataReader()
        {
            this.Id = Int32.Parse(this.dataReader["id"].ToString());
            this.Nombre = this.dataReader["nombre"].ToString();
            
        }

        private void obtenerFilaPorId(int id)
        {
            this.comando.CommandText = "SELECT id,nombre FROM usuarios WHERE id = @id";
            this.comando.Parameters.AddWithValue("@id", id);
            this.comando.Prepare();
            this.dataReader = this.comando.ExecuteReader();
            this.dataReader.Read();
        }

        private void Actualizar()
        {
            this.comando.CommandText = "UPDATE usuarios SET " +
                "nombre = @nombre," +
                "password = @password" +
                " WHERE id = @id";

            this.comando.Parameters.AddWithValue("@nombre", this.Nombre);
            this.comando.Parameters.AddWithValue("@password", this.Password);
            this.comando.Parameters.AddWithValue("@id", this.Id);
            this.comando.Prepare();
            this.comando.ExecuteNonQuery();
        }

        public void Eliminar()
        {
            this.comando.CommandText = "DELETE FROM usuarios WHERE id = @id";
            this.comando.Parameters.AddWithValue("@id", this.Id);
            this.comando.Prepare();
            this.comando.ExecuteNonQuery();
        }

        public List<UsuarioModelo> Obtener()
        {
            List<UsuarioModelo> usuarios = obtenerTodasLasFilas();
            crearArrayDePersonas(usuarios);
            return usuarios;

        }
        

       
    
        private void crearArrayDePersonas(List<UsuarioModelo> usuarios)
        {
            while (this.dataReader.Read())
            {
                UsuarioModelo u = new UsuarioModelo();
                u.Id = Int32.Parse(dataReader["id"].ToString());
                u.Nombre = dataReader["nombre"].ToString();

                usuarios.Add(u);
            }
        }

        private List<UsuarioModelo> obtenerTodasLasFilas()
        {
            List<UsuarioModelo> usuarios = new List<UsuarioModelo>();
            this.comando.CommandText = "SELECT id,nombre FROM usuarios";
            this.dataReader = this.comando.ExecuteReader();
            return usuarios;
        }
    }
}
