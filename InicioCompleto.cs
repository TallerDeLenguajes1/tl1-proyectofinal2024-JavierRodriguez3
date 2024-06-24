namespace InicioCompleto;
using FabricarPersonajes;
using RellenarPersonajes;
using ManejoJson;
using ManejoJsonGanadores;
using torneo;
using System;
using System.Collections.Generic;

public class PeleaCompleta
    {
        public async Task IniciarPeleaCompleta()
        {
            FabricaDePersonajes fabricarPj = new FabricaDePersonajes(); // Instancio FabricaDePersonajes

            List<Personaje> enemigos = await fabricarPj.CrearEnemigos(); // Creo los enemigos (método asincrónico)

            PersonajesJson enemigosJson = new PersonajesJson(); // Instancio PersonajesJson

            string nombreArchivo = "Json/enemigos.json";
            enemigosJson.GuardarPersonaje(enemigos, nombreArchivo);   // Guardo los enemigos creados en un JSON

            Torneo torneo = new Torneo();

            List<Personaje> segundoAsalto = torneo.inicioTorneo(enemigos);

            List<Personaje> tercerAsalto = torneo.inicioTorneo(segundoAsalto);

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