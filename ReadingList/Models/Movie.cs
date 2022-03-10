using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadingList.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual Director Director { get; set; }
        public int? DirectorId { get; set; }
        public virtual Country Country { get; set; }
        public int? CountryId { get; set; }
        public virtual List<MovieGenre> Genres { get; set; }
        public int? Year { get; set; }
        public virtual List<MoviePrize> Prizes { get; set; }
        public Language Language { get; set; }
        public string Description { get; set; }
        public virtual List<MovieActor> Actors { get; set; }
        public virtual List<MovieWishList> WishLists { get; set; }
        public virtual List<MovieLocation> Locations { get; set; }
        public VideoType Type { get; set; }
        public Rating Rating { get; set; }
    }

    public enum VideoType
    {
        Movie,
        Series,
        Miniseries,
        Video,
        Other
    }

    public enum Rating
    {
        PG,
        PG13,
        G,
        R,
        NC17,
        NR,
        X,
        Unkknown
    }
}
