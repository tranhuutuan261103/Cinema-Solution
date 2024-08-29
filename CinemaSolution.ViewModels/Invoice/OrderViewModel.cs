using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.ViewModels.Invoice
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public List<ProductComboViewModel> ProductCombos { get; set; } = new List<ProductComboViewModel>();
        public int TotalPrice { get; set; }
    }
}
