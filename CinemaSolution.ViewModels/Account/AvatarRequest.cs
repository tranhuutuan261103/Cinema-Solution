using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.ViewModels.Account
{
    public class AvatarRequest
    {
        public IFormFile? Avatar { get; set; }
    }
}
