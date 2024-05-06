using Microsoft.EntityFrameworkCore;
using PharmacyStore.Core.Models;
using PharmacyStore.DataAccess.Entities;

namespace PharmacyStore.DataAccess.Repositories
{
    public class MedicinesRepository : IMedicineRepository
    {
        private readonly PharmacyDBContext _context;

        public MedicinesRepository(PharmacyDBContext context)
        {
            _context = context;
        }

        public async Task<List<Medicine>> GetMedicines()
        {
            var medicineEntities = await _context.medicines.AsNoTracking().ToListAsync();

            var medicines = medicineEntities.Select(b => Medicine.Create(b.Medicine_Code, b.Name, b.Type, b.Category, b.Price).medicine).ToList();

            return medicines;
        }

        public async Task<Guid> Create(Medicine medicine)
        {
            var medicineEntitie = new Medicine_Entity
            {
                Medicine_Code = medicine.Medicine_Code,
                Name = medicine.Medicine_Name,
                Type = medicine.Medicine_Type,
                Category = medicine.Medicine_Category,
                Price = medicine.Medicine_Price,
            };

            await _context.medicines.AddAsync(medicineEntitie);
            await _context.SaveChangesAsync();

            return medicineEntitie.Medicine_Code;
        }

        public async Task<Guid> Update(Guid code, string name, string type, string category, decimal price)
        {
            await _context.medicines
                .Where(b => b.Medicine_Code == code)
                .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Name, b => name)
                .SetProperty(b => b.Type, b => type)
                .SetProperty(b => b.Category, b => category)
                .SetProperty(b => b.Price, b => price));
            return code;
        }

        public async Task<Guid> Delete(Guid code)
        {
            await _context.medicines.Where(b => b.Medicine_Code == code).ExecuteDeleteAsync();
            return code;
        }

        public async Task<Medicine> GetMedicineById(Guid id)
        {
            var medicineEntity = await _context.medicines.FindAsync(id);
            var medicine = Medicine.Create(medicineEntity.Medicine_Code,
                                           medicineEntity.Name,
                                           medicineEntity.Type,
                                           medicineEntity.Category,
                                           medicineEntity.Price).medicine;
            return medicine;
            
           
        }
    }
}
