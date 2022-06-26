using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using CapaLogica;
using Newtonsoft.Json;


namespace API
{
    public class Autenticar
    {
        // Esta funcion devuelve un diccionario con datos de error o exito
        // de la autenticacion que llegue en el request
        public static Dictionary<string, string> GenerarRespuesta(HttpListenerRequest request)
        {
            // Llamamos a la funcion que extrae las credenicales del cuerpo de la
            // peticion del usuario
            string cuerpo = extraerCuerpoDeRequest(request);

            // Evaluamos las credenicales recibidas, y generamos una respuesta con eso
            Dictionary<string, string> respuesta = evaluarCredenciales(cuerpo);

            // Devolvemos el diccionario de respuesta para que se envie
            // como response HTTP al cliente
            return respuesta;

        }

        // Esta funcion extrae el cuerpo de la peticion (request) que llega por POST en formato JSON
        private static string extraerCuerpoDeRequest(HttpListenerRequest request)
        {
            string cuerpo;
            using (var reader = new System.IO.StreamReader(request.InputStream, request.ContentEncoding))
            {
                cuerpo = reader.ReadToEnd();
            }

            return cuerpo;
        }

        // Esta funcion evalua el JSON recibido en la peticion del cliente, y verifica 
        // que las credenciales sean correctas, llamando al controlador UsuarioControlador
        // de la capa logica.
        private static Dictionary<string, string> evaluarCredenciales(string cuerpo)
        {
            // Deserializamos el JSON recibido y lo convertimos a un diccionario llamado "credenciales",
            // el cual tendra los campos "usuario" y "password"
            Dictionary<string,string> credenciales = JsonConvert.DeserializeObject<Dictionary<string,string>>(cuerpo);

            // Creamos un diccionario para devolver como respuesta
            Dictionary<string, string> resultadoAutenticacion = new Dictionary<string, string>();

            if (UsuarioControlador.Autenticar(credenciales["usuario"], credenciales["password"]) == true)
            {
                // Diccionario de autenticacion exitosa
                resultadoAutenticacion.Add("codigo", "1");
                resultadoAutenticacion.Add("mensaje", "Credenciales correctas");
            }
            else
            {
                // Diccionario de autenticacion fallida
                resultadoAutenticacion.Add("codigo", "-1");
                resultadoAutenticacion.Add("mensaje", "Credenciales invalidas");
            }
           
            // Devolvemos el diccionario generado
            return resultadoAutenticacion;
        }

        
    }
}
