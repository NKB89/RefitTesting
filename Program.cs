using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RefitDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://reqres.in/api/") // Base URL
            };

            try
            {
                // Lav en manuel GET-anmodning via HttpClient
                var response = await client.GetAsync("users/7"); // Test GET uden Refit
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Response: {content}");
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
    }
}
