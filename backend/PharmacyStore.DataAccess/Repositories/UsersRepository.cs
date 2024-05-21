using Microsoft.EntityFrameworkCore;
using PharmacyStore.Core.Models;
using PharmacyStore.DataAccess.Entities;

namespace PharmacyStore.DataAccess.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly PharmacyDBContext _context;

        public UsersRepository(PharmacyDBContext context)
        {
            _context = context;
        }

        public async Task<Guid> Create(User user)
        {
            var userEntity = new User_Entity
            {
                Id = user.ID,
                Login = user.Login,
                Password = user.Password
            };
            await _context.users.AddAsync(userEntity);
            await _context.SaveChangesAsync();

            return userEntity.Id;
        }

        public async Task<string> Get(string login)
        {
            var userEntity = await _context.users.AsNoTracking().FirstOrDefaultAsync(u => u.Login == login) ?? throw new Exception();

            var userPassword = userEntity.Password;
            return userPassword;
        }

        //public async Task<Guid> Update(Guid id, string name, decimal hours, decimal salary)
        //{
        //    await _context.positions.Where(p => p.id == id).ExecuteUpdateAsync(s => s
        //        .SetProperty(p => p.name, p => name)
        //        .SetProperty(p => p.hours, p => hours)
        //        .SetProperty(p => p.salary, p => salary));
        //    return id;
        //}

        //public async Task<Guid> Delete(Guid id)
        //{
        //    await _context.positions
        //        .Where(p => p.id == id).ExecuteDeleteAsync();
        //    return id;
        //}
    }
}
