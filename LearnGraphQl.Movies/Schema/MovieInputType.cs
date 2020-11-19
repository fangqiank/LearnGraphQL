using GraphQL.Types;
using LearnGraphQl.Movies.Models;

namespace LearnGraphQl.Movies.Schema
{
    public class MovieInputType:InputObjectGraphType<MovieInputModel>
    {
        public MovieInputType()
        {
            Name = "MovieInput";

            Field(x => x.Name).Description("Name");
            Field(x => x.Company);
            Field(x => x.ReleaseDate);
            Field(x => x.ActorId);
            Field(x => x.MovieRating, type: typeof(MovieRatingEnum));


        }
    }
}
