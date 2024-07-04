using InicioCompleto;
using FabricarPersonajes;
using RellenarPersonajes;
using ShowProgram;

Console.CursorVisible = false;

textoProgram ShowProgram = new textoProgram();


ShowProgram.MostrarMensaje();

PeleaCompleta inicio = new PeleaCompleta();

await inicio.IniciarPeleaCompleta();
