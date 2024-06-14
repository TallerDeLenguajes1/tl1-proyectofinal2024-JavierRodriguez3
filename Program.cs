using FabricarPersonajes;
using RellenarPersonajes;
using ManejoJson;
using ManejoJsonGanadores;

FabricaDePersonajes fabricarPj = new FabricaDePersonajes(); //instancio FabricaDePersonajes

List<Personaje> enemigos = await fabricarPj.CrearEnemigos(); //creo los enemigos 

PersonajesJson enemigosJson = new PersonajesJson(); //instancio PersonajesJson


string nombreArchivo = "Json/enemigos.json";
enemigosJson.GuardarPersonaje(enemigos, nombreArchivo);   //guardo los enemigos creador en un json

List<Personaje> enemigosLeer = enemigosJson.LeerPersonajes(nombreArchivo);

List<Personaje> winners = new List<Personaje>();

foreach (Personaje enemigo in enemigosLeer)
{
    Console.WriteLine($"Nombre del enemigo {enemigo.Nombre}");
    if (enemigo.Win == true)
    {
        winners.Add(enemigo);
    }
}

GanadoresJson ganadoresJson = new GanadoresJson();

string nombreArchivo2 = "Json/ganadores.json";
ganadoresJson.GuardarGanador(winners, nombreArchivo2);


List<Personaje> ganadorLeer = ganadoresJson.LeerGanador(nombreArchivo2);

foreach (Personaje ganador in ganadorLeer)
{
    Console.WriteLine($"Nombres de los ganadores {ganador.Nombre}");
}
