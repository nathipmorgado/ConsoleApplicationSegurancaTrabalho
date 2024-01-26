using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        await ConsumeApiAsync();
    }

    static async Task ConsumeApiAsync()
    {
        using (HttpClient client = new HttpClient())
        {
            // Substitua a URL pela URL real da API que você está consumindo
            string apiUrl = "http://localhost:4444/api/v1/Colaborador";

            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    dynamic jsonResponse = JsonConvert.DeserializeObject(responseData);
                    Console.WriteLine(jsonResponse); ;
                }
                else
                {
                    Console.WriteLine($"Erro na solicitação: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}