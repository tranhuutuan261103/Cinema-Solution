using CinemaSolution.ViewModels.Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.ViewModels.Screening
{
    public class GetScreeningPagingRequest : PagingRequestBase
    {
        public int? MovieId { get; set; }
        public int? AuditoriumId { get; set; }
    }
}
