using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Api.Dtos;
using Api.Services;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxController : ControllerBase
    {
        private readonly CentralRevenueService _centralRevenueService;

        public TaxController(CentralRevenueService centralRevenueService)
        {
            _centralRevenueService = centralRevenueService;
        }

        [HttpPost("pay")]
        public async Task<IActionResult> PayTax()
        {
            var result = await _centralRevenueService.ProcessTaxPayment();
            return Ok(result);
        }
    }
}