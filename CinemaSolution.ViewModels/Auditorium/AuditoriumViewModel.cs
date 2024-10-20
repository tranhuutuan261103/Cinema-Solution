﻿using CinemaSolution.ViewModels.Cinema;
using CinemaSolution.ViewModels.Province;
using CinemaSolution.ViewModels.Screening;
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
        public CinemaViewModel? Cinema { get; set; }
        public ProvinceViewModel? Province { get; set; }
        public string Address { get; set; } = string.Empty;
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int SeatsPerRow { get; set; }
        public int SeatsPerColumn { get; set; }
        public string SeatMapVector { get; set; } = string.Empty;
        public List<ScreeningViewModel> Screenings { get; set; } = new List<ScreeningViewModel>();
    }
}
