using LearnGraphQl.Movies.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearnGraphQl.Movies.Services
{
    public interface IActorService
    {
        Task<Actor> GetByIdAsync(int id);
        Task<IEnumerable<Actor>> GetAsync();
    }
}
