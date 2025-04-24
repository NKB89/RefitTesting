using Refit;
using RefitTesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefitTesting.InterfacesFolder
{
    public interface IReqResApi
    {
        // Opdater stien til at starte med en skråstreg "/"
        [Get("/users/{id}")]
        Task<User> GetUserAsync(int id); // Hent bruger med et givet ID
    }
}
