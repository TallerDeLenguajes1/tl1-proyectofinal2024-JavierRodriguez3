using InicioCompleto;
using FabricarPersonajes;
using RellenarPersonajes;
using textoLindo;

Console.CursorVisible = false;

textoProgram lindoTexto = new textoProgram();


lindoTexto.MostrarMensaje();


FabricaDePersonajes Pj = new FabricaDePersonajes();

List<Personaje> MostrarEnemigos = await Pj.CrearEnemigos();



string art = @"  _             __  __ _       _    _____                    _____                             _   _ _       _       
 | |           |  \/  (_)     (_)  / ____|                  / ____|                           | \ | (_)     (_)      
 | |     __ _  | \  / |_ _ __  _  | |  __ _ __ __ _ _ __   | |  __ _   _  ___ _ __ _ __ __ _  |  \| |_ _ __  _  __ _ 
 | |    / _` | | |\/| | | '_ \| | | | |_ | '__/ _` | '_ \  | | |_ | | | |/ _ \ '__| '__/ _` | | . ` | | '_ \| |/ _` |
 | |___| (_| | | |  | | | | | | | | |__| | | | (_| | | | | | |__| | |_| |  __/ |  | | | (_| | | |\  | | | | | | (_| |
 |______\__,_| |_|  |_|_|_| |_|_|  \_____|_|  \__,_|_| |_|  \_____|\__,_|\___|_|  |_|  \__,_| |_| \_|_|_| |_| |\__,_|
                                                                                                           _/ |      
                                                                                                          |__/       ";

Console.WriteLine(art);


Console.WriteLine("Ingresar una letra para presentar a los luchadores");
Console.ReadKey(true);
Console.Clear();

string art2 = @"  _____  ______ _      ______          _____   ____  _____  ______  _____ 
 |  __ \|  ____| |    |  ____|   /\   |  __ \ / __ \|  __ \|  ____|/ ____|
 | |__) | |__  | |    | |__     /  \  | |  | | |  | | |__) | |__  | (___  
 |  ___/|  __| | |    |  __|   / /\ \ | |  | | |  | |  _  /|  __|  \___ \ 
 | |    | |____| |____| |____ / ____ \| |__| | |__| | | \ \| |____ ____) |
 |_|    |______|______|______/_/    \_\_____/ \____/|_|  \_\______|_____/ 
                                                                          ";
Console.WriteLine(art2);
int i = 1;
foreach (Personaje pj in MostrarEnemigos)
{
    Console.WriteLine($"{i}.{pj.Nombre}");
    i++;
}

PeleaCompleta inicio = new PeleaCompleta();

await inicio.IniciarPeleaCompleta();
