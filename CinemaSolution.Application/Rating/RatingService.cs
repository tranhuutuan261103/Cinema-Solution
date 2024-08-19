using CinemaSolution.Data.EF;
using CinemaSolution.ViewModels.Rating;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Application.Rating
{
    public class RatingService : IRatingService
    {
        private readonly CinemaDBContext cinemaDBContext;
        public RatingService(CinemaDBContext cinemaDBContext)
        {
            this.cinemaDBContext = cinemaDBContext;
        }

        public async Task<List<RatingCountViewModel>> GetAllRatingCount(int movieId)
        {
            var ratings = from r in cinemaDBContext.Ratings
                          where r.MovieId == movieId
                          group r by r.Value into g
                          select new RatingCountViewModel
                          {
                              Value = g.Key,
                              Count = g.Count()
                          };
            return await ratings.ToListAsync();
        }
    }
}
