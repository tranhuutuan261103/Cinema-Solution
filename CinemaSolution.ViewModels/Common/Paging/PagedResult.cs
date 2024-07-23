using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.ViewModels.Common.Paging
{
    public class PagedResult<T> : PagedResultBase where T : class
    {
        public IList<T> Items { get; set; }
        public PagedResult()
        {
            Items = new List<T>();
        }
    }
}
