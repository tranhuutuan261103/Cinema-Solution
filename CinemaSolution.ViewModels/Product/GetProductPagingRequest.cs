using CinemaSolution.ViewModels.Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.ViewModels.Product
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public string? Keyword { get; set; }
    }
}
