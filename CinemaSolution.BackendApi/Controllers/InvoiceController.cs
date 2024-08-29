﻿using CinemaSolution.Application.Invoice;
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
        // [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var userId = "2" as string;
                if (string.IsNullOrEmpty(userId))
                {
                    return BadRequest("User ID not found.");
                }
                var invoices = await _invoiceService.GetInvoicesByUserId(int.Parse(userId));
                return Json(invoices);
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting invoices.");
                return BadRequest(ex);
            }
        }
    }
}
