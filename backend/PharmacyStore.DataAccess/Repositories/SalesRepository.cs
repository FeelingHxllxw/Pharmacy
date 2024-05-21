using Microsoft.EntityFrameworkCore;
using PharmacyStore.Core.Models;
using PharmacyStore.DataAccess.Entities;

namespace PharmacyStore.DataAccess.Repositories
{
    public class SalesRepository : ISalesRepository
    {
        private readonly PharmacyDBContext _context;

        public SalesRepository(PharmacyDBContext context)
        {
            _context = context;
        }

        public async Task<Guid> Create(Sale sale)
        {
            var saleEntity = new Sale_Entity
            {
                Sale_Id = sale.Sale_Id,
                Sale_Date = sale.Sale_Date,
                Medicine_Code = sale.Medicine_Id,
                Count = sale.Count,
                Recipe_Id = sale.Recipe_Id,
                Worker_Id = sale.Worker_Id
            };
            await _context.sales.AddAsync(saleEntity);
            await _context.SaveChangesAsync();
            return sale.Sale_Id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.sales.Where(b => b.Sale_Id == id).ExecuteDeleteAsync();
            return id;
        }

        public async Task<Sale> GetSaleById(Guid id)
        {
            var saleEntity = await _context.sales.FindAsync(id);
            var sale = new Sale(saleEntity.Sale_Id, saleEntity.Sale_Date, saleEntity.Medicine_Code, saleEntity.Count, saleEntity.Recipe_Id, saleEntity.Worker_Id);
            var Medicine = _context.medicines.Where(p => p.Medicine_Code == sale.Medicine_Id).Select(p => p.Name).SingleOrDefault();
            var Diagnosis = _context.recipes.Where(p => p.Recipe_Id == sale.Recipe_Id).Select(p => p.Diagnosis).SingleOrDefault();
            var name = _context.pharmacists.Where(p => p.Worker_Id == sale.Worker_Id).Select(p => $"{p.First_Name} {p.Last_Name} {p.Middle_Name}").SingleOrDefault();
            sale.Medicine = Medicine;
            sale.Diagnosis = Diagnosis;
            sale.Name = name;
            return sale;

        }

        public async Task<List<Sale>> GetSales()
        {
            var saleEntites = await _context.sales.AsNoTracking().ToListAsync();
            var sales = saleEntites.Select(b => new Sale(b.Sale_Id, b.Sale_Date, b.Medicine_Code, b.Count, b.Recipe_Id, b.Worker_Id)).ToList();
            foreach (var sale in sales)
            {
                var Medicine = _context.medicines.Where(p => p.Medicine_Code == sale.Medicine_Id).Select(p => p.Name).SingleOrDefault();
                var Diagnosis = _context.recipes.Where(p => p.Recipe_Id == sale.Recipe_Id).Select(p => p.Diagnosis).SingleOrDefault();
                var name = _context.pharmacists.Where(p => p.Worker_Id == sale.Worker_Id).Select(p => $"{p.First_Name} {p.Last_Name} {p.Middle_Name}").SingleOrDefault();
                sale.Medicine = Medicine;
                sale.Diagnosis = Diagnosis;
                sale.Name = name;
            }
            return sales;
        }

        public async Task<Guid> Update(Guid Id, DateTime Sale_Date, Guid Medicine_Id, int Count, Guid Recipe_Id, Guid Worker_Id)
        {
            await _context.sales.Where(b => b.Sale_Id == Id).ExecuteUpdateAsync(b => b
            .SetProperty(b => b.Sale_Date, b=> Sale_Date)
            .SetProperty(b => b.Medicine_Code, b=> Medicine_Id)
            .SetProperty(b => b.Count, b => Count)
            .SetProperty(b => b.Recipe_Id, b=>Recipe_Id)
            .SetProperty(b => b.Worker_Id, b=>Worker_Id)
            );
            return Id;
        }
    }
}
