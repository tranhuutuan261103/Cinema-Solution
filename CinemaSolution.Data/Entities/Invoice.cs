using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Data.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public int TicketId { get; set; }
        public virtual Ticket? Ticket { get; set; }
        public int OrderId { get; set; }
        public virtual Order? Order { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal SumPrice { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public bool IsDeleted { get; set; }
    }
}
