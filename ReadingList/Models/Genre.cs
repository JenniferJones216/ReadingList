using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadingList.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<BookGenre> Books { get; set; }
        public virtual List<MovieGenre> Movies { get; set; }
    }
}
