using CinemaSolution.Data.EF;
using CinemaSolution.ViewModels.Common.Paging;
using CinemaSolution.ViewModels.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Application.User
{
    public class UserService : IUserService
    {
        private readonly CinemaDBContext cinemaDBContext;
        public UserService(CinemaDBContext cinemaDBContext)
        {
            this.cinemaDBContext = cinemaDBContext;
        }

        public async Task<int> GetCount(int? roleId = null)
        {
            if (roleId.HasValue)
            {
                return await cinemaDBContext.UsersInRoles.CountAsync(x => x.RoleId == roleId);
            }
            return await cinemaDBContext.Users.CountAsync();
        }

        public async Task<PagedResult<UserViewModel>> GetPagedResult(GetUserPagingRequest request)
        {
            var userQuery = from u in cinemaDBContext.Users
                            join ur in cinemaDBContext.UsersInRoles on u.Id equals ur.UserId
                            join r in cinemaDBContext.Roles on ur.RoleId equals r.Id
                            select new { u, r };

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                userQuery = userQuery.Where(x => x.u.Username.Contains(request.Keyword) || x.u.Email.Contains(request.Keyword));
            }

            if (request.RoleId.HasValue)
            {
                userQuery = userQuery.Where(x => x.r.Id == request.RoleId);
            }

            var groupedUser = userQuery.GroupBy(x => x.u)
                .Select(x => new UserViewModel
                {
                    Id = x.Key.Id,
                    Username = x.Key.Username,
                    Email = x.Key.Email,
                    FirstName = x.Key.FirstName,
                    LastName = x.Key.LastName,
                    PhoneNumber = x.Key.PhoneNumber,
                    Address = x.Key.Address,
                    AvatarUrl = x.Key.AvatarUrl,
                    BackgroundUrl = x.Key.BackgroundUrl,
                    Roles = x.Select(x => new RoleViewModel
                    {
                        Id = x.r.Id,
                        Name = x.r.Name
                    }).ToList()
                });

            var totalRow = await groupedUser.CountAsync();

            var data = await groupedUser.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            return new PagedResult<UserViewModel>
            {
                TotalRecords = totalRow,
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };
        }
    }
}
