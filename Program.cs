using System;
using System.Net.Http;
using Refit;
using RefitTesting.Models;

namespace RefitDemo
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            // Bruger den korrekte base-URL for reqres
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://reqres.in/api/")  // https://reqres.in/api/
            };
            client.DefaultRequestHeaders.UserAgent.ParseAdd("RefitDemoApp");

            var api = RestService.For<IGitHubApi>(client);

            // Test GET: Hent bruger med ID 1 (som er en gyldig testbruger)
            try
            {
                var user = await api.GetUserAsync("1");  // ID 1 er gyldigt
                Console.WriteLine($"GET -> {user.Name}, {user.Email}");
            }
            catch (ApiException ex)
            {
                Console.WriteLine($"Error: {ex.StatusCode} - {ex.Message}");
            }

            // Test POST
            var newUser = new User { Name = "John Doe", Email = "john@example.com" };
            var createdUser = await api.CreateUserAsync(newUser);
            Console.WriteLine($"POST -> {createdUser.Name}, {createdUser.Email}");

            // Test PUT
            var updatedUser = new User { Name = "Jane Updated", Email = "updated@example.com" };
            var result = await api.UpdateUserAsync(1, updatedUser);
            Console.WriteLine($"PUT -> {result.Name}, {result.Email}");

            // Test DELETE
            await api.DeleteUserAsync(1);
            Console.WriteLine("DELETE -> User deleted");
        }
    }
}
