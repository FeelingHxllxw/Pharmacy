using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using Pharmacy.Application.Services;
using Pharmacy.Contracts;
using PharmacyStore.Core.Models;

namespace Pharmacy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ISalesService _salesService;

        public SalesController(ISalesService salesService)
        {
            _salesService = salesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SalesResponse>>> GetSales()
        {
            var sales = await _salesService.GetAllSales();

            var responce = sales.Select(b => new SalesResponse(b.Sale_Id, b.Sale_Date, b.Medicine_Id, b.Medicine, b.Count, b.Recipe_Id, b.Diagnosis, b.Worker_Id, b.Name));

            return Ok(responce);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<SalesResponse>> GetSaleById(Guid id)
        {
            var sale = await _salesService.GetSaleById(id);

            var response = new SalesResponse(sale.Sale_Id, sale.Sale_Date, sale.Medicine_Id, sale.Medicine, sale.Count, sale.Recipe_Id, sale.Diagnosis, sale.Worker_Id, sale.Name);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateSale([FromBody] SalesRequest request)
        {
            var sale = new Sale(Guid.NewGuid(), request.Sale_Date, request.Medicine_Id, request.Count, request.Recipe_Id, request.WorkerId);

            var saleId = await _salesService.CreateSale(sale);

            return Ok(saleId);
        }
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateSale(Guid id, [FromBody] SalesRequest request)
        {
            var saleId = await _salesService.UpdateSale(id, request.Sale_Date, request.Medicine_Id, request.Count, request.Recipe_Id, request.WorkerId);
            return Ok(saleId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteSale(Guid id)
        {
            return Ok(await _salesService.DeleteSale(id));
        }
    }
}
