using Microsoft.AspNetCore.Mvc;
using Pharmacy.Application.Services;
using Pharmacy.Contracts;
using PharmacyStore.Core.Models;

namespace Pharmacy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkersController :ControllerBase
    {
        private readonly IWorkersService _workersService;

        public WorkersController(IWorkersService workersService)
        {
            _workersService = workersService;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<WorkersResponse>>> GetWorkers()
        {
            var workers = await _workersService.GetAllWorkers();

            var responce = workers.Select(b => new WorkersResponse(b.Worker_Id, b.Last_Name, b.First_Name, b.Middle_Name, b.Employment_Date, b.Birth_Date, b.Education));

            return Ok(responce);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<WorkersResponse>> GetByIdWorker(Guid id)
        {
            var worker = await _workersService.GetWorkerById(id);
            var response = new WorkersResponse(worker.Worker_Id, worker.Last_Name, worker.First_Name, worker.Middle_Name, worker.Employment_Date, worker.Birth_Date, worker.Education);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateWorker([FromBody] WorkersRequest request)
        {
            var (worker, error) = Worker.Create(Guid.NewGuid(), request.Last_name, request.First_Name, request.Middle_Name, request.Employment_Date, request.Birth_Date, request.Education);

            if(!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            await _workersService.CreateWorker(worker);

            return Ok(worker.Worker_Id);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateWorker(Guid id, [FromBody] WorkersRequest request)
        {
            var workId = await _workersService.UpdateWorker(id, request.Last_name, request.First_Name, request.Middle_Name, request.Employment_Date, request.Birth_Date, request.Education);

            return Ok(workId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteWorker(Guid id)
        {
            return Ok(await _workersService.DeleteWorker(id));
        }
    }
}
