using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadingList.Models
{
    public class BookLocation
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
        public bool? Audiobook { get; set; }
        public string URL { get; set; }
    }
}
