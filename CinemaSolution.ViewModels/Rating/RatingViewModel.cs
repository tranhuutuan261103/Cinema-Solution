using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.ViewModels.Rating
{
    public class RatingViewModel
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public int Value { get; set; }
    }
}
