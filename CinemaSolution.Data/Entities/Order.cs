using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public virtual Invoice? Invoice { get; set; }
        public int TotalPrice { get; set; }
        public bool IsDeleted { get; set; }
        public virtual List<ProductComboInOrder>? ProductComboInOrders { get; set; }
    }
}
