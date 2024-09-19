using CinemaSolution.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.ViewModels.Invoice
{
    public class InvoiceCreateRequest
    {
        public int UserId { get; set; }
        public List<InvoiceSeatCreateRequest>? Seats { get; set; }
        public int ScreeningId { get; set; }
        public DateTime DateOfPurchase { get; set; }
    }
}
