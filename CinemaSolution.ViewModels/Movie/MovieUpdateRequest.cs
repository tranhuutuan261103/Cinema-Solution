using CinemaSolution.ViewModels.Category;
using CinemaSolution.ViewModels.Common.ItemSelection;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.ViewModels.Movie
{
    public class MovieUpdateRequest
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public List<ItemSelection<CategoryViewModel>> Categories { get; set; } = new List<ItemSelection<CategoryViewModel>>();
        public string Language { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public string Actors { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string TrailerUrl { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;
        public int Duration { get; set; }
        public IFormFile? ThumbnailImage3x2 { get; set; }
        public string? ThumbnailImage3x2Url { get; set; }
        public IFormFile? ThumbnailImage2x3 { get; set; }
        public string? ThumbnailImage2x3Url { get; set; }
    }
}
