using LearnGraphQl.Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnGraphQl.Movies.Services
{
    public class MovieService:IMovieService
    {
        private readonly IMovieEventService _movieEventService;
        private readonly IList<Movie> _movies;

        public MovieService(IMovieEventService movieEventService)
        {
            this._movieEventService = movieEventService;
            _movies= new List<Movie>
            {
                new Movie
                {
                    Id=1,
                    Name = "Forrest Gump",
                    ActorId = 1,
                    Company = "Paramount Pictures",
                    MovieRating = MovieRating.PG13,
                    ReleaseDate = new DateTime(1994,7,6)
                },

                new Movie
                {
                    Id=2,
                    Name = "Se2en",
                    ActorId = 2,
                    Company = "New Line Cinema",
                    MovieRating = MovieRating.R,
                    ReleaseDate = new DateTime(1995,9,22)
                },

                new Movie
                {
                    Id=3,
                    Name = "Top Gun",
                    ActorId = 3,
                    Company = "Paramount Pictures",
                    MovieRating = MovieRating.PG,
                    ReleaseDate = new DateTime(1986,5,16)
                },

                new Movie
                {
                    Id=4,
                    Name = "La La Land",
                    ActorId = 4,
                    Company = "Summit Entertainment",
                    MovieRating = MovieRating.PG13,
                    ReleaseDate = new DateTime(2016,12,25)
                },

                new Movie
                {
                    Id=5,
                    Name = "The Notebook",
                    ActorId = 5,
                    Company = "New Line Cinema",
                    MovieRating = MovieRating.PG13,
                    ReleaseDate = new DateTime(2004,6,25)
                },


            };
        }

        public Task<Movie> GetByIdAsync(int id)
        {
            var movie = _movies.SingleOrDefault(x => x.Id == id);
            if(movie is null)
                throw new ArgumentException($"Movie Id {id} is wrong");

            return Task.FromResult(_movies.SingleOrDefault(x => x.Id == id));
        }

        public Task<IEnumerable<Movie>> GetAsync()
        {
            return Task.FromResult(_movies.AsEnumerable());
        }

        public Task<Movie> CreateAsync(Movie movie)
        {
            _movies.Add(movie);

            var movieEvent = new MovieEvent
            {
                Title = $"Add Movie",
                MovieId = movie.Id,
                TimeStamp = DateTime.Now,
                MovieRating = movie.MovieRating
            };

            _movieEventService.AddEvent(movieEvent);

            return Task.FromResult(movie);
        }
    }
}
