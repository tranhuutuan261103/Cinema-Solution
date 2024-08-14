using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.ViewModels.Seat
{
    public class SeatStatusViewModel
    {
        public int Id { get; set; }
        public string StatusName { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
    }
}
