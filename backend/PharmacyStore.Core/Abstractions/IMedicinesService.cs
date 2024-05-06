using PharmacyStore.Core.Models;

namespace Pharmacy.Application.Services
{
    public interface IMedicinesService
    {
        Task<Guid> CreateMedicine(Medicine med);
        Task<Guid> DeleteMedicine(Guid code);
        Task<List<Medicine>> GetAllMedicines();
        Task<Medicine> GetByIdMedicine(Guid code);
        Task<Guid> UpdateMedicine(Guid code, string name, string type, string category, decimal price);
    }
}