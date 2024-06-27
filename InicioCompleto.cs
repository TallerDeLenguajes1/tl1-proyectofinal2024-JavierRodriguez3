namespace InicioCompleto;
using FabricarPersonajes;
using RellenarPersonajes;
using ManejoJson;
using ManejoJsonGanadores;
using torneo;


public class PeleaCompleta
    {
        public async Task IniciarPeleaCompleta()
        {
            FabricaDePersonajes fabricarPj = new FabricaDePersonajes(); // Instancio FabricaDePersonajes

            List<Personaje> enemigos = await fabricarPj.CrearEnemigos(); // Creo los enemigos (método asincrónico)

            PersonajesJson enemigosJson = new PersonajesJson(); // Instancio PersonajesJson

            string nombreArchivo;
            if (!Directory.Exists("./Json"))
                {
                    Directory.CreateDirectory("./Json");
                    nombreArchivo = "Json/enemigos.json";
                    enemigosJson.GuardarPersonaje(enemigos, nombreArchivo);
                }
            nombreArchivo = "Json/enemigos.json";
            enemigosJson.GuardarPersonaje(enemigos, nombreArchivo);   // Guardo los enemigos creados en un JSON

            Console.WriteLine("Ingresar una letra para comenzar el torneo");
            Console.ReadKey(true);

            Torneo torneo = new Torneo();

            string art = @"   _____ _    _         _____ _______ ____   _____   _____  ______   ______ _____ _   _          _      
  / ____| |  | |  /\   |  __ \__   __/ __ \ / ____| |  __ \|  ____| |  ____|_   _| \ | |   /\   | |     
 | |    | |  | | /  \  | |__) | | | | |  | | (___   | |  | | |__    | |__    | | |  \| |  /  \  | |     
 | |    | |  | |/ /\ \ |  _  /  | | | |  | |\___ \  | |  | |  __|   |  __|   | | | . ` | / /\ \ | |     
 | |____| |__| / ____ \| | \ \  | | | |__| |____) | | |__| | |____  | |     _| |_| |\  |/ ____ \| |____ 
  \_____|\____/_/    \_\_|  \_\ |_|  \____/|_____/  |_____/|______| |_|    |_____|_| \_/_/    \_\______|
                                                                                                        
                                                                                                        ";
            Console.WriteLine(art);

            List<Personaje> segundoAsalto = torneo.inicioTorneo(enemigos);

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

            List<Personaje> ganadores = new List<Personaje>();

            foreach (Personaje ganador in enemigos)
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