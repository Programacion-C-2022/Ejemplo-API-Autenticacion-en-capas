# Ejempo de Autenticacion - API en arquitectura en Capas

Levantar la API en Visual Studio, queda y usar un cliente REST como Insomina para mandarle una peticion.

## Uso
Tiene que mandarse una peticion a la URL http://localhost:8888/autenticar, de tipo POST.

Si no cumple con eso, la aplicacion devuelve "404 no encontrado", en formato JSON:

```
{
	"codigo": "404",
	"mensaje": "URL no encontrada"
}
```
Tiene que enviarsele un JSON como cuerpo del request con este contenido:

```
{
	"usuario" : "ejemploUsuario",
	"password" : "ejemploPassword"
}
```
Ejemplo de peticion con Insomina:
![enter image description here](https://i.postimg.cc/g0RbMRBX/Screenshot-2022-06-26-203008.png)

Si la autenticacion es correcta, devuelve este JSON:
```
{
	"codigo": "1",
	"mensaje": "Credenciales correctas"
}
```

Sino, devuelve este JSON:
```
{
	"codigo": "-1",
	"mensaje": "Credenciales invalidas"
}
```
