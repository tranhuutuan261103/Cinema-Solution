using CinemaSolution.ViewModels.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Application.Comment
{
    public interface ICommentService
    {
        Task<List<CommentViewModel>> GetAll(int movieId, int maxSize = 10, int? userId = null);
        Task<CommentViewModel> Create(int userId, CommentCreateRequest request);
        Task<CommentViewModel> Reply(int userId, CommentReplyRequest request);
        Task<CommentViewModel> Like(int userId, int commentId);
    }
}
