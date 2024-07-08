using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Data.Entities
{
    public class Rating
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public int Value { get; set; }
        public virtual Movie? Movie { get; set; }
        public virtual User? User { get; set; }
    }
}
