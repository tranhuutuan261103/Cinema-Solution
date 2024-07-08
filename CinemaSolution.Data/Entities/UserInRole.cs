using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Data.Entities
{
    public class UserInRole
    {
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public int RoleId { get; set; }
        public virtual Role? Role { get; set; }
    }
}
