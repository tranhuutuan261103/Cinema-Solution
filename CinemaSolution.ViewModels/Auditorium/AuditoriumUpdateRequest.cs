using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.ViewModels.Auditorium
{
    public class AuditoriumUpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int SeatsPerRow { get; set; }
        public int SeatsPerColumn { get; set; }
        public int CinemaId { get; set; }
        public int ProvinceId { get; set; }
        public List<SeatDefaultViewModel> Seats { get; set; } = new List<SeatDefaultViewModel>();
    }
}
