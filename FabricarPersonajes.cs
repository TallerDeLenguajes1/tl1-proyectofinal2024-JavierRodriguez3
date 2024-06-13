using RellenarPersonajes;
namespace FabricarPersonajes;


public class FabricaDePersonajes{
private List<Personaje> enemigos;
private Personaje miPersonaje;
private string[] nombres;

public FabricaDePersonajes(){
    enemigos = new List<Personaje>();  
    nombres = new string[] {"dangelo", "trigo", "targa", "fla", "guille", "luciano", "tommy", "peper"};
}
public List<Personaje> CrearEnemigos(){

    
    Random random = new Random();

    for (int i = 0; i < 8; i++)
    {
        Personaje NuevoPersonaje = new Personaje();
        int indiceAlea = random.Next(nombres.Length);
        NuevoPersonaje.Nombre=nombres[indiceAlea];
        enemigos.Add(NuevoPersonaje);
    }
    return enemigos;
}


}