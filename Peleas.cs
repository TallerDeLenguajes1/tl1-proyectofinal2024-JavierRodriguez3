namespace Peleas;

using System.Security.Cryptography;
using FabricarPersonajes;
using RellenarPersonajes;

public class Combate
{

    private string[] Armas = new string[]
{
    "Kunai",
    "Shuriken",
    "Fūma Shuriken",
    "Senbon",
    "Katana",
    "Kusanagi",
    "Samehada",
    "Kubikiribōchō",
    "Hiramekarei",
    "Kiba"
};

    public void  realizarCombate(Personaje p1, Personaje p2)
    {
        var random = new Random();
        int ataque = p1.Destreza * p1.Fuerza * this.modRango(p1);
        int efectividad = random.Next(1, 101);
        int defensa = p2.Armadura * p2.Velocidad;
        const int Ajuste = 500;

        int danioProvocado = ((ataque * efectividad) - defensa) / Ajuste;
        p2.Salud = p2.Salud - danioProvocado;
        if(p2.Salud < 0 ){
            p2.Salud = 0;
        }
        Console.WriteLine("\n-----------------------------------------------------");
        Console.WriteLine($"{p2.Nombre} Recibio daño y su vida disminuyo a {p2.Salud}");
        Console.WriteLine("-----------------------------------------------------\n");
    }

    public Personaje turno(Personaje atacante, Personaje defensor)
        {
            Random random = new Random();
            while (atacante.Salud > 0 && defensor.Salud > 0)
            {
                
                Console.WriteLine("\n###########################################################################################");
                Console.WriteLine("###########################       Que comience la batalla       ###########################");
                Console.WriteLine("###########################################################################################\n");

                Console.WriteLine($"El peleador {atacante.Nombre} Esta por elegir su movimiento");
                Console.WriteLine("Seleccionar la opcion deseada");
                Console.WriteLine("1. Atacar \n2. Defender \n3. Saltar \n4. Rendirse");
                
                int eleccion;
                do
                {

                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    if (char.IsDigit(keyInfo.KeyChar))
                    {
                        eleccion = (int)char.GetNumericValue(keyInfo.KeyChar);

                        if (eleccion >= 1 && eleccion <= 4)
                        {
                            break;
                        }
                    }

                    Console.WriteLine("\nOpción inválida.");
                }while (true);

                switch (eleccion)
                {
                    case 1:
                        realizarCombate(atacante, defensor);
                        if(atacante.Jutsu[0] == "Taijutsu"){
                            Console.WriteLine("\n-----------------------------------------------------");
                            Console.WriteLine($"{atacante.Nombre} Utilizo {Armas[random.Next(0, 10)]}");
                            Console.WriteLine("-----------------------------------------------------\n");
                        }
                        else{
                            Console.WriteLine("\n-----------------------------------------------------");
                            Console.WriteLine($"{atacante.Nombre} Utilizo {atacante.Jutsu[random.Next(0, atacante.Jutsu.Count)]}");
                            Console.WriteLine("-----------------------------------------------------\n");
                        }
                        break;
                    case 2:
                        atacante.Armadura +=  1;
                        Console.WriteLine("\n-----------------------------------------------------");
                        Console.WriteLine($"{atacante.Nombre} se agrego {1} de defensa y ahora tiene {atacante.Armadura}");
                        Console.WriteLine("-----------------------------------------------------\n");
                        break;
                    case 3: 
                        break;    
                    case 4:
                        atacante.Salud = 0;
                        Console.WriteLine("\n-----------------------------------------------------");
                        Console.WriteLine($"{atacante.Nombre} cometio suicidio");
                        Console.WriteLine("-----------------------------------------------------\n");
                        if (atacante.Salud <= 0)
                        {
                            defensor.Fuerza = defensor.Fuerza * 2;
                            return atacante;
                        }
                        break;
                }

                

                if (defensor.Salud <= 0)
                {
                    atacante.Fuerza = atacante.Fuerza * 2;
                    return defensor;
                }

                Console.WriteLine("\n###########################################################################################");
                Console.WriteLine("###########################       Que comience la batalla       ###########################");
                Console.WriteLine("###########################################################################################\n");

                Console.WriteLine($"El peleador {defensor.Nombre} Esta por elegir su movimiento");
                Console.WriteLine("Seleccionar la opcion deseada");
                Console.WriteLine("1. Atacar \n2. Defender \n3. Saltar \n4. Rendirse");

                do
                {

                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    if (char.IsDigit(keyInfo.KeyChar))
                    {
                        eleccion = (int)char.GetNumericValue(keyInfo.KeyChar);

                        if (eleccion >= 1 && eleccion <= 4)
                        {
                            break;
                        }
                    }

                    Console.WriteLine("\nOpción inválida.");
                }while (true);

                switch (eleccion)
                {
                    case 1:
                        realizarCombate(defensor, atacante);
                        if(defensor.Jutsu[0] == "Taijutsu"){
                            Console.WriteLine("-----------------------------------------------------");
                            Console.WriteLine($"{defensor.Nombre} Utilizo {Armas[random.Next(0, 10)]}");
                            Console.WriteLine("-----------------------------------------------------");
                        }
                        else{
                            Console.WriteLine("-----------------------------------------------------");
                            Console.WriteLine($"{defensor.Nombre} Utilizo {defensor.Jutsu[random.Next(0, defensor.Jutsu.Count)]}");
                            Console.WriteLine("-----------------------------------------------------");
                        }
                        break;
                    case 2:
                        defensor.Armadura += 1;
                        Console.WriteLine("-----------------------------------------------------");
                        Console.WriteLine($"{defensor.Nombre} se agrego {1} de defensa y ahora tiene {defensor.Armadura}");
                        Console.WriteLine("-----------------------------------------------------");
                        break;
                    case 3: 
                        break;    
                    case 4:
                        defensor.Salud = 0;
                        Console.WriteLine("-----------------------------------------------------");
                        Console.WriteLine($"{defensor.Nombre} cometio suicidio");
                        Console.WriteLine("-----------------------------------------------------");
                        if (defensor.Salud <= 0)
                        {
                            atacante.Fuerza = atacante.Fuerza * 2;
                            return defensor;
                        }
                        break;
                }

                
            }

            if (atacante.Salud <= 0)
            {
                defensor.Fuerza = defensor.Fuerza * 2;
                return atacante;
            }

            return atacante;
        }


    public int modRango(Personaje atacante){
        int nivel;

        switch (atacante.Range)
        {
            case "Genin":
                nivel = 1;
                return nivel;
            case "Chunin":
                nivel = 2;
                return nivel;
            case "Jonin":
                nivel = 3;
                return nivel;
            default:
                nivel = 4;
                return nivel;    
        }
    }
}