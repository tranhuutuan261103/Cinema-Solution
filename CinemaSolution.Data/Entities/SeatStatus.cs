using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Data.Entities
{
    public class SeatStatus
    {
        public int Id { get; set; }
        public string StatusName { get; set; } = string.Empty;
        public string? StatusDescription { get; set; }
        public bool IsAvailable { get; set; }
        public virtual List<Seat>? Seats { get; set; }
    }
}
