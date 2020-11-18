using GraphQL.Types;
using LearnGraphQl.Movies.Services;

namespace LearnGraphQl.Movies.Schema
{
    public class MoviesQuery: ObjectGraphType
    {
        public MoviesQuery(IMovieService movieService)
        {
            Name = "Query";

            Field<ListGraphType<MovieType>>("movies", resolve: context =>
                movieService.GetAsync());


        }
    }
}
