using GraphQL.Utilities;
using System;

namespace LearnGraphQl.Movies.Schema
{
    public class MovieSchema:GraphQL.Types.Schema
    {
        public MovieSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<MoviesQuery>();

            Mutation = provider.GetRequiredService<MoviesMutation>();

            Subscription = provider.GetRequiredService<MoviesSubscription>();
        }
    }
}
