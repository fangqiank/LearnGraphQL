using GraphQL.Types;
using LearnGraphQl.Movies.Models;

namespace LearnGraphQl.Movies.Schema
{
    public class MovieEventType:ObjectGraphType<MovieEvent>
    {
        public MovieEventType()
        {
            Name = "MovieEvent";

            Field(x => x.Id);
            Field(x => x.MovieId);
            Field(x => x.Title);
            Field(x => x.TimeStamp);
            Field(x => x.MovieRating, type: typeof(MovieRatingEnum));

        }
    }
}
