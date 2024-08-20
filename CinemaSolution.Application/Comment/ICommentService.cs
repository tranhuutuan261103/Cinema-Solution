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
        Task<List<CommentViewModel>> GetAll(int movieId);
        Task<CommentViewModel> Create(int userId, CommentCreateRequest request);
        Task<CommentViewModel> Like(int userId, int commentId);
    }
}
