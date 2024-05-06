using PharmacyStore.Core.Models;

namespace PharmacyStore.DataAccess.Repositories
{
    public interface ICustomerRepository
    {
        Task<Guid> Create(Customer customer);
        Task<Guid> Delete(Guid id);
        Task<List<Customer>> GetAllCustomers();
        Task<Customer> GetById(Guid id);
        Task<Guid> Update(Guid id, string Last_Name, string First_Name, string Middle_Name, string Addres, string City, string Phone);
    }
}