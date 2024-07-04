namespace torneo;
using RellenarPersonajes;
using FabricarPersonajes;
using Peleas;
public  class Torneo{

    Combate PeleaTorneo = new Combate();

    List<Personaje> Perdedores = new List<Personaje>();
    public List<Personaje> inicioTorneo(List<Personaje> enemigos){ 
        for (int i = 0; i < enemigos.Count - 1; i+=2)
        {
            Personaje per1=enemigos[i];
            Personaje per2=enemigos[i+1];
            Perdedores.Add(PeleaTorneo.turno(per1, per2));          
        }

        foreach (Personaje Elim in Perdedores)
        {
            enemigos.Remove(Elim);
        }
        return enemigos;
    }
}