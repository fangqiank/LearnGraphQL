using System;

namespace LearnGraphQl.Movies.Models
{
    [Flags] //让枚举有多个值
    public enum MovieRating
    {
        Unrated=0,
        G=1,
        PG=2,
        PG13=3,
        R=4,
        NC17=5
    }
}