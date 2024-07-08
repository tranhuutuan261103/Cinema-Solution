using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Data.Entities
{
    public class ProductComboInOrder
    {
        public int ProductComboId { get; set; }
        public virtual ProductCombo? ProductCombo { get; set; }
        public int OrderId { get; set; }
        public virtual Order? Order { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
