using RellenarPersonajes;
namespace FabricarPersonajes;


public class FabricaDePersonajes{
private List<Personaje> enemigos;
private Personaje miPersonaje;

public FabricaDePersonajes(){
    enemigos = new List<Personaje>(); 
}
public List<Personaje> CrearEnemigos(){
 
    Random random = new Random();
    Personaje[] NuevoPersonaje = new Personaje[2];
    Array valoresRango = Enum.GetValues(typeof(RangoPersonaje));
    


    for (int i = 0; i < NuevoPersonaje.Length; i++)
    {
    RangoPersonaje RangoAleatorio = (RangoPersonaje)valoresRango.GetValue(random.Next(valoresRango.Length));

        NuevoPersonaje[i] = new Personaje(){
            Velocidad = random.Next(1, 11),
            Destreza = random.Next(1, 6),
            Fuerza = random.Next(1, 11),
            Rango = RangoAleatorio,
            Armadura = random.Next(1, 11),
            Salud = 100,
            Nombre = $"Kakashi Hatake {i}",
            Apodo = $"El copiador {i}",
            FechaNacimiento = DateTime.Parse("1995-7-2"),
            Edad = random.Next(1, 301)
        };
        enemigos.Add(NuevoPersonaje[i]);
    }

    return enemigos;
}


}