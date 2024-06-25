using InicioCompleto;
using FabricarPersonajes;
using RellenarPersonajes;
using ManejoJson;
using ManejoJsonGanadores;
using torneo;

Console.WriteLine("######################################################");
Console.WriteLine("###########################Bievenido a la Mini Gran Guerra Ninja###########################");
Console.WriteLine("######################################################");

Console.WriteLine("Ingresar una letra");
Console.ReadKey();

PeleaCompleta inicio = new PeleaCompleta();

await inicio.IniciarPeleaCompleta();
