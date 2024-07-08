using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Data.Entities
{
    public class MovieInCategory
    {
        public int MovieId { get; set; }
        public int CategoryId { get; set; }
        public virtual Movie? Movie { get; set; }
        public virtual Category? Category { get; set; }
    }
}
