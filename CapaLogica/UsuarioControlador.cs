using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;

namespace CapaLogica
{
    public class UsuarioControlador
    {
        public static bool Autenticar(string nombre, string password)
        {
            // Se crea instancia del modelo
            UsuarioModelo u = new UsuarioModelo();
            // Se asigna el nombre de usuario a la instancia
            u.Nombre = nombre;
            // Se llama la funcion autenticar, indicandole el nombre de usuario
            return u.Autenticar(password);
        }

        public static void Alta(string nombre, string password)
        {
            UsuarioModelo u = new UsuarioModelo();

            u.Nombre = nombre;
            u.Password = password;
            u.Guardar();
        }

       

    }

}
