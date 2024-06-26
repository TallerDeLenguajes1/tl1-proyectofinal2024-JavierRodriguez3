namespace ManejoDeApi;
using System.Text.Json;




public class ConsumirApi{

    public static async Task<List<Character>> TraerInformacionApi()
        {

            List<Character> listaPersonajes = new List<Character>();
            Random random = new Random();
            int a = random.Next(8, 20);
            try
            {
                using HttpClient client = new HttpClient();
                var url = "https://narutodb.xyz/api/character?page=2&limit=40";
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
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
            }

            return listaPersonajes;
        }
}