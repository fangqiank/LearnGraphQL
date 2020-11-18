using GraphQL.Types;
using LearnGraphQl.Movies.Models;
using LearnGraphQl.Movies.Services;

namespace LearnGraphQl.Movies.Schema
{
    public class MovieType:ObjectGraphType<Movie>
    {
        public MovieType(IActorService actorService )
        {
            Name = "Movie";
            Description = "";

            Field(x => x.Id).Description("Id of movie");
            Field(x => x.Company).Description("The company");
            Field(x => x.Name).Description("The movie name");
            Field(x => x.ReleaseDate).Description("Date of release");
            Field(x => x.ActorId).Description("The actor");
            Field<MovieRatingEnum>("movieRatings", resolve: context =>
                context.Source.MovieRating);

            Field<ActorType>("actor", resolve: context => 
                actorService.GetByIdAsync(context.Source.ActorId));

            Field<StringGraphType>("customString", resolve: context =>
                "1234");


        }
    }
}
