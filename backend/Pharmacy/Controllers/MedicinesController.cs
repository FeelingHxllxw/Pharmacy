using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Application.Services;
using Pharmacy.Contracts;
using PharmacyStore.Core.Models;

namespace Pharmacy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class MedicinesController :ControllerBase
    {
        private readonly IMedicinesService _medicinesService;

        public MedicinesController(IMedicinesService medicinesService)
        {
            _medicinesService = medicinesService;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<MedicinesResponse>>> GetMedicines()
        {
            var medicines = await _medicinesService.GetAllMedicines();

            var responce = medicines.Select(b => new MedicinesResponse(b.Medicine_Code, b.Medicine_Name, b.Medicine_Type, b.Medicine_Category, b.Medicine_Price));

            return Ok(responce);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<MedicinesResponse>> GetByIdMedicine(Guid id)
        {
            var medicine = await _medicinesService.GetByIdMedicine(id);
            var response = new MedicinesResponse(medicine.Medicine_Code, medicine.Medicine_Name, medicine.Medicine_Type, medicine.Medicine_Category, medicine.Medicine_Price);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateMedicine([FromBody] MedicinesRequest request)
        {
            var (medicine, error) = Medicine.Create(Guid.NewGuid(), request.name, request.type, request.category, request.price);

            if(!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            await _medicinesService.CreateMedicine(medicine);

            return Ok(medicine.Medicine_Code);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateMedicine(Guid id, [FromBody] MedicinesRequest request)
        {


            var medId = await _medicinesService.UpdateMedicine(id, request.name, request.type, request.category, request.price);

            return Ok(medId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteMedicine(Guid id)
        {
            return Ok(await _medicinesService.DeleteMedicine(id));
        }
    }
}
