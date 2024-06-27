namespace textoLindo;
using System;
using System.Threading;

public class textoProgram
{
    public void MostrarMensaje()
    {
        string[] mensajes = {
            "Después de la batalla a gran escala conocida como la Cuarta Gran Guerra Ninja, el mundo ninja descansó en paz.",
            "Hasta que los Otsutsuki decidieron salir de su profundo letargo en busca de caos y destrucción.",
            "Por lo que decidieron realizar un torneo y brindar un gran poder al ganador.",
            "Lo que dio comienzo a..."
        };

        foreach (string mensaje in mensajes)
        {
            MostrarTextoLetraPorLetra(mensaje);
            Console.WriteLine(); // Salto de línea después de cada mensaje completo
            Console.WriteLine("Presiona Enter para continuar...");
            Console.ReadLine();
            Console.Clear(); // Limpia la consola para el siguiente mensaje
        }
    }

    public static void MostrarTextoLetraPorLetra(string texto)
    {
        foreach (char c in texto)
        {
            Console.Write(c);
            Thread.Sleep(millisecondsTimeout: 5); // Ajusta el tiempo de espera entre cada caracter (en milisegundos)
        }
    }
}
