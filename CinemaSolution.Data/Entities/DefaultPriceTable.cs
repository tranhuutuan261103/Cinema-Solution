using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Data.Entities
{
    public class DefaultPriceTable
    {
        public int SeatTypeId { get; set; }
        public int PersonTypeId { get; set; }
        public int Price { get; set; }
        public virtual SeatType? SeatType { get; set; }
        public virtual PersonType? PersonType { get; set; }
    }
}
