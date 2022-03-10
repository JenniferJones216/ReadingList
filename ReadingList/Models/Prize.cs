using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadingList.Models
{
    public class Prize
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<BookPrize> Books { get; set; }
        public virtual List<MoviePrize> Movies { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
    }
}
