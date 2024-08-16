using Azure.Core;
using CinemaSolution.Data.EF;
using CinemaSolution.ViewModels.Comment;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Application.Comment
{
    public class CommentService : ICommentService
    {
        private readonly CinemaDBContext cinemaDBContext;
        public CommentService(CinemaDBContext cinemaDBContext)
        {
            this.cinemaDBContext = cinemaDBContext;
        }

        public async Task<List<CommentViewModel>> GetAll(int movieId)
        {
            var comments = from c in cinemaDBContext.Comments
                           join u in cinemaDBContext.Users on c.UserId equals u.Id
                           join m in cinemaDBContext.Movies on c.MovieId equals m.Id
                           join r in cinemaDBContext.Ratings on new { c.UserId, c.MovieId } equals new { r.UserId, r.MovieId }
                           where c.MovieId == movieId && r != null
                           select new CommentViewModel
                           {
                               Id = c.Id,
                               Content = c.Content,
                               CreatedDate = c.CreatedDate,
                               IsDeleted = c.IsDeleted,
                               User = new ViewModels.User.UserViewModel
                               {
                                   Id = u.Id,
                                   Username = u.Username,
                                   Email = u.Email,
                                   AvatarUrl = u.AvatarUrl,
                                   FirstName = u.FirstName,
                                   LastName = u.LastName,
                               },
                               MovieId = c.MovieId,
                               Rating = new ViewModels.Rating.RatingViewModel
                               {
                                   MovieId = c.MovieId,
                                   UserId = c.UserId,
                                   Value = r.Value
                               }
                           };
            return await comments.ToListAsync();
        }
        public async Task<CommentViewModel> Create(int userId, CommentCreateRequest request)
        {
            if (request.RatingValue < 1 || request.RatingValue > 10)
            {
                throw new Exception("Rating value must be between 1 and 10");
            }
            if (string.IsNullOrEmpty(request.Content))
            {
                throw new Exception("Content must not be empty");
            }
            if (request.Content.Length > 256)
            {
                throw new Exception("Content must not exceed 256 characters");
            }
            try
            {
                var user = await cinemaDBContext.Users.FindAsync(userId);
                if (user == null)
                {
                    throw new Exception("User not found");
                }

                var comment = new Data.Entities.Comment
                {
                    Content = request.Content,
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,
                    UserId = userId,
                    MovieId = request.MovieId,
                };
                cinemaDBContext.Comments.Add(comment);
                await cinemaDBContext.SaveChangesAsync();

                var ratingExists = await cinemaDBContext.Ratings.FirstOrDefaultAsync(r => r.MovieId == request.MovieId && r.UserId == userId);
                if (ratingExists != null)
                {
                    ratingExists.Value = request.RatingValue;
                    cinemaDBContext.Ratings.Update(ratingExists);
                    await cinemaDBContext.SaveChangesAsync();
                } else
                {
                    var rating = new Data.Entities.Rating
                    {
                        MovieId = request.MovieId,
                        UserId = userId,
                        Value = request.RatingValue
                    };
                    cinemaDBContext.Ratings.Add(rating);
                    await cinemaDBContext.SaveChangesAsync();
                }

                return new CommentViewModel
                {
                    Id = comment.Id,
                    Content = comment.Content,
                    CreatedDate = comment.CreatedDate,
                    IsDeleted = comment.IsDeleted,
                    User = new ViewModels.User.UserViewModel
                    {
                        Id = userId,
                        Username = user.Username,
                        Email = user.Email,
                        AvatarUrl = user.AvatarUrl,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                    },
                    MovieId = comment.MovieId,
                    Rating = new ViewModels.Rating.RatingViewModel
                    {
                        MovieId = comment.MovieId,
                        UserId = comment.UserId,
                        Value = request.RatingValue
                    }
                };
            } catch (Exception ex)
            {
                throw new Exception("Error creating comment", ex);
            }
        }
    }
}
