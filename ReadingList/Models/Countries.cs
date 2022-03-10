using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadingList.Models
{
    public class Countries
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Books> Books { get; set; }
    }
}
