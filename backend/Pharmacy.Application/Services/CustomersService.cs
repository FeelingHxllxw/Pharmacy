using PharmacyStore.Core.Models;
using PharmacyStore.DataAccess.Repositories;

namespace Pharmacy.Application.Services
{
    public class CustomersService(ICustomerRepository customersRepository) : ICustomersService
    {
        private readonly ICustomerRepository _customersRepository = customersRepository;

        public async Task<Guid> CreateCustomer(Customer customer)
        {
            return await _customersRepository.Create(customer);
        }

        public async Task<Guid> DeleteCustomer(Guid id)
        {
            return await (_customersRepository.Delete(id));
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _customersRepository.GetAllCustomers();
        }

        public async Task<Customer> GetCustomerById(Guid id)
        {
            return await _customersRepository.GetById(id);
        }

        public async Task<Guid> UpdateCustomer(Guid id, string Last_Name, string First_Name, string Middle_Name, string Addres, string City, string Phone)
        {
            return await _customersRepository.Update(id, Last_Name, First_Name, Middle_Name, Addres, City, Phone);
        }
    }
}
