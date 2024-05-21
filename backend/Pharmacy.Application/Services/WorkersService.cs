using PharmacyStore.Core.Models;
using PharmacyStore.DataAccess.Repositories;

namespace Pharmacy.Application.Services
{
    public class WorkersService(IWorkerRepository workersRepository) : IWorkersService
    {
        private readonly IWorkerRepository _workersRepository = workersRepository;

        public async Task<Guid> CreateWorker(Worker work)
        {
            return await _workersRepository.Create(work);
        }

        public async Task<Guid> DeleteWorker(Guid id)
        {
            return await (_workersRepository.Delete(id));
        }

        public async Task<List<Worker>> GetAllWorkers()
        {
            return await _workersRepository.GetAllWorkers();
        }

        public async Task<Worker> GetWorkerById(Guid id)
        {
            return await _workersRepository.GetWorkerById(id);
        }

        public async Task<Guid> UpdateWorker(Guid id, string Last_Name, string First_Name, string Middle_Name, DateTime Employment_Date, DateTime Birth_Date, string Education)
        {
            return await _workersRepository.Update(id, Last_Name, First_Name, Middle_Name, Employment_Date, Birth_Date, Education);
        }
    }
}
