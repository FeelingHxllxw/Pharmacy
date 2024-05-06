using PharmacyStore.Core.Models;

namespace PharmacyStore.DataAccess.Repositories
{
    public interface IMedicineRepository
    {
        Task<Guid> Create(Medicine medicine);
        Task<Guid> Delete(Guid code);
        Task<List<Medicine>> GetMedicines();
        Task<Medicine> GetMedicineById(Guid code);
        Task<Guid> Update(Guid code, string name, string type, string category, decimal price);
    }
}