using PharmacyStore.Core.Models;

namespace PharmacyStore.DataAccess.Repositories
{
    public interface ISalesRepository
    {
        Task<Guid> Create(Sale sale);
        Task<Guid> Delete(Guid id);
        Task<List<Sale>> GetSales();
        Task<Sale> GetSaleById(Guid id);
        Task<Guid> Update(Guid Id, DateTime Sale_Date, Guid Medicine_Id, int Count, Guid Recipe_Id, Guid Worker_Id);
    }
}
