using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Data.Entities
{
    public class CommentLike
    {
        public int CommentId { get; set; }
        public virtual Comment? Comment { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
