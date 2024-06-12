using System.Threading.Tasks.Dataflow;
using FabricarPersonajes;
using RellenarPersonajes;

FabricaDePersonajes fabricarPj = new FabricaDePersonajes();

List<Personaje> enemigos = fabricarPj.CrearEnemigos();


foreach (Personaje enemigo in enemigos)
{
    Console.WriteLine($"Nombre del enemigo {enemigo.Nombre}");
}

