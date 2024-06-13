namespace FabricarPersonajes;
using System;
using System.Collections.Generic;
using RellenarPersonajes;
using ManejoJson;
using ManejoDeApi;


public class FabricaDePersonajes{
private List<Personaje> enemigos;
private Personaje miPersonaje;

public FabricaDePersonajes(){
    enemigos = new List<Personaje>(); 
}
public async Task<List<Personaje>> CrearEnemigos(){
 
    Random random = new Random();
    Personaje[] NuevoPersonaje = new Personaje[20];
    Array valoresRango = Enum.GetValues(typeof(RangoPersonaje));
    List<Character> enemigosApi = await ConsumirApi.TraerInformacionApi();


    for (int i = 0; i < NuevoPersonaje.Length; i++)
    {
        int valorNumerico = random.Next(0, 5);
        RangoPersonaje rango = (RangoPersonaje)valorNumerico;
        string nombreRango = rango.ToString();

        NuevoPersonaje[i] = new Personaje(){
            Velocidad = random.Next(1, 11),
            Destreza = random.Next(1, 6),
            Fuerza = random.Next(1, 11),
            Range = nombreRango,
            Armadura = random.Next(1, 11),
            Salud = 100,
            Nombre = enemigosApi[i].name,
            Clan = enemigosApi[i].personal?.clan ?? "personaje sin clan",
            FechaNacimiento = DateTime.Parse("1995-7-2"),
            Edad = random.Next(0, 301),
            Win = random.Next(0, 2) == 0
        };
        enemigos.Add(NuevoPersonaje[i]);
    }

    return enemigos;
}


}