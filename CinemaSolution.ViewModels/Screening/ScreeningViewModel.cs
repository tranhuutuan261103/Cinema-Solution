using CinemaSolution.ViewModels.Auditorium;
using CinemaSolution.ViewModels.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.ViewModels.Screening
{
    public class ScreeningViewModel
    {
        public int Id { get; set; }
        public MovieViewModel? Movie { get; set; }
        public AuditoriumViewModel? Auditorium { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public int SeatsAvailable { get; set; }
        public int SeatsTotal { get; set; }
    }
}
