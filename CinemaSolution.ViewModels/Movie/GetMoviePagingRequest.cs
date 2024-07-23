using CinemaSolution.ViewModels.Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.ViewModels.Movie
{
    public class GetMoviePagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
    }
}
