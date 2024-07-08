using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Data.Entities
{
    public class SeatType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public virtual ICollection<Seat>? Seats { get; set; }
        public virtual ICollection<DefaultPriceTable>? DefaultPriceTables { get; set; }
    }
}
