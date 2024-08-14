using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.ViewModels.User
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? AvatarUrl { get; set; }
        public string? BackgroundUrl { get; set; }
        public List<RoleViewModel> Roles { get; set; } = new List<RoleViewModel>();
    }
}
