using CinemaSolution.ViewModels.Screening;
using CinemaSolution.ViewModels.Seat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.ViewModels.Invoice
{
    public class TicketViewModel
    {
        public int Id { get; set; }
        public ScreeningViewModel Screening { get; set; } = new ScreeningViewModel();
        public List<SeatViewModel> Seats { set; get; } = new List<SeatViewModel>();
        public int Price { set; get; }
    }
}
