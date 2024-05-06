using PharmacyStore.Core.Models;

namespace Pharmacy.Application.Services
{
    public interface IWorkersService
    {
        Task<Guid> CreateWorker(Worker work);
        Task<Guid> DeleteWorker(Guid id);
        Task<List<Worker>> GetAllWorkers();

        Task<Worker> GetWorkerById(Guid id);

        Task<Guid> UpdateWorker(Guid id, string Last_Name, string First_Name, string Middle_Name, DateTime Employment_Date, DateTime Birth_Date, string Education);
    }
}