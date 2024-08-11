using CinemaSolution.ViewModels.Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.ViewModels.User
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string? Keyword { get; set; }
        public int? RoleId { get; set; }
    }
}
