using CinemaSolution.ViewModels.Rating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Application.Rating
{
    public interface IRatingService
    {
        Task<List<RatingCountViewModel>> GetAllRatingCount(int movieId);
    }
}
