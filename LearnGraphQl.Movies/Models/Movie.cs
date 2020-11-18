using System;

namespace LearnGraphQl.Movies.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public String Company { get; set; }
        public int ActorId { get; set; }
        public MovieRating MovieRating { get; set; }
    }
}
