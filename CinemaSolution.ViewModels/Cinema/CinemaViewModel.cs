using CinemaSolution.ViewModels.Auditorium;
using CinemaSolution.ViewModels.Province;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.ViewModels.Cinema
{
    public class CinemaViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LogoUrl { get; set; } = string.Empty;
        public List<AuditoriumViewModel> Auditoriums { get; set; } = new List<AuditoriumViewModel>();
        public bool IsDeleted { get; set; }
    }
}
