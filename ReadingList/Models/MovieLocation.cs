using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadingList.Models
{
    public class MovieLocation
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
        public bool? SpanishAudio { get; set; }
        public string URL { get; set; }
        public Format? Format { get; set; }
        public Cost? Cost { get; set; }
        public Double? Price { get; set; }
    }

    public enum Format
    {
        DVD,
        Streaming,
        VHS,
        Blueray,
        Other
    }

    public enum Cost
    {
        Free,
        Subscription,
        Pay,
        Unknown
    }
}
