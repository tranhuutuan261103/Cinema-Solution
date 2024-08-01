using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.ViewModels.Auditorium
{
    public class AuditoriumViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CinemaId { get; set; }
        public int SeatsPerRow { get; set; }
        public int SeatsPerColumn { get; set; }
    }
}
