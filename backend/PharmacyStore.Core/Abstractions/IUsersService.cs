using PharmacyStore.Core.Models;


namespace Pharmacy.Application.Services
{
    public interface IUsersService
    {
        string Generate(string password);
        Task<string> Login(User userLogin);
        Task<Guid> Register(User user);
        bool Verify(string password, string passwordHash);
    }
}
