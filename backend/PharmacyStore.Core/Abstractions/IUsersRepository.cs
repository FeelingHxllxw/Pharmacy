using PharmacyStore.Core.Models;
namespace PharmacyStore.DataAccess.Repositories
{
    public interface IUsersRepository
    {
        Task<Guid> Create(User user);
        Task<string> Get(string login);
    }
}
