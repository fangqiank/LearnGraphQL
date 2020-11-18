using LearnGraphQl.Movies.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearnGraphQl.Movies.Services
{
    public interface IMovieService
    {
        Task<Movie> GetByIdAsync(int id);
        Task<IEnumerable<Movie>> GetAsync();
        Task<Movie> CreateAsync(Movie movie);
    }
}
