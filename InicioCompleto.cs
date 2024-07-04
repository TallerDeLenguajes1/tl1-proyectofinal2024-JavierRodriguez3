namespace InicioCompleto;
using FabricarPersonajes;
using RellenarPersonajes;
using ManejoJson;
using ManejoJsonGanadores;
using torneo;


public class PeleaCompleta
    {
    private static void peleasTorneo(List<Personaje> personajes)
    {
        Torneo torneo = new Torneo();

        string art = @"   _____ _    _         _____ _______ ____   _____   _____  ______   ______ _____ _   _          _      
  / ____| |  | |  /\   |  __ \__   __/ __ \ / ____| |  __ \|  ____| |  ____|_   _| \ | |   /\   | |     
 | |    | |  | | /  \  | |__) | | | | |  | | (___   | |  | | |__    | |__    | | |  \| |  /  \  | |     
 | |    | |  | |/ /\ \ |  _  /  | | | |  | |\___ \  | |  | |  __|   |  __|   | | | . ` | / /\ \ | |     
 | |____| |__| / ____ \| | \ \  | | | |__| |____) | | |__| | |____  | |     _| |_| |\  |/ ____ \| |____ 
  \_____|\____/_/    \_\_|  \_\ |_|  \____/|_____/  |_____/|______| |_|    |_____|_| \_/_/    \_\______|
                                                                                                        
                                                                                                        ";
        Console.WriteLine(art);

        List<Personaje> segundoAsalto = torneo.inicioTorneo(personajes);

        string art2 = @"   _____ ______ __  __ _____   ______ _____ _   _          _      
  / ____|  ____|  \/  |_   _| |  ____|_   _| \ | |   /\   | |     
 | (___ | |__  | \  / | | |   | |__    | | |  \| |  /  \  | |     
  \___ \|  __| | |\/| | | |   |  __|   | | | . ` | / /\ \ | |     
  ____) | |____| |  | |_| |_  | |     _| |_| |\  |/ ____ \| |____ 
 |_____/|______|_|  |_|_____| |_|    |_____|_| \_/_/    \_\______|
                                                                  
                                                                  ";
        Console.WriteLine(art2);
        List<Personaje> tercerAsalto = torneo.inicioTorneo(segundoAsalto);

        string art3 = @"  ______ _____ _   _          _      
 |  ____|_   _| \ | |   /\   | |     
 | |__    | | |  \| |  /  \  | |     
 |  __|   | | | . ` | / /\ \ | |     
 | |     _| |_| |\  |/ ____ \| |____ 
 |_|    |_____|_| \_/_/    \_\______|
                                     
                                     ";
        Console.WriteLine(art3);

        torneo.inicioTorneo(tercerAsalto);
    }

    private static void PresentacionJuego(string nombre)
    {
        string artA = @"  _             __  __ _       _    _____                    _____                             _   _ _       _       
 | |           |  \/  (_)     (_)  / ____|                  / ____|                           | \ | (_)     (_)      
 | |     __ _  | \  / |_ _ __  _  | |  __ _ __ __ _ _ __   | |  __ _   _  ___ _ __ _ __ __ _  |  \| |_ _ __  _  __ _ 
 | |    / _` | | |\/| | | '_ \| | | | |_ | '__/ _` | '_ \  | | |_ | | | |/ _ \ '__| '__/ _` | | . ` | | '_ \| |/ _` |
 | |___| (_| | | |  | | | | | | | | |__| | | | (_| | | | | | |__| | |_| |  __/ |  | | | (_| | | |\  | | | | | | (_| |
 |______\__,_| |_|  |_|_|_| |_|_|  \_____|_|  \__,_|_| |_|  \_____|\__,_|\___|_|  |_|  \__,_| |_| \_|_|_| |_| |\__,_|
                                                                                                           _/ |      
                                                                                                          |__/       ";

        Console.WriteLine(artA);


        Console.WriteLine("Ingresar una letra para presentar a los luchadores");
        Console.ReadKey(true);
        Console.Clear();

        PersonajesJson presentarJson = new PersonajesJson();

        string artB = @"  _____  ______ _      ______          _____   ____  _____  ______  _____ 
 |  __ \|  ____| |    |  ____|   /\   |  __ \ / __ \|  __ \|  ____|/ ____|
 | |__) | |__  | |    | |__     /  \  | |  | | |  | | |__) | |__  | (___  
 |  ___/|  __| | |    |  __|   / /\ \ | |  | | |  | |  _  /|  __|  \___ \ 
 | |    | |____| |____| |____ / ____ \| |__| | |__| | | \ \| |____ ____) |
 |_|    |______|______|______/_/    \_\_____/ \____/|_|  \_\______|_____/ 
                                                                          ";
        Console.WriteLine(artB);
        List<Personaje> personajes = presentarJson.LeerPersonajes(nombre);
        int i = 1;
        foreach (Personaje pj in personajes)
        {
            Console.WriteLine($"{i}.{pj.Nombre}");
            i++;
        }
    }
        public async Task IniciarPeleaCompleta()
    {

        FabricaDePersonajes fabricarPj = new FabricaDePersonajes(); // Instancio FabricaDePersonajes

        List<Personaje> personajes = await fabricarPj.llenarLista(); // Creo los personajes (método asincrónico)

        PersonajesJson personajesJson = new PersonajesJson(); // Instancio PersonajesJson

        string nombreArchivo;

        nombreArchivo = "Json/personajes.json";

        if (!Directory.Exists("./Json"))
        {
            Directory.CreateDirectory("./Json");
            nombreArchivo = "Json/personajes.json";
            personajesJson.GuardarPersonaje(personajes, nombreArchivo);
        }
        personajesJson.GuardarPersonaje(personajes, nombreArchivo);   // Guardo los personajes creados en un JSON

        PresentacionJuego(nombreArchivo);


        Console.WriteLine("Ingresar una letra para comenzar el torneo");
        Console.ReadKey(true);
        peleasTorneo(personajes);

        List<Personaje> ganadores = new List<Personaje>();

        foreach (Personaje ganador in personajes)
        {
            ganadores.Add(ganador);
        }

        GanadoresJson ganadoresJson = new GanadoresJson();

        string nombreArchivo2 = "Json/ganadores.json";
        ganadoresJson.GuardarGanador(ganadores, nombreArchivo2);

        List<Personaje> ganadorLeer = ganadoresJson.LeerGanador(nombreArchivo2);

        foreach (Personaje ganador in ganadorLeer)
        {
            Console.WriteLine($"Nombres de los ganadores: {ganador.Nombre}");
        }
    }

}














