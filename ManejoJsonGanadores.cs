    namespace ManejoJsonGanadores;
    using RellenarPersonajes;
    using System.Text.Json;



    public class GanadoresJson{


        public void GuardarGanador(List<Personaje> ganadores, string ganadoresJson){
            try{
                List<Personaje> ganadoresExistentes = LeerGanador(ganadoresJson);

                ganadoresExistentes.AddRange(ganadores);

                string jsonString = JsonSerializer.Serialize(ganadoresExistentes, new JsonSerializerOptions{WriteIndented = true});
                File.WriteAllText(ganadoresJson, jsonString);
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
                return ganadores;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error al guardar personaje {ex.Message}");
                return new List<Personaje>();
            }
        }
    }