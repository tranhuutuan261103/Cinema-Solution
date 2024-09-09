using CinemaSolution.ViewModels.Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.ViewModels.Auditorium
{
    public class GetAuditoriumPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; } = string.Empty;
        public int? CinemaId { get; set; }
        public int? ProvinceId { get; set; }
    }
}
