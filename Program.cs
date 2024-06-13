using System.Threading.Tasks.Dataflow;
using FabricarPersonajes;
using RellenarPersonajes;
using ManejoJson;

FabricaDePersonajes fabricarPj = new FabricaDePersonajes(); //instancio FabricaDePersonajes

List<Personaje> enemigos = fabricarPj.CrearEnemigos(); //creo los enemigos 

PersonajesJson enemigosJson = new PersonajesJson(); //instancio PersonajesJson

string nombreArchivo = "enemigos.json";
enemigosJson.GuardarPersonaje(enemigos, nombreArchivo);   //guardo los enemigos creador en un json

List<Personaje> enemigosLeer = enemigosJson.LeerPersonajes(nombreArchivo);

foreach (Personaje enemigo in enemigosLeer)
{
    Console.WriteLine($"Nombre del enemigo {enemigo.Nombre}");
}

