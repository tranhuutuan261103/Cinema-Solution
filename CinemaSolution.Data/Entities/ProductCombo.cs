using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Data.Entities
{
    public class ProductCombo
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int Price { get; set; }
        public bool IsDeleted { get; set; }

        public virtual List<ProductInProductCombo>? ProductInProductCombos { get; set; }
        public virtual List<ProductComboInOrder>? ProductComboInOrders { get; set; }
    }
}
