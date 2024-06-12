using RellenarPersonajes;
namespace FabricarPersonajes;


public class FabricaDePersonajes{
private List<Personaje> Enemigos;
private Personaje MiPersonaje;

public FabricaDePersonajes(){
    Enemigos = new List<Personaje>();  
}
public List<Personaje> CrearEnemigos(){

    for (int i = 0; i < 3; i++)
    {
        Personaje NuevoPersonaje = new Personaje();
        NuevoPersonaje.Nombre="pedro";
        Enemigos.Add(NuevoPersonaje);
    }
    return Enemigos;
}


}