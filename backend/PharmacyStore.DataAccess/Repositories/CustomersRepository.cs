using Microsoft.EntityFrameworkCore;
using PharmacyStore.Core.Models;
using PharmacyStore.DataAccess.Entities;

namespace PharmacyStore.DataAccess.Repositories
{
    public class CustomersRepository : ICustomerRepository
    {
        private readonly PharmacyDBContext _context;

        public CustomersRepository(PharmacyDBContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            var customerEntities = await _context.customers.AsNoTracking().ToListAsync();

            var customers = customerEntities.Select(b => Customer.Create(b.Customer_Id, b.Last_Name, b.First_Name, b.Middle_Name, b.Addres, b.City, b.Phone).customer).ToList();

            return customers;
        }

        public async Task<Guid> Create(Customer customer)
        {
            var customerEntitie = new Customer_Entity
            {
                Customer_Id = customer.Customer_Id,
                Last_Name = customer.Last_Name,
                First_Name = customer.First_Name,
                Middle_Name = customer.Middle_Name,
                Addres = customer.Addres,
                City = customer.City,
                Phone = customer.Phone,
            };

            await _context.customers.AddAsync(customerEntitie);
            await _context.SaveChangesAsync();

            return customerEntitie.Customer_Id;
        }

        public async Task<Guid> Update(Guid id, string Last_Name, string First_Name, string Middle_Name, string Addres, string City, string Phone)
        {
            await _context.customers
                .Where(b => b.Customer_Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Last_Name, b => Last_Name)
                .SetProperty(b => b.First_Name, b => First_Name)
                .SetProperty(b => b.Middle_Name, b => Middle_Name)
                .SetProperty(b => b.Addres, b => Addres)
                .SetProperty(b => b.City, b => City)
                .SetProperty(b => b.Phone, b => Phone));
            return id;
        }

        public async Task<Guid> Delete(Guid code)
        {
            await _context.customers.Where(b => b.Customer_Id == code).ExecuteDeleteAsync();
            return code;
        }

        public async Task<Customer> GetById(Guid id)
        {
            var customerEntity = await _context.customers.FindAsync(id);
            var customer = Customer.Create(customerEntity.Customer_Id,
                                           customerEntity.Last_Name,
                                           customerEntity.First_Name,
                                           customerEntity.Middle_Name,
                                           customerEntity.Addres,
                                           customerEntity.City,
                                           customerEntity.Phone).customer;
            return customer;
        }
    }
}
