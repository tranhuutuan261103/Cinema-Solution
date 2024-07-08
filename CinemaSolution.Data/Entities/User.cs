using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordSalt { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public bool IsDeleted { get; set; }
        public virtual List<UserInRole>? UserInRoles { get; set; }
        public virtual List<Invoice>? Invoices { get; set; }
        public virtual List<Rating>? Ratings { get; set; }
        public virtual List<Comment>? Comments { get; set; }
    }
}
