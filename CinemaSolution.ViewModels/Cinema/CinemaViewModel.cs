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
        public ProvinceViewModel Province { get; set; } = new ProvinceViewModel();
        public string Address { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
    }
}
