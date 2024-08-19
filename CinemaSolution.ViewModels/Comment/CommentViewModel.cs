using CinemaSolution.ViewModels.Rating;
using CinemaSolution.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.ViewModels.Comment
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
        public UserViewModel User { get; set; } = new UserViewModel();
        public int MovieId { get; set; }
        public RatingViewModel Rating { get; set; } = new RatingViewModel();
        public List<CommentViewModel> Replies { get; set; } = new List<CommentViewModel>();
    }
}
