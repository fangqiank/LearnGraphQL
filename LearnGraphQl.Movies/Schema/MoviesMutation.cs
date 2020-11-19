using System.Linq;
using GraphQL;
using GraphQL.Types;
using LearnGraphQl.Movies.Models;
using LearnGraphQl.Movies.Services;

namespace LearnGraphQl.Movies.Schema
{
    public class MoviesMutation:ObjectGraphType
    {
        public MoviesMutation(IMovieService movieService)
        {
            Name = "Mutation";

            FieldAsync<MovieType>(
                "createMovie",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<MovieInputType>> {Name = "movie"}
                    ),
                resolve: async context =>
                {
                    var movieInput = context.GetArgument<MovieInputModel>("movie");

                    var movies = await movieService.GetAsync();

                    var maxId = movies.Select(x => x.Id).Max();

                    var movie = new Movie
                    {
                        Id = maxId + 1,
                        Name = movieInput.Name,
                        Company = movieInput.Company,
                        ActorId = movieInput.ActorId,
                        MovieRating = movieInput.MovieRating,
                        ReleaseDate = movieInput.ReleaseDate
                    };

                    var result = await movieService.CreateAsync(movie);

                    return result;
                }
                );


        }
    }
}
