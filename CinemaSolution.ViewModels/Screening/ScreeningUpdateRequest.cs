using CinemaSolution.ViewModels.Auditorium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.ViewModels.Screening
{
    public class ScreeningUpdateRequest
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public AuditoriumViewModel Auditorium { get; set; } = new AuditoriumViewModel();
        public List<SeatDefaultViewModel> SeatDefaults { get; set; } = new List<SeatDefaultViewModel>();
    }
}
