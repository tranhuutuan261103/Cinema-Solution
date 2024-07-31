using CinemaSolution.ViewModels.Province;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.ViewModels.Cinema
{
    public class CinemaCreateRequest
    {
        public string Name { get; set; } = string.Empty;
        public int ProvinceId { get; set; }
        public string Address { get; set; } = string.Empty;
    }
}
