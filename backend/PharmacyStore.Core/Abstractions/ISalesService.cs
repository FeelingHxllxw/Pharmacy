using PharmacyStore.Core.Models;


namespace Pharmacy.Application.Services
{
    public interface ISalesService
    {
        Task<Guid> CreateSale(Sale sale);
        Task<Guid> DeleteSale(Guid id);
        Task<List<Sale>> GetAllSales();
        Task<Sale> GetSaleById(Guid id);
        Task<Guid> UpdateSale(Guid Id, DateTime Sale_Date, Guid Medicine_Id, int Count, Guid Recipe_Id, Guid Worker_Id);
    }
}
