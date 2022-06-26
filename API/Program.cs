using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Net;
using Newtonsoft.Json;
using CapaLogica;

namespace API
{
    class Program
    {
        

        static void Main(string[] args)
        {

            // Crear e iniciar el Listener HTTP
            HttpListener listener = new HttpListener();
            string listenUrl = "http://127.0.0.1:8888/";
            listener.Prefixes.Add(listenUrl);
            listener.Start();
            Console.WriteLine("Listening...");

            while (true)
            {
                // Obtener contexto del Listener para extraer informacion
                HttpListenerContext context = listener.GetContext();

                // Extraer el request del contexto del listener
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;

                // Imprimir el log del request en consola
                Log(request);

                // Crear respuesta y enviarla
                EnviarRespuesta(request,response);
            }
        }

        static void EnviarRespuesta(HttpListenerRequest request, HttpListenerResponse response) {
            string body; // Variable para guardar el cuerpo de la respuesta

            // Diccionario que generara el JSON de respuesta
            Dictionary<string, string> camposJsonDeSalida = new Dictionary<string, string>();

            // Si la URL del request no es /autenticar,
            // y el metodo HTTP no es POST (el cual se usa para recibir
            // datos de entrada desde el cliente, devolvemos 404 no encontrado.
            // NO SE DEBE RESPONDER PETICIONES QUE NO SEAN POST!!!
            if (request.Url.AbsolutePath != "/autenticar" || request.HttpMethod != "POST")
            {
                response.StatusCode = 404;
                camposJsonDeSalida.Add("codigo", "404");
                camposJsonDeSalida.Add("mensaje", "URL no encontrada");

            }
            // Si la URL es /autenticar y el metodo HTTP es POST, llamamos la funcion 
            // GenerarRespuesta de la clase estatica Autenticar,
            // que evalua las credenciales obtenidas por en el request.
            // Eso ya nos da el diccionario de respuesta para serializar.
            else
            {
                 camposJsonDeSalida = Autenticar.GenerarRespuesta(request);
            }

            // Serializamos a JSON el diccionario de respuesta
            body = JsonConvert.SerializeObject(camposJsonDeSalida);

            // Indicamos que el tipo de respuesta es JSON
            response.ContentType = "application/json";
            
            // Creamos el buffer de respuesta y la enviamos al cliente
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(body);
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);

        }
        
        
        public static void Log(HttpListenerRequest request)
        {
            Console.WriteLine(request.RemoteEndPoint + " " + request.HttpMethod + " " + request.RawUrl);
        }
    }
}
