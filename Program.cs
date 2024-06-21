using FabricarPersonajes;
using RellenarPersonajes;
using ManejoJson;
using ManejoJsonGanadores;
using torneo;

FabricaDePersonajes fabricarPj = new FabricaDePersonajes(); //instancio FabricaDePersonajes

List<Personaje> enemigos = await fabricarPj.CrearEnemigos(); //creo los enemigos 

PersonajesJson enemigosJson = new PersonajesJson(); //instancio PersonajesJsonñ

string nombreArchivo = "Json/enemigos.json";
enemigosJson.GuardarPersonaje(enemigos, nombreArchivo);   //guardo los enemigos creador en un json


Torneo primerTorneo = new Torneo();

List<Personaje> segundoAsalto = new List<Personaje>();

List<Personaje> tercerAsalto = new List<Personaje>();

segundoAsalto = primerTorneo.inicioTorneo(enemigos);

tercerAsalto = primerTorneo.inicioTorneo(segundoAsalto);

primerTorneo.inicioTorneo(tercerAsalto);

List<Personaje> ganadores = new List<Personaje>();

foreach (Personaje ganador in enemigos)
{
    ganadores.Add(ganador);
}


GanadoresJson ganadoresJson = new GanadoresJson();

string nombreArchivo2 = "Json/ganadores.json";
ganadoresJson.GuardarGanador(ganadores, nombreArchivo2);


List<Personaje> ganadorLeer = ganadoresJson.LeerGanador(nombreArchivo2);

foreach (Personaje ganador in ganadorLeer){
    Console.WriteLine($"Nombres de los ganadores {ganador.Nombre}");
}