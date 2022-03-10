using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadingList.Models
{
    public class WishList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual List<BookWishList> Books { get; set; }
        public virtual List<MovieWishList> Movies { get; set; }
    }
}
