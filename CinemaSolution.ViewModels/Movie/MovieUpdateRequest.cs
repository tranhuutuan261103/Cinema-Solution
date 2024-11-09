using CinemaSolution.ViewModels.Category;
using CinemaSolution.ViewModels.Common.ItemSelection;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.ViewModels.Movie
{
    public class MovieUpdateRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = string.Empty;
        public List<ItemSelection<CategoryViewModel>> Categories { get; set; } = new List<ItemSelection<CategoryViewModel>>();
        [Required(ErrorMessage = "Language is required")]
        public string Language { get; set; } = string.Empty;
        [Required(ErrorMessage = "Director is required")]
        public string Director { get; set; } = string.Empty;
        [Required(ErrorMessage = "Actors is required")]
        public string Actors { get; set; } = string.Empty;
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "Trailer URL is required")]
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
