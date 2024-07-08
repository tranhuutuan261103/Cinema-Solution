using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Data.Entities
{
    public class PersonType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public virtual List<Seat>? Seats { get; set; }
        public virtual List<DefaultPriceTable>? DefaultPriceTables { get; set; }
    }
}
