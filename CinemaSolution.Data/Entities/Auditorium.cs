using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Data.Entities
{
    public class Auditorium
    {
        public int Id { get; set; }
        public int CinemaId { get; set; }
        public virtual Cinema? Cinema { get; set; }
        public string Name { get; set; } = string.Empty;
        public int NumberOfRowSeats { get; set; }
        public int NumberOfColumnSeats { get; set; }
        public string SeatMapVector { get; set; } = string.Empty;
        public virtual ICollection<Screening>? Screenings { get; set; }
    }
}
