namespace RellenarPersonajes;

public enum RangoPersonaje{ //Luego lo usaremos numericamente para hacer el aleatorio
    Genin,
    Chunin,
    Jonin,
    Kage
}
public class Personaje{
    private int velocidad;
    private int destreza;
    private int fuerza;
    private RangoPersonaje rango;
    private string range;
    private int armadura;
    private int salud;
    private List<string> jutsu;
    private string nombre;
    private string clan;
    private string fechaNacimiento;
    private int edad;

    public int Velocidad { get => velocidad; set => velocidad = value; }
    public int Destreza { get => destreza; set => destreza = value; }
    public int Fuerza { get => fuerza; set => fuerza = value; }
    public RangoPersonaje Rango { get => rango; set => rango = value; }
        public string Range { get => range; set => range = value; }

    public int Armadura { get => armadura; set => armadura = value; }
    public int Salud { get => salud; set => salud = value; }
    public List<string> Jutsu { get => jutsu; set => jutsu = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Clan { get => clan; set => clan = value; }
    public string FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
    public int Edad { get => edad; set => edad = value; }
}