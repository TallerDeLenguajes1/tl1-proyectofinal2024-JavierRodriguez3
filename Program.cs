using InicioCompleto;
using FabricarPersonajes;
using RellenarPersonajes;

Console.CursorVisible = false;

FabricaDePersonajes Pj = new FabricaDePersonajes();

List<Personaje> MostrarEnemigos = await Pj.CrearEnemigos();


Console.WriteLine("\n#############################################################################################################");
Console.WriteLine("###########################         Bievenido a la Mini Gran Guerra Ninja         ###########################");
Console.WriteLine("#############################################################################################################\n");




Console.WriteLine("Ingresar una letra para presentar a los luchadores");
Console.ReadKey(true);
Console.Clear();

Console.WriteLine("\n###############################################################################################################");
Console.WriteLine("###########################         Los protagonistas de este torneo seran:         ###########################");
Console.WriteLine("###############################################################################################################\n");

int i = 1;
foreach (Personaje pj in MostrarEnemigos)
{
    Console.WriteLine($"{i}.{pj.Nombre}");
    i++;
}

PeleaCompleta inicio = new PeleaCompleta();

await inicio.IniciarPeleaCompleta();
