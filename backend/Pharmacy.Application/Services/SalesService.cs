
using PharmacyStore.Core.Models;
using PharmacyStore.DataAccess.Repositories;


namespace Pharmacy.Application.Services
{
    public class SalesService(ISalesRepository salesRepository) : ISalesService
    {
        private readonly ISalesRepository _salesRepository = salesRepository;

        public async Task<Guid> CreateSale(Sale sale)
        {
            return await _salesRepository.Create(sale);
        }

        public async Task<Guid> DeleteSale(Guid id)
        {
            return await _salesRepository.Delete(id);
        }

        public async Task<List<Sale>> GetAllSales()
        {
            return await _salesRepository.GetSales();
        }

        public async Task<Sale> GetSaleById(Guid id)
        {
            return await _salesRepository.GetSaleById(id);
        }

        public async Task<Guid> UpdateSale(Guid Id, DateTime Sale_Date, Guid Medicine_Id, int Count, Guid Recipe_Id, Guid Worker_Id)
        {
            return await _salesRepository.Update(Id, Sale_Date, Medicine_Id, Count, Recipe_Id, Worker_Id);
        }
    }
}
