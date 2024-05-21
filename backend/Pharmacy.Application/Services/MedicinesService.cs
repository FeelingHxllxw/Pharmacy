using PharmacyStore.Core.Models;
using PharmacyStore.DataAccess.Repositories;

namespace Pharmacy.Application.Services
{
    public class MedicinesService(IMedicineRepository medicinesRepository) : IMedicinesService
    {
        private readonly IMedicineRepository _medicinesRepository = medicinesRepository;

        public async Task<List<Medicine>> GetAllMedicines()
        {
            return await _medicinesRepository.GetMedicines();
        }

        public async Task<Guid> CreateMedicine(Medicine med)
        {
            return await _medicinesRepository.Create(med);
        }

        public async Task<Guid> UpdateMedicine(Guid code, string name, string type, string category, decimal price)
        {
            return await _medicinesRepository.Update(code, name, type, category, price);
        }

        public async Task<Guid> DeleteMedicine(Guid code)
        {
            return await (_medicinesRepository.Delete(code));
        }

        public async Task<Medicine> GetByIdMedicine(Guid code)
        {
            return await _medicinesRepository.GetMedicineById(code);
        }
    }
}
