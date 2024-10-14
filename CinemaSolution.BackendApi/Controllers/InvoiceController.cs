using CinemaSolution.Application.Invoice;
using CinemaSolution.ViewModels.Invoice;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaSolution.BackendApi.Controllers
{
    [ApiController]
    [Route("api/invoices")]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _invoiceService;
        private readonly ILogger<InvoiceController> _logger;

        public InvoiceController(IInvoiceService invoiceService, ILogger<InvoiceController> logger)
        {
            _invoiceService = invoiceService;
            _logger = logger;
        }

        [HttpGet("")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var userId = HttpContext.Items["UserId"] as string;
                if (string.IsNullOrEmpty(userId))
                {
                    return BadRequest("User ID not found.");
                }
                var invoices = await _invoiceService.GetInvoicesByUserId(int.Parse(userId));
                return Json(invoices);
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting invoices.");
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoiceById(int id)
        {
            try
            {
                var invoice = await _invoiceService.GetInvoiceById(id);
                return Json(invoice);
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting invoice by ID.");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Create(InvoiceCreateRequest request)
        {
            try
            {
                var userId = HttpContext.Items["UserId"] as string;
                if (string.IsNullOrEmpty(userId))
                {
                    return BadRequest("User ID not found.");
                }
                request.UserId = int.Parse(userId);
                var invoice = await _invoiceService.Create(request);
                return CreatedAtAction(nameof(GetInvoiceById), new { id = invoice.Id }, invoice);
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating invoice.");
                return BadRequest(ex.Message);
            }
        }
    }
}
