using GraphQL.Types;
using LearnGraphQl.Movies.Models;

namespace LearnGraphQl.Movies.Schema
{
    public class MovieRatingEnum:EnumerationGraphType<MovieRating>
    {
        public MovieRatingEnum()
        {
            Name = "MovieRatings";
            Description = "";

            AddValue(MovieRating.Unrated.ToString(),"Unrated",MovieRating.Unrated);
            AddValue(MovieRating.G.ToString(),"G",MovieRating.G);
            AddValue(MovieRating.NC17.ToString(), "NC17", 
                MovieRating.NC17);
            AddValue(MovieRating.PG.ToString(), "PG", 
                MovieRating.PG);
            AddValue(MovieRating.PG13.ToString(), "PG13", 
                MovieRating.PG13);
            AddValue(MovieRating.R.ToString(), "R", 
                MovieRating.R);
        }
    }
}
