using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadingList.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<BookLocation> Books { get; set; }
        public virtual List<MovieLocation> Movies { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
    }
}
