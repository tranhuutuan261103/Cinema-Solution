using CinemaSolution.ViewModels.Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.ViewModels.Cinema
{
    public class GetCinemaPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public int? ProvinceId { get; set; }
    }
}
