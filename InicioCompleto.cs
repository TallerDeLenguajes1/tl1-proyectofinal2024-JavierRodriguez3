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

            Console.WriteLine("\n#########################################################################################");
            Console.WriteLine("###########################         Cuartos de Final          ###########################");
            Console.WriteLine("#########################################################################################\n");

            List<Personaje> segundoAsalto = torneo.inicioTorneo(enemigos);

            Console.WriteLine("\n##################################################################################");
            Console.WriteLine("###########################         Semi Final          ##########################");
            Console.WriteLine("##################################################################################\n");

            List<Personaje> tercerAsalto = torneo.inicioTorneo(segundoAsalto);

            Console.WriteLine("\n###################################################################################");
            Console.WriteLine("###########################         La Gran Final          ########################");
            Console.WriteLine("###################################################################################\n");

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