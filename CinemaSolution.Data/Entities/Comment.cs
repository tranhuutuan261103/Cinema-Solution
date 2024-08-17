using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Data.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? ParentId { get; set; }
        public virtual Comment? Parent { get; set; }
        public virtual ICollection<Comment>? Replies { get; set; } // Thêm thuộc tính này để lưu các comment con
        public bool IsDeleted { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public int MovieId { get; set; }
        public virtual Movie? Movie { get; set; }
        public virtual ICollection<CommentLike>? CommentLikes { get; set; }
    }
}
