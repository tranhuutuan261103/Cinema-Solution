using CinemaSolution.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.ViewModels.Invoice
{
    public class InvoiceViewModel
    {
        public int Id { get; set; }
        public UserViewModel User { get; set; } = new UserViewModel();
        public TicketViewModel? Ticket { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal SumPrice { get; set; }
        public DateTime DateOfPurchase { get; set; }
    }
}
