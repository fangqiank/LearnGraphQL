using System;
using System.Collections.Concurrent;
using LearnGraphQl.Movies.Models;

namespace LearnGraphQl.Movies.Services
{
    public interface IMovieEventService
    {
        ConcurrentStack<MovieEvent> AllEvents { get; }
        void AddError(Exception ex);
        MovieEvent AddEvent(MovieEvent newEvent);
        IObservable<MovieEvent> EventStream();
    }
}
