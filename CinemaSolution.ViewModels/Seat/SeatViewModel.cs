using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.ViewModels.Seat
{
    public class SeatViewModel
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public int Number { get; set; }
        public SeatTypeViewModel SeatType { get; set; } = new SeatTypeViewModel();
        public SeatStatusViewModel SeatStatus { get; set; } = new SeatStatusViewModel();
    }
}
