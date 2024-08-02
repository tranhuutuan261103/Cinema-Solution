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
        public MovieViewModel Movie { get; set; } = new MovieViewModel();
        public AuditoriumViewModel Auditorium { get; set; } = new AuditoriumViewModel();
        public DateTime StartDate { get; set; }
        public TimeSpan StartTime { get; set; }
    }
}
