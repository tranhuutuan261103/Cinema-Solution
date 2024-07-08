using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CinemaSolution.Data.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public string Actors { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<MovieImage>? MovieImages { get; set; }
        public string TrailerUrl { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;
        public int Duration { get; set; }
        public double Rating { get; set; }
        public bool IsDeleted { get; set; }
        public virtual List<MovieInCategory>? MovieInCategories { get; set; }
        public virtual List<Rating>? Ratings { get; set; }
        public virtual List<Comment>? Comments { get; set; }
        public virtual List<Screening>? Screenings { get; set; }
    }
}
