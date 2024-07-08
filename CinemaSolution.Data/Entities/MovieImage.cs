using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Data.Entities
{
    public class MovieImage
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string? Caption { get; set; }
        public DateTime DateCreated { get; set; }
        public long FileSize { get; set; }
        public bool IsPoster { get; set; }
        public int MovieImageTypeId { get; set; }
        public virtual MovieImageType? MovieImageType { get; set; }
        public int MovieId { get; set; }
        public virtual Movie? Movie { get; set; }
    }
}
