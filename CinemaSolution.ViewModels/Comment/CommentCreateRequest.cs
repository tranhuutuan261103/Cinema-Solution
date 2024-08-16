using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.ViewModels.Comment
{
    public class CommentCreateRequest
    {
        public string Content { get; set; } = string.Empty;
        public int MovieId { get; set; }
        public int RatingValue { get; set; }
    }
}
