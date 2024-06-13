namespace ManejoJsonGanadores;
using RellenarPersonajes;
using System.Text.Json;



public class GanadoresJson{


    public void GuardarGanador(List<Personaje> ganadores, string ganadoresJson){
        try{
            string jsonString = JsonSerializer.Serialize(ganadores, new JsonSerializerOptions{WriteIndented = true});
            File.WriteAllText(ganadoresJson, jsonString);
            Console.WriteLine("Enemigo guardado con exito");
        }
        catch (Exception ex){
            Console.WriteLine($"Error al guardar personaje {ex.Message}");
        }
    }

    public List<Personaje> LeerGanador(string ganadoresJson){
        try
        {
            if (!File.Exists(ganadoresJson))
            {
                Console.WriteLine("No existe el archivo");
                return new List<Personaje>();
            }
            string jsonString =  File.ReadAllText(ganadoresJson);
            List<Personaje> ganadores = JsonSerializer.Deserialize<List<Personaje>>(jsonString);
            Console.WriteLine("Personaje leidos con exito");
            return ganadores;
        }
        catch (Exception ex)
        {
            
            Console.WriteLine($"Error al guardar personaje {ex.Message}");
            return new List<Personaje>();
        }
    }



    }