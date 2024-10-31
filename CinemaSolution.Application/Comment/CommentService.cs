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

        public async Task<List<CommentViewModel>> GetAll(int movieId, int maxSize = 10, int? userId = null)
        {
            var comments = from c in cinemaDBContext.Comments
                           join u in cinemaDBContext.Users on c.UserId equals u.Id
                           join m in cinemaDBContext.Movies on c.MovieId equals m.Id
                           join r in cinemaDBContext.Ratings on new { c.UserId, c.MovieId } equals new { r.UserId, r.MovieId }
                           join cl in cinemaDBContext.CommentLikes on c.Id equals cl.CommentId into commentLikes
                           where c.MovieId == movieId && c.ParentId == null
                           orderby commentLikes.Count() descending
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
                               },
                               Replies = (from reply in cinemaDBContext.Comments
                                          join replyUser in cinemaDBContext.Users on reply.UserId equals replyUser.Id
                                          join replyRating in cinemaDBContext.Ratings on new { reply.UserId, reply.MovieId } equals new { replyRating.UserId, replyRating.MovieId }
                                          where reply.ParentId == c.Id
                                          orderby reply.CreatedDate
                                          select new CommentViewModel
                                          {
                                              Id = reply.Id,
                                              Content = reply.Content,
                                              CreatedDate = reply.CreatedDate,
                                              IsDeleted = reply.IsDeleted,
                                              User = new ViewModels.User.UserViewModel
                                              {
                                                  Id = replyUser.Id,
                                                  Username = replyUser.Username,
                                                  Email = replyUser.Email,
                                                  AvatarUrl = replyUser.AvatarUrl,
                                                  FirstName = replyUser.FirstName,
                                                  LastName = replyUser.LastName,
                                              },
                                              MovieId = reply.MovieId,
                                              Rating = new ViewModels.Rating.RatingViewModel
                                              {
                                                  MovieId = reply.MovieId,
                                                  UserId = reply.UserId,
                                                  Value = replyRating.Value
                                              }
                                          }).ToList(),
                               Likes = commentLikes.Count(),
                               IsLiked = userId == null ? false : commentLikes.Any(cl => cl.UserId == userId)
                           };

            if (maxSize > 0)
            {
                comments = comments.Take(maxSize);
            }

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

        public async Task<CommentViewModel> Reply(int userId, CommentReplyRequest request)
        {
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
                    ParentId = request.ParentId,
                };
                cinemaDBContext.Comments.Add(comment);
                await cinemaDBContext.SaveChangesAsync();

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
                        Value = 0
                    },
                    IsLiked = false
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating comment", ex);
            }
        }

        public async Task<CommentViewModel> Like(int userId, int commentId)
        {
            // Fetch the comment from the database
            var comment = await cinemaDBContext.Comments.FindAsync(commentId);
            if (comment == null)
            {
                throw new Exception("Comment not found");
            }

            // Check if the user has already liked the comment
            var commentLike = await cinemaDBContext.CommentLikes
                .FirstOrDefaultAsync(cl => cl.CommentId == commentId && cl.UserId == userId);

            // If the user has liked the comment, remove the like
            if (commentLike != null)
            {
                cinemaDBContext.CommentLikes.Remove(commentLike);
            }
            else
            {
                // Otherwise, add a new like
                var newCommentLike = new Data.Entities.CommentLike
                {
                    CommentId = commentId,
                    UserId = userId,
                    CreatedAt = DateTime.Now
                };
                cinemaDBContext.CommentLikes.Add(newCommentLike);
            }

            // Save changes to the database
            await cinemaDBContext.SaveChangesAsync();

            // Query the updated comment details including likes and replies
            var commentUpdated = from c in cinemaDBContext.Comments
                                 join u in cinemaDBContext.Users on c.UserId equals u.Id
                                 join m in cinemaDBContext.Movies on c.MovieId equals m.Id
                                 join r in cinemaDBContext.Ratings on new { c.UserId, c.MovieId } equals new { r.UserId, r.MovieId }
                                 join cl in cinemaDBContext.CommentLikes on c.Id equals cl.CommentId into commentLikes
                                 where c.Id == commentId
                                 orderby commentLikes.Count() descending
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
                                     },
                                     Likes = commentLikes.Count(),
                                     IsLiked = commentLikes.Any(cl => cl.UserId == userId)
                                 };

            // Return the updated comment or handle null if not found
            var result = await commentUpdated.FirstOrDefaultAsync();
            if (result == null)
            {
                throw new Exception("Failed to retrieve the updated comment");
            }

            return result;
        }
    }
}
