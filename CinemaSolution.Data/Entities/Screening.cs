using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Data.Entities
{
    public class Screening
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int AuditoriumId { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Movie? Movie { get; set; }
        public virtual Auditorium? Auditorium { get; set; }
        public virtual ICollection<Seat>? Seats { get; set; }
        public virtual ICollection<Ticket>? Tickets { get; set; }
    }
}
