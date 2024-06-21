namespace Peleas;

using RellenarPersonajes;

public class Combate
{

    public void  realizarCombate(Personaje atacante, Personaje defensor)
    {
        var random = new Random();
        int ataque = atacante.Destreza * atacante.Fuerza * this.modRango(atacante);
        int efectividad = random.Next(1, 101);
        int defensa = defensor.Armadura * defensor.Velocidad;
        const int Ajuste = 500;

        int danioProvocado = ((ataque * efectividad) - defensa) / Ajuste;

        defensor.Salud = defensor.Salud - danioProvocado;
    }

    public Personaje turno(Personaje atacante, Personaje defensor)
        {
            while (atacante.Salud > 0 && defensor.Salud > 0)
            {
                realizarCombate(atacante, defensor);

                if (defensor.Salud <= 0)
                {
                    atacante.Fuerza = atacante.Fuerza * 2;
                    return defensor;
                }

                realizarCombate(defensor, atacante);
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