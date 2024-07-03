namespace FabricarPersonajes;
using System;
using System.Collections.Generic;
using RellenarPersonajes;
using ManejoJson;
using ManejoDeApi;

public class FabricaDePersonajes{
private List<Personaje> enemigos;


public async Task<List<Personaje>> CrearEnemigos(){

    enemigos = new List<Personaje>(); 
    Random random = new Random();
    List<Character> enemigosApi = await ConsumirApi.TraerInformacionApi();


        

    for (int i = 0; i < 8; i++)
    {
        int valorNumerico = random.Next(0, 5);
        RangoPersonaje rango = (RangoPersonaje)valorNumerico;
        string nombreRango = rango.ToString();
        int anio = random.Next(1750, 2025);
        int dia = random.Next(1, 29);
        int mes = random.Next(1, 12);
        DateTime fechaHoy = DateTime.Now;
        int edad = fechaHoy.Year - new DateTime(anio, mes, dia).Year;

    int a = random.Next(0, enemigosApi.Count);

        Personaje NuevoPersonaje = new Personaje(){
            Velocidad = random.Next(1, 10),
            Destreza = random.Next(1, 10),
            Fuerza = random.Next(1, 10),
            Range = nombreRango,
            Armadura = random.Next(1, 10),
            Jutsu = enemigosApi[a].jutsu ?? ["Taijutsu"],
            Salud = 100,
            Nombre = enemigosApi[a].name,
            Clan = enemigosApi[a].personal?.clan ?? "Renegado",
            FechaNacimiento = new DateTime(anio, mes, dia).ToString("yyyy-M-d"),
            Edad =edad
        };
        enemigos.Add(NuevoPersonaje);
    }

    return enemigos;
}


}