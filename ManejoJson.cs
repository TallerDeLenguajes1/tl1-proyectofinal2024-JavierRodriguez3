namespace ManejoJson;
using RellenarPersonajes;
using FabricarPersonajes;
using System.Text.Json;



public class PersonajesJson{


    public void GuardarPersonaje(List<Personaje> enemigos, string enemigosJson){
        try{
            string jsonString = JsonSerializer.Serialize(enemigos, new JsonSerializerOptions{WriteIndented = true});
            File.WriteAllText(enemigosJson, jsonString);
        }
        catch (Exception ex){
            Console.WriteLine($"Error al guardar personaje {ex.Message}");
        }
    }

    public List<Personaje> LeerPersonajes(string enemigosJson){
        try
        {
            if (!File.Exists(enemigosJson))
            {
                Console.WriteLine("No existe el archivo");
                return new List<Personaje>();
            }
            string jsonString =  File.ReadAllText(enemigosJson);
            List<Personaje> enemigos = JsonSerializer.Deserialize<List<Personaje>>(jsonString);
            return enemigos;
        }
        catch (Exception ex)
        {
            
            Console.WriteLine($"Error al guardar personaje {ex.Message}");
            return new List<Personaje>();
        }
    }
}