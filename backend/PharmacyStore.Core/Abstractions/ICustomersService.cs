using PharmacyStore.Core.Models;

namespace Pharmacy.Application.Services
{
    public interface ICustomersService
    {
        Task<Guid> CreateCustomer(Customer customer);
        Task<Guid> DeleteCustomer(Guid id);
        Task<List<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(Guid id);
        Task<Guid> UpdateCustomer(Guid id, string Last_Name, string First_Name, string Middle_Name, string Addres, string City, string Phone);
    }
}