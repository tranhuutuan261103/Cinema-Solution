using CinemaSolution.AdminWebApplication.Filters;
using CinemaSolution.Application.Invoice;
using CinemaSolution.ViewModels.Invoice;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaSolution.AdminWebApplication.Controllers
{
    [Route("invoices")]
    [Authorize(Roles = "Administrator")]
    [SetBarActive("invoice")]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _invoiceService;
        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index(int pageIndex = 1, int pageSize = 5)
        {
            var request = new GetInvoicePagingRequest()
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var invoices = await _invoiceService.GetPagedResult(request);
            return View(invoices);
        }
    }
}
