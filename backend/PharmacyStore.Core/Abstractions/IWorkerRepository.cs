using PharmacyStore.Core.Models;

namespace PharmacyStore.DataAccess.Repositories
{
    public interface IWorkerRepository
    {
        Task<Guid> Create(Worker worker);
        Task<Guid> Delete(Guid id);
        Task<List<Worker>> GetAllWorkers();
        Task<Worker> GetWorkerById(Guid id);
        Task<Guid> Update(Guid id, string Last_Name, string First_Name, string Middle_Name, DateTime Employment_Date, DateTime Birth_Date, string Education);
    }
}