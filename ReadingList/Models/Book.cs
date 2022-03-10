using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadingList.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual Author Author { get; set; }
        public int? AuthorId { get; set; }
        public virtual Country Country { get; set; }
        public int? CountryId { get; set; }
        public virtual List<BookGenre> Genres { get; set; }
        public int? Year { get; set; }
        public virtual List<BookPrize> Prizes { get; set; }
        public Language Language { get; set; }
        public string Description { get; set; }
        
        public virtual List<BookLocation> Locations { get; set; }
        public virtual List<BookWishList> WishLists { get; set; }

       // public string AuthorName { get; set; }
    }
    public enum Language
    {
        English,
        Spanish,
        French,
        LatinAmerica,
        Quebec,
        Other
    }
}

