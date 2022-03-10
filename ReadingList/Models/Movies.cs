using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadingList.Models
{
    public class Movies
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual Director Director { get; set; }

        public int DirectorId { get; set; }
        public virtual Country Country { get; set; }
        public int CountryId { get; set; }
        public virtual List<MovieGenre> Genres { get; set; }
        public int Year { get; set; }
        public virtual List<MoviePrize> Prizes { get; set; }
        public MovieLanguage Language { get; set; }
        public string Description { get; set; }
        public virtual List<MovieActor> Actors { get; set; }
        public virtual List<MovieList> Lists { get; set; }
        public virtual List<MovieLocation> Locations { get; set; }
        public VideoType Type { get; set; }
    }
    public enum MovieLanguage
    {
        English,
        Spanish,
        French,
        Catalon,
        Quebec,
        Other
    }

    public enum  VideoType
    {
        Movie,
        Series,
        MiniSeries,
        Video,
        Other
    }
}
