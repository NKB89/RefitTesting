using Refit;
using RefitTesting.Models;
using System.Threading.Tasks;

public interface IGitHubApi
{
    [Get("users/{user}")]
    Task<User> GetUserAsync(string user);

    [Post("users")]
    Task<User> CreateUserAsync([Body] User user);

    [Put("users/{id}")]
    Task<User> UpdateUserAsync(int id, [Body] User user);

    [Delete("users/{id}")]
    Task DeleteUserAsync(int id);
}
