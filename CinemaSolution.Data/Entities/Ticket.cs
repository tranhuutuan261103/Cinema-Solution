using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Data.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public int ScreeningId { get; set; }
        public virtual Screening? Screening { get; set; }
        public virtual Invoice? Invoice { get; set; }
        public int Price { get; set; }
        public virtual ICollection<Seat>? Seats { get; set; }
    }
}
