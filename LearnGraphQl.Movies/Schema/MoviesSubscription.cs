using GraphQL;
using GraphQL.Resolvers;
using GraphQL.Subscription;
using GraphQL.Types;
using LearnGraphQl.Movies.Models;
using LearnGraphQl.Movies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;

namespace LearnGraphQl.Movies.Schema
{
    public class MoviesSubscription:ObjectGraphType
    {
        private readonly IMovieEventService _movieEventService;

        public MoviesSubscription(IMovieEventService movieEventService)
        {
            this._movieEventService = movieEventService;
            Name = "Subscription";

            AddField(new EventStreamFieldType
            {
                Name="movieEvent",
                Arguments = new QueryArguments(
                    new QueryArgument<ListGraphType<MovieRatingEnum>>
                    {
                        Name = "movieRatings"
                    }),

                Type = typeof(MovieEventType),
                Resolver = new FuncFieldResolver<MovieEvent>(ResolveEvent),
                Subscriber = new EventStreamResolver<MovieEvent>(Subscribe)
            });
        }

        private IObservable<MovieEvent> Subscribe(IResolveEventStreamContext context)
        {
            var ratingList = context.GetArgument<IList<MovieRating>>("movieRatings", 
                new List<MovieRating>());

            if (ratingList.Any())
            {
                MovieRating movieRating = 0;

                foreach (var rating in ratingList)
                {
                    movieRating = rating | rating;
                }

                return _movieEventService
                    .EventStream()
                    .Where(x => (x.MovieRating & movieRating) == x.MovieRating);
            }
            else
            {
                return _movieEventService.EventStream();
            }
        }

        private MovieEvent ResolveEvent(IResolveFieldContext context)
        {
            var movieEvent = context.Source as MovieEvent;
            return movieEvent;
        }
    }
}
