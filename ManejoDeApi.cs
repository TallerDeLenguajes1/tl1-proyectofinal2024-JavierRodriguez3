namespace ManejoJson;
using System.Text.Json;




public class ConsumirApi{

    public static async Task<List<Character>> TraerInformacionApi()
        {

            List<Character> listaPersonajes = new List<Character>();

            try
            {
                using HttpClient client = new HttpClient();
                var url = "https://narutodb.xyz/api/character";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                // Deserializar la respuesta JSON en ApiResponse
                var apiResponse = JsonSerializer.Deserialize<Root>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (apiResponse != null && apiResponse.characters != null)
                {
                    listaPersonajes.AddRange(apiResponse.characters);
                }


            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Error de red al llamar a la API: " + ex.Message);
            }
            catch (JsonException ex)
            {
                Console.WriteLine("Error de deserializar JSON: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
            }

            return listaPersonajes;
        }
}