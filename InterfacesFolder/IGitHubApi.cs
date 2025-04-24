using Refit;
using RefitTesting.Models;
using System.Threading.Tasks;

public interface IGitHubApi
{
    // Brug GET /users/{id}
    [Get("users/{id}")]
    Task<User> GetUserAsync(int id); // Bemærk at vi bruger int som parameter i stedet for string

    // Brug POST /users
    [Post("users")]
    Task<User> CreateUserAsync([Body] User user);

    // Brug PUT /users/{id}
    [Put("users/{id}")]
    Task<User> UpdateUserAsync(int id, [Body] User user);

    // Brug DELETE /users/{id}
    [Delete("users/{id}")]
    Task DeleteUserAsync(int id);
}
