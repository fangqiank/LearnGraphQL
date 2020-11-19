using System;
using System.Collections.Generic;
using System.Text;

namespace LearnGraphQl.Movies.Models
{
    public class MovieInputModel
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Company { get; set; }
        public int ActorId { get; set; }
        public MovieRating MovieRating { get; set; }
    }
}
