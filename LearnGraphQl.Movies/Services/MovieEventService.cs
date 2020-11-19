using LearnGraphQl.Movies.Models;
using System;
using System.Collections.Concurrent;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace LearnGraphQl.Movies.Services
{
    public class MovieEventService: IMovieEventService
    {
        private readonly ISubject<MovieEvent> _eventStream = new ReplaySubject<MovieEvent>();

        public ConcurrentStack<MovieEvent> AllEvents { get; }
        

        public MovieEventService()
        {
            AllEvents=new ConcurrentStack<MovieEvent>();
        }
        
        
        public void AddError(Exception ex)
        {
            _eventStream.OnError(ex);
        }

        public MovieEvent AddEvent(MovieEvent newEvent)
        {
            AllEvents.Push(newEvent);
            _eventStream.OnNext(newEvent);
            return newEvent;
        }

        public IObservable<MovieEvent> EventStream()
        {
            return _eventStream.AsObservable();
        }
    }
}
