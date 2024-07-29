using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.ViewModels.Common.ItemSelection
{
    public class ItemSelection<T> where T : class
    {
        public T Item { get; set; } = default!;
        public bool IsSelected { get; set; }
    }
}
