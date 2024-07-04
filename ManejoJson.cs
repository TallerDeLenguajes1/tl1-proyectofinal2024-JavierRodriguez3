namespace ManejoJson;
using RellenarPersonajes;
using System.Text.Json;



public class PersonajesJson{


    public void GuardarPersonaje(List<Personaje> personajes, string personajesJson){
        try{
            string jsonString = JsonSerializer.Serialize(personajes, new JsonSerializerOptions{WriteIndented = true});
            File.WriteAllText(personajesJson, jsonString);
        }
        catch (Exception ex){
            Console.WriteLine($"Error al guardar personaje {ex.Message}");
        }
    }

    public List<Personaje> LeerPersonajes(string personajesJson){
        try
        {
            if (!File.Exists(personajesJson))
            {
                Console.WriteLine("No existe el archivo");
            }
            string jsonString =  File.ReadAllText(personajesJson);
            List<Personaje> personajes = JsonSerializer.Deserialize<List<Personaje>>(jsonString);
            return personajes;
        }
        catch (Exception ex)
        {
            
            Console.WriteLine($"Error al guardar personaje {ex.Message}");
            return new List<Personaje>();
        }
    }  //No lo uso, pero como es un requerimiento queda aqui.
}