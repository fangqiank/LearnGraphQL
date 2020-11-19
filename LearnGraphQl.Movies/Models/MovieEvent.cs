using System;

namespace LearnGraphQl.Movies.Models
{
    public class MovieEvent
    {
        public MovieEvent()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public int MovieId { get; set; }
        public string Title { get; set; }
        public DateTime TimeStamp { get; set; }
        public MovieRating MovieRating { get; set; }
    }
}
